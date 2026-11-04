using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ============================================================================
// 1. [.NET 8-11] Options Pattern with ValidateOnStart
// ============================================================================
// Validates configuration at application boot so missing settings fail early.
builder.Services.AddOptions<OrderProcessingOptions>()
    .BindConfiguration("OrderProcessing")
    .ValidateDataAnnotations()
    .ValidateOnStart();

// ============================================================================
// 2. [.NET 9-11] HybridCache (L1 In-Memory + DB / L2 Store)
// ============================================================================
// Solves cache stampedes: if 50 requests ask for the same customer at once,
// only 1 query runs against SQL/Oracle DB; the other 49 wait and share the result.
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration = TimeSpan.FromMinutes(10),
        LocalCacheExpiration = TimeSpan.FromMinutes(2)
    };
});

// Mock repository simulating Dapper calling SQL / Oracle DB stored procedures
builder.Services.AddSingleton<IDapperOrderRepository, MockDapperOrderRepository>();

// ============================================================================
// 3. [.NET 9-11] Built-in OpenAPI 3.2 Document Generation
// ============================================================================
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Title = "Order Processing Minimal API";
        document.Info.Version = "v11.0";
        document.Info.Description = "Modern .NET 11 Minimal API with model validation and OpenAPI 3.2 schema generation.";
        return Task.CompletedTask;
    });
});

var app = builder.Build();

// Built-in OpenAPI JSON (/openapi/v1.json) and Scalar UI (/scalar/v1)
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.WithTitle("Order API - Scalar Docs")
           .WithTheme(ScalarTheme.Default);
});

// ============================================================================
// Endpoints
// ============================================================================

// --- Fast Health Check ---
app.MapGet("/health", () => Results.Ok(new { status = "Healthy", runtime = Environment.Version.ToString() }))
   .ShortCircuit()
   .WithName("HealthCheck");

// --- GET Orders with HybridCache & TypedResults ---
app.MapGet("/api/customers/{customerId:int}/orders", async Task<Results<Ok<IEnumerable<OrderDto>>, NotFound<string>>> (
    int customerId,
    IDapperOrderRepository repository,
    HybridCache cache,
    CancellationToken ct) =>
{
    string cacheKey = $"customer-orders-{customerId}";

    // HybridCache: 1. RAM lookup; 2. Database lookup with request locking.
    // Note: 'tags' parameter is completely optional (used here if you want tag-based eviction).
    var orders = await cache.GetOrCreateAsync(
        cacheKey,
        async token => await repository.GetOrdersByCustomerIdAsync(customerId, token),
        tags: [$"customer-{customerId}"], // Optional
        cancellationToken: ct
    );

    if (orders is null || !orders.Any())
    {
        return TypedResults.NotFound($"No orders found for Customer ID {customerId}");
    }

    return TypedResults.Ok(orders);
})
.WithName("GetCustomerOrders")
.WithSummary("Fetches customer orders cached via HybridCache");

// --- POST Create Order: Demonstrates Model-Level Validation ---
// Why model validation makes sense:
// Placing validation on the model ensures rules apply equally during INSERT and UPDATE,
// avoiding duplicate validation checks across different endpoints.
app.MapPost("/api/orders", async Task<Results<CreatedAtRoute<OrderDto>, ValidationProblem>> (
    OrderUpsertModel model,
    IDapperOrderRepository repository,
    HybridCache cache,
    CancellationToken ct) =>
{
    // Execute .NET 11 async validation (checks DB existence asynchronously)
    var validationErrors = new Dictionary<string, string[]>();
    await foreach (var validationResult in model.ValidateAsync(new ValidationContext(model), ct))
    {
        foreach (var memberName in validationResult.MemberNames)
        {
            validationErrors[memberName] = [validationResult.ErrorMessage ?? "Validation error"];
        }
    }

    if (validationErrors.Count > 0)
    {
        return TypedResults.ValidationProblem(validationErrors);
    }

    var createdOrder = await repository.CreateOrderAsync(model, ct);

    // Optional cache eviction
    await cache.RemoveByTagAsync([$"customer-{model.CustomerId}"], ct);

    return TypedResults.CreatedAtRoute(
        createdOrder,
        routeName: "GetCustomerOrders",
        routeValues: new { customerId = model.CustomerId }
    );
})
.WithName("CreateOrder")
.WithSummary("Creates an order using shared model validation");

// --- PUT Update Order: Uses the EXACT SAME validation model ---
app.MapPut("/api/orders/{orderId:int}", async Task<Results<Ok<OrderDto>, ValidationProblem, NotFound>> (
    int orderId,
    OrderUpsertModel model,
    IDapperOrderRepository repository,
    CancellationToken ct) =>
{
    var validationErrors = new Dictionary<string, string[]>();
    await foreach (var validationResult in model.ValidateAsync(new ValidationContext(model), ct))
    {
        foreach (var memberName in validationResult.MemberNames)
        {
            validationErrors[memberName] = [validationResult.ErrorMessage ?? "Validation error"];
        }
    }

    if (validationErrors.Count > 0)
    {
        return TypedResults.ValidationProblem(validationErrors);
    }

    var updated = await repository.UpdateOrderAsync(orderId, model, ct);
    return updated != null ? TypedResults.Ok(updated) : TypedResults.NotFound();
})
.WithName("UpdateOrder")
.WithSummary("Updates an order reusing the same model validation logic");

// Redirect root to Scalar docs
app.MapGet("/", () => Results.Redirect("/scalar/v1")).ExcludeFromDescription();

app.Run();

// ============================================================================
// Strongly-Typed Options (ValidateOnStart)
// ============================================================================
public class OrderProcessingOptions
{
    [Range(1, 500, ErrorMessage = "BatchSizeLimit must be between 1 and 500.")]
    public int BatchSizeLimit { get; set; } = 100;

    [Required(ErrorMessage = "RegionEndpoint is mandatory for deployment routing.")]
    public string RegionEndpoint { get; set; } = "default";
}

// ============================================================================
// Model with [.NET 11] IAsyncValidatableObject
// Shared between INSERT (POST) and UPDATE (PUT)
// ============================================================================
public class OrderUpsertModel : IAsyncValidatableObject
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "CustomerId must be positive.")]
    public int CustomerId { get; set; }

    [Required, MinLength(2, ErrorMessage = "SKU must be at least 2 characters.")]
    public string Sku { get; set; } = string.Empty;

    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000.")]
    public int Quantity { get; set; }

    [Range(0.01, 100000.0, ErrorMessage = "UnitPrice must be greater than zero.")]
    public decimal UnitPrice { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => [];

    // [.NET 11] Asynchronous Validation:
    // Performs database check without blocking thread-pool threads
    public async IAsyncEnumerable<ValidationResult> ValidateAsync(
        ValidationContext validationContext,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Task.Delay(10, cancellationToken); // Simulated async DB check

        if (CustomerId == 404)
        {
            yield return new ValidationResult(
                $"Customer ID {CustomerId} does not exist in the database.",
                [nameof(CustomerId)]
            );
        }

        if (Sku.StartsWith("DISCONTINUED-", StringComparison.OrdinalIgnoreCase))
        {
            yield return new ValidationResult(
                $"Product SKU '{Sku}' is discontinued and cannot be ordered.",
                [nameof(Sku)]
            );
        }
    }
}

public record OrderDto(int Id, int CustomerId, string Sku, int Quantity, decimal TotalAmount, string Status);

// ============================================================================
// Dapper Repository Contract & Mock Implementation
// ============================================================================
public interface IDapperOrderRepository
{
    Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId, CancellationToken ct = default);
    Task<OrderDto> CreateOrderAsync(OrderUpsertModel model, CancellationToken ct = default);
    Task<OrderDto?> UpdateOrderAsync(int orderId, OrderUpsertModel model, CancellationToken ct = default);
}

public class MockDapperOrderRepository : IDapperOrderRepository
{
    private static readonly List<OrderDto> _orders =
    [
        new(101, 1, "WIDGET-A", 5, 50.00m, "Completed"),
        new(102, 1, "GADGET-B", 2, 50.00m, "Shipped"),
        new(103, 2, "TOOL-C",   1, 150.00m, "Processing")
    ];

    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId, CancellationToken ct = default)
    {
        await Task.Delay(15, ct); // Simulated SQL/Oracle stored proc call
        return _orders.Where(o => o.CustomerId == customerId).ToList();
    }

    public async Task<OrderDto> CreateOrderAsync(OrderUpsertModel model, CancellationToken ct = default)
    {
        await Task.Delay(20, ct);
        var order = new OrderDto(
            Id: _orders.Count + 101,
            CustomerId: model.CustomerId,
            Sku: model.Sku,
            Quantity: model.Quantity,
            TotalAmount: model.Quantity * model.UnitPrice,
            Status: "Created"
        );
        _orders.Add(order);
        return order;
    }

    public async Task<OrderDto?> UpdateOrderAsync(int orderId, OrderUpsertModel model, CancellationToken ct = default)
    {
        await Task.Delay(15, ct);
        var existing = _orders.FirstOrDefault(o => o.Id == orderId);
        if (existing == null) return null;

        var updated = existing with
        {
            Sku = model.Sku,
            Quantity = model.Quantity,
            TotalAmount = model.Quantity * model.UnitPrice
        };
        _orders.Remove(existing);
        _orders.Add(updated);
        return updated;
    }
}
