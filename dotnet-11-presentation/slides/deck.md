---
marp: true
theme: default
paginate: true
header: "What's new in .NET 11 | Modern .NET Features"
footer: 'Minimal APIs • Dapper • React / Vite'
style: |
  section {
    background-color: #ffffff;
    color: #1f2328;
    font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, Arial, sans-serif;
    padding: 36px 48px;
    font-size: 23px;
    text-align: left;
    justify-content: flex-start;
  }
  h1 {
    color: #0969da;
    font-size: 38px;
    margin-bottom: 10px;
    font-weight: 700;
  }
  h2 {
    color: #1f2328;
    font-size: 28px;
    margin-bottom: 14px;
    border-bottom: 2px solid #d0d7de;
    padding-bottom: 6px;
    font-weight: 600;
  }
  h3 {
    color: #0969da;
    font-size: 23px;
    margin-top: 8px;
    margin-bottom: 6px;
  }
  p, li {
    font-size: 20px;
    line-height: 1.45;
    color: #1f2328;
  }
  ul {
    margin-top: 6px;
    margin-bottom: 10px;
  }
  code {
    background-color: #eff1f3;
    color: #cf222e;
    padding: 2px 6px;
    border-radius: 4px;
    font-family: "JetBrains Mono", Consolas, monospace;
    font-size: 19px;
  }
  pre code {
    background-color: #f6f8fa;
    color: #1f2328;
    font-size: 16px;
    line-height: 1.35;
    border-radius: 6px;
    border: 1px solid #d0d7de;
    padding: 10px 12px;
  }
  .badge {
    display: inline-block;
    padding: 2px 8px;
    font-size: 13px;
    font-weight: 700;
    border-radius: 12px;
    text-transform: uppercase;
    vertical-align: middle;
    margin-left: 6px;
  }
  .net8  { background-color: #1a7f37; color: #ffffff; }
  .net9  { background-color: #0969da; color: #ffffff; }
  .net10 { background-color: #8250df; color: #ffffff; }
  .net11 { background-color: #cf222e; color: #ffffff; }
  .demo-badge { background-color: #bf8700; color: #ffffff; }
  .grid-2 {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 16px;
    margin-top: 8px;
  }
  .box-before {
    background-color: #fff8f8;
    border: 1px solid #ff8182;
    border-radius: 6px;
    padding: 10px;
  }
  .box-after {
    background-color: #f6fff8;
    border: 1px solid #4ac26b;
    border-radius: 6px;
    padding: 10px;
  }
  .box-before h4 { color: #cf222e; margin: 0 0 6px 0; font-size: 17px; }
  .box-after h4 { color: #1a7f37; margin: 0 0 6px 0; font-size: 17px; }
  .callout-box {
    background-color: #ddf4ff;
    border-left: 4px solid #0969da;
    padding: 8px 14px;
    margin-top: 10px;
    border-radius: 0 6px 6px 0;
  }
  .callout-box p { margin: 0; font-size: 19px; }
---

<!-- ===================================================================== -->
<!-- SLIDE 1: TITLE                                                        -->
<!-- ===================================================================== -->

# What's new in .NET 11
## Practical Modern .NET Features for Minimal APIs, Dapper & React

A down-to-earth overview of practical features across **.NET 8, 9, 10, and 11** (C# 12–15).

* **Focus Areas:**
  * Reducing boilerplate in everyday C# code
  * Working with in-memory data returned from Dapper stored procedures
  * Cleaner request validation and endpoints in Minimal APIs
  * Keeping API contracts in sync with React / Vite

<!--
SPEAKER NOTES:
- Welcome everyone.
- Keep tone grounded: we are focusing on features that make our day-to-day work simpler and reduce repetitive code.
- No EF Core, Blazor, or MAUI—everything is tailored to our stack: Minimal APIs, Dapper calling stored procedures, and React with Vite.
- Every feature has a version badge ([.NET 8], [.NET 9], [.NET 10], [.NET 11]) so you can see what is available today vs. with .NET 11.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 2: ROADMAP                                                      -->
<!-- ===================================================================== -->

# Roadmap
## 5 Focused Topics

1. **Tooling & Setup:** The .NET 11 SDK, `.slnx` files, and single-file C# scripts
2. **C# 15 & Language Features:** Union types, the `field` keyword, and collection expressions
3. **Working with Data & Libraries:** LINQ aggregations, in-memory outer joins, and `HybridCache`
4. **ASP.NET Core & Minimal APIs:** Shared model validation, OpenAPI 3.2, and frontend client generation
5. **Runtime Under the Hood:** Native Runtime Async in .NET 11 and everyday takeaways

<div class="callout-box">
<p>💡 Small, focused live demos are embedded directly alongside each topic.</p>
</div>

<!--
SPEAKER NOTES:
- Give a brief overview of the topics.
- We will look at practical syntax first, then data and APIs, and finally a quick look at the runtime changes.
- Demos will be shown directly as each topic is discussed.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 3: LIFECYCLE & SUPPORT                                          -->
<!-- ===================================================================== -->

# Lifecycle & Release Cadence <span class="badge net10">.NET 10 LTS</span> <span class="badge net11">.NET 11 STS</span>
## Why .NET 11 Makes Sense for Modern Adoption

* **Microsoft's Updated Support Policy:**
  * Starting with .NET 9, Microsoft extended Standard Term Support (STS) releases to **2 full years** of support.
  * All major releases now target **November**.
* **Support Alignment:**
  * **.NET 10 (LTS):** Supported until **November 2028** (3 years).
  * **.NET 11 (STS):** Supported until **November 2028** (2 years).
* **The Result:**
  * Both .NET 10 and .NET 11 reach end of support at the **exact same time** (November 2028).
  * Adopting .NET 11 gives us the newest language features (like C# 15 Unions and Runtime Async) without cutting our support window short.

<!--
SPEAKER NOTES:
- Explain why Microsoft's policy change is relevant: previously STS releases only had 18 months of support, which made teams hesitant.
- Now STS is 2 years, aligning .NET 11's end-of-support to November 2028—the same month as .NET 10 LTS.
- This gives us a comfortable runway to use .NET 11 features.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 4: SINGLE-FILE C# APPS                                          -->
<!-- ===================================================================== -->

# Single-File C# Apps <span class="badge net10">.NET 10</span> <span class="badge net11">.NET 11</span>
## Running Standalone Scripts: `dotnet run script.cs`

Run any standalone `.cs` file directly from the terminal without creating a `.csproj` or project folder:

```bash
# Execute a single C# file directly:
dotnet run FixCustomerData.cs

# Pass preview language flags when testing new language features:
dotnet run 01_Unions_Basics.cs -p:LangVersion=preview
```

* **Where this is useful:**
  * Quick database maintenance scripts and data migration utilities
  * Standalone test harnesses to verify a Dapper query or stored procedure
  * Testing new C# features and language spikes without polluting the repository with project files

<!--
SPEAKER NOTES:
- Introduced in .NET 10 and refined in .NET 11.
- No need to run `dotnet new console`, maintain a `.csproj` file, or clean up `bin/` and `obj/` folders for quick one-off tasks.
- Perfect for developer utility scripts and test harnesses.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 5: MODERN SOLUTION FILES & VISUAL STUDIO                        -->
<!-- ===================================================================== -->

# Project Tooling: `.slnx` & Hot Reload <span class="badge net9">.NET 9</span> <span class="badge net10">.NET 10</span>
## Simpler Solutions and Smoother Visual Studio Iteration

* **`.slnx` Solution Format:**
  * Replaces legacy `.sln` files (which had obscure GUIDs and frequent git merge conflicts) with clean, readable XML:
```xml
<Solution>
  <Folder Name="/Demos/">
    <File Path="requests.http" />
  </Folder>
  <Project Path="MinimalApiDemo/MinimalApiDemo.csproj" />
</Solution>
```
* **Visual Studio Hot Reload Improvements:**
  * Hot Reload now supports modifying lambda expressions, adding methods, and editing Minimal API route handlers without having to stop and restart the debugging session.

<!--
SPEAKER NOTES:
- `.slnx` is natively supported in Visual Studio 2022 (v17.10+) and .NET CLI.
- No more painful git merge conflicts in `.sln` files when two developers add projects simultaneously.
- Hot reload makes tweaking Minimal API routes in Visual Studio much faster.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 6: C# 15 UNIONS - OVERVIEW                                      -->
<!-- ===================================================================== -->

# C# 15 Union Types <span class="badge net11">.NET 11 / C# 15</span>
## Modeling Closed Sets of Types Natively

A `union` defines a closed set of permitted types. Unlike open inheritance, the compiler knows every possible case at build time:

```csharp
// Define an order's lifecycle states as a closed union
public union OrderState(Pending, Shipped, Delivered, Cancelled);

public record Pending(int OrderId, DateTime CreatedAt);
public record Shipped(int OrderId, string TrackingNumber);
public record Delivered(int OrderId, DateTime DeliveredAt);
public record Cancelled(int OrderId, string Reason);
```

* **Exhaustive Pattern Matching:**
  * In a `switch` expression, the compiler verifies that **all cases are handled**.
  * No `default:` arm is required. If someone adds a 5th state in the future, the compiler will flag any unhandled `switch` expressions with an error.

<!--
SPEAKER NOTES:
- Introduce unions conceptually: they are closed sum types (discriminated unions).
- It's not just for return types—it's great for domain state machines, event types, and workflow steps.
- Because the set of types is closed, the compiler enforces exhaustiveness on pattern matching.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 7: C# 15 UNIONS - RESULT PATTERN                                -->
<!-- ===================================================================== -->

# C# 15 Unions: Explicit Results <span class="badge net11">C# 15</span>
## Handling Expected Outcomes Without Throwing Exceptions

<div class="grid-2">
<div class="box-before">
<h4>Before (Exceptions for Flow Control)</h4>

```csharp
public OrderDto GetOrder(int id) {
  var row = repo.QuerySingleOrDefault(id);
  if (row == null) 
    throw new NotFoundException($"Order {id}");
  return row;
}

// Caller:
try {
  return Results.Ok(repo.GetOrder(id));
} catch (NotFoundException ex) {
  return Results.NotFound(ex.Message);
}
```
</div>

<div class="box-after">
<h4>With C# 15 Unions (Explicit Return)</h4>

```csharp
public union OrderResult(Success, NotFound, ValidationError);

public OrderResult GetOrder(int id) {
  if (id <= 0) 
    return new ValidationError("id", "Invalid");
  var row = repo.QuerySingleOrDefault(id);
  return row != null 
    ? new Success(row) 
    : new NotFound(id);
}

// Caller: Compiler verifies all cases!
return repo.GetOrder(id) switch {
  Success s         => TypedResults.Ok(s.Order),
  NotFound nf       => TypedResults.NotFound(),
  ValidationError v => TypedResults.BadRequest(v)
};
```
</div>
</div>

<div class="callout-box">
<p>💻 <strong>Demo:</strong> <code>01_Unions_Basics.cs</code> (Domain states) & <code>02_Unions_Results.cs</code> (Result pattern)</p>
</div>

<!--
SPEAKER NOTES:
- Show the contrast: "Not found" or "Validation failed" are regular business outcomes, not catastrophic exceptions.
- Exceptions incur stack-trace unwinding overhead and hide return branches from the method signature.
- [SWITCH TO DEMO]:
  Run: `dotnet run dotnet-11-presentation/demos/csharp-scripts/01_Unions_Basics.cs -p:LangVersion=preview`
  Run: `dotnet run dotnet-11-presentation/demos/csharp-scripts/02_Unions_Results.cs -p:LangVersion=preview`
- Show how clean the code is and how the switch handles each case.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 8: THE FIELD KEYWORD                                            -->
<!-- ===================================================================== -->

# The `field` Keyword <span class="badge net10">.NET 10 / C# 14</span>
## Semi-Auto Properties Without Manual Backing Fields

<div class="grid-2">
<div class="box-before">
<h4>Before C# 14 (Manual Backing Field)</h4>

```csharp
public class Product
{
    private string _sku = string.Empty;

    public string Sku
    {
        get => _sku;
        set => _sku = value?.Trim()
                           .ToUpperInvariant() 
                      ?? string.Empty;
    }
}
```
</div>

<div class="box-after">
<h4>With C# 14 `field` Keyword</h4>

```csharp
public class Product
{
    public string Sku
    {
        get => field;
        set => field = value?.Trim()
                            .ToUpperInvariant() 
                       ?? string.Empty;
    } = string.Empty;
}
```
</div>
</div>

* `field` provides a compiler-synthesized backing store inside the accessor body.
* Eliminates the need to declare extra private fields just to trim whitespace, clamp values, or perform basic property validation.

<div class="callout-box">
<p>💻 <strong>Demo:</strong> <code>03_Field_Keyword.cs</code></p>
</div>

<!--
SPEAKER NOTES:
- A very practical quality-of-life improvement.
- Previously, adding a single `.Trim()` or check forced you to convert an auto-property into 6 lines of code with a separate backing field.
- [SWITCH TO DEMO]:
  Run: `dotnet run dotnet-11-presentation/demos/csharp-scripts/03_Field_Keyword.cs -p:LangVersion=preview`
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 9: COLLECTION EXPRESSIONS                                       -->
<!-- ===================================================================== -->

# Collection Expressions & Spans <span class="badge net8">.NET 8</span> <span class="badge net9">.NET 9</span>
## Cleaner Syntax and Zero-Allocation Parameters

* **Collection Expressions `[.. list]` <span class="badge net8">C# 12</span>:**
  * Unified syntax for arrays, spans, and lists with the spread operator:
```csharp
int[] baseCategories = [10, 20, 30];
int[] seasonalCategories = [50, 60];

// Combines collections cleanly without Concat() or AddRange():
int[] allCategories = [.. baseCategories, 99, .. seasonalCategories];
```

* **`params ReadOnlySpan<T>` <span class="badge net9">C# 13</span>:**
  * In earlier C# versions, calling a method with `params` always allocated a heap array.
  * With `params ReadOnlySpan<T>`, arguments are passed directly on the stack with zero heap allocations:
```csharp
public void LogTags(params ReadOnlySpan<string> tags) { /* Stack allocated */ }
```

<div class="callout-box">
<p>💻 <strong>Demo:</strong> <code>04_Collection_Expressions.cs</code></p>
</div>

<!--
SPEAKER NOTES:
- Collection expressions replace ugly `new List<int>()` and `new[] { ... }`.
- Spread operator `[..]` makes merging lists simple and readable.
- `params ReadOnlySpan<T>` is a nice bonus: calling a method with variable arguments no longer creates a hidden heap array.
- [SWITCH TO DEMO]:
  Run: `dotnet run dotnet-11-presentation/demos/csharp-scripts/04_Collection_Expressions.cs -p:LangVersion=preview`
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 10: ARCHITECTURE NOTE: PRIMARY CONSTRUCTORS                     -->
<!-- ===================================================================== -->

# Architecture Guideline: Primary Constructors
## ⚠️ Why We Avoid Primary Constructors in DI Service Classes

```csharp
// ❌ Avoid in Service Classes with Dependency Injection:
public class OrderService(IDapperRepository repository, ILogger<OrderService> logger)
{
    public async Task ProcessOrder()
    {
        // 'repository' is NOT readonly! It can be reassigned inside any method.
        // It acts as a mutable captured variable across the class.
    }
}
```

* **The Problem:**
  * Primary constructors are great for immutable records (`public record OrderDto(...)`).
  * In service classes, captured constructor parameters **cannot be marked `readonly`**.
* **Our Team Standard:**
  * Use explicit `private readonly IDapperRepository _repo;` in DI services.
  * This guarantees immutability and makes dependency storage clear.

<!--
SPEAKER NOTES:
- It's tempting to use primary constructors everywhere because they save a few lines of code.
- But in DI services, captured parameters remain mutable in class scope and cannot be marked readonly.
- For services, stick to explicit private readonly fields. For DTOs and records, primary constructors are great.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 11: LINQ AGGREGATIONS                                           -->
<!-- ===================================================================== -->

# LINQ Aggregations <span class="badge net9">.NET 9</span>
## Faster Frequency Counting & Running Totals

* **`CountBy`:** Counts occurrences per key in a single streaming pass (replaces `.GroupBy()`):
```csharp
// Returns key-value pairs of customer and count:
var orderCounts = orders.CountBy(o => o.Customer);
```

* **`AggregateBy`:** Computes running totals per key:
```csharp
// `seed: 0m` is the starting decimal accumulator value:
var totals = orders.AggregateBy(
    keySelector: o => o.Customer,
    seed: 0m,
    func: (currentTotal, o) => currentTotal + (o.Quantity * o.Price)
);
```

* **`Index()`:** Retrieves the zero-based index alongside each item without maintaining an extra `int i = 0; i++` counter:
```csharp
foreach (var (index, item) in orders.Index()) {
    Console.WriteLine($"Line #{index + 1}: {item.Product}");
}
```

<div class="callout-box">
<p>💻 <strong>Demo:</strong> <code>05_Linq_Aggregations.cs</code></p>
</div>

<!--
SPEAKER NOTES:
- Explain why CountBy is great: previously you had to do `.GroupBy(x => x.Customer).ToDictionary(g => g.Key, g => g.Count())`, which allocated intermediate group objects.
- AggregateBy does running accumulation per key. Clarify that `seed: 0m` is simply the starting decimal amount (0.00).
- Index() is a nice helper when you need the index of an element alongside the element itself.
- [SWITCH TO DEMO]:
  Run: `dotnet run dotnet-11-presentation/demos/csharp-scripts/05_Linq_Aggregations.cs -p:LangVersion=preview`
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 12: LINQ OUTER JOINS                                            -->
<!-- ===================================================================== -->

# In-Memory Outer Joins: `LeftJoin` <span class="badge net10">.NET 10</span>
## Joining In-Memory Datasets After Dapper Queries

Joins two collections in memory. If an item on the right side is missing, it evaluates to `null`:

```csharp
// 1. Single-property join (matching on Sku):
var enriched = orders.LeftJoin(
    catalog,
    order => order.Sku,
    prod  => prod.Sku,
    (order, prod) => new { order.OrderId, Title = prod?.Title ?? "Uncataloged" }
);

// 2. Composite key join (matching on TenantId AND Sku using an anonymous object):
var multiJoined = orders.LeftJoin(
    catalog,
    order => new { order.TenantId, order.Sku },
    prod  => new { prod.TenantId, prod.Sku },
    (order, prod) => new { order.OrderId, Title = prod?.Title ?? "Unassigned" }
);
```

* **What it can & cannot do:**
  * **CAN:** Join on single keys or composite keys (`new { ... }`) using equality.
  * **CANNOT:** Perform non-equality joins (e.g. date ranges). For non-equality conditions, use SQL or `.Where()`.

<div class="callout-box">
<p>💻 <strong>Demo:</strong> <code>06_Linq_LeftJoin.cs</code></p>
</div>

<!--
SPEAKER NOTES:
- Pre-.NET 10, left joins required `GroupJoin` + `SelectMany` + `DefaultIfEmpty()`.
- Now `LeftJoin` is a first-class method on IEnumerable<T>.
- Address the review question: Can it join on multiple properties? Yes! You match on an anonymous object or tuple `new { order.TenantId, order.Sku }`.
- [SWITCH TO DEMO]:
  Run: `dotnet run dotnet-11-presentation/demos/csharp-scripts/06_Linq_LeftJoin.cs -p:LangVersion=preview`
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 13: HYBRIDCACHE                                                 -->
<!-- ===================================================================== -->

# Caching Stored Proc Results: `HybridCache` <span class="badge net9">.NET 9</span> <span class="badge net11">.NET 11</span>
## Two-Tier Caching & Stampede Protection

`HybridCache` combines fast in-memory RAM (L1) with an external database/store (e.g. SQL / Oracle DB):

```csharp
// 1. Checks fast RAM; 2. Checks DB store; 3. Executes factory with locking:
var orders = await hybridCache.GetOrCreateAsync(
    $"customer-orders-{customerId}",
    async cancel => await dapperRepo.GetOrdersByCustomerIdAsync(customerId, cancel),
    tags: [$"customer-{customerId}"], // Tags are completely OPTIONAL
    cancellationToken: ct
);
```

* **Solving the "Cache Stampede":**
  * If 50 concurrent requests ask for the same customer when the cache expires, **only 1 request queries the database**. The other 49 wait and share the result.
* **Optional Tag Eviction:**
  * When updating an order, you can invalidate all cached items for that customer at once:
```csharp
await hybridCache.RemoveByTagAsync([$"customer-{customerId}"], ct);
```

<!--
SPEAKER NOTES:
- Explain the real problem: cache stampede / thundering herd. With IMemoryCache, when a key expires under load, 50 requests all hit SQL/Oracle DB at the same time.
- HybridCache provides atomic locking so only one query runs.
- Emphasize that `tags` are completely optional—you only use them if you want tag-based invalidation.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 14: SYSTEM.TEXT.JSON & SOURCE GENERATION                        -->
<!-- ===================================================================== -->

# System.Text.Json: Source Generation <span class="badge net8">.NET 8</span> <span class="badge net11">.NET 11</span>
## Compile-Time Serialization vs. Runtime Reflection

By default, serializers use runtime reflection (`System.Reflection`) to inspect property types on every request. **JSON Source Generation** shifts this work to compile time:

```csharp
// Generates serialization code during build:
[JsonSerializable(typeof(OrderDto))]
[JsonSerializable(typeof(List<OrderDto>))]
public partial class AppJsonContext : JsonSerializerContext { }
```

* **Why Source Generation Helps:**
  * **Build-Time Verification:** Catches unsupported types or serialization issues during compilation rather than failing in production.
  * **Faster Cold Starts:** Eliminates reflection inspection when an API container spins up.
  * **Trim & NativeAOT Safe:** Guarantees that the code can be trimmed without breaking serialization.

<!--
SPEAKER NOTES:
- Clarify what JSON source generation actually is: Roslyn generates the serializer code at compile time.
- Reflection is fine for small scripts, but in production APIs source generation guarantees that serialization logic is verified at compile time.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 15: BONUS - OPENAPI CLIENT & MODEL GENERATION                   -->
<!-- ===================================================================== -->

# API Contract Automation <span class="badge net9">.NET 9</span> <span class="badge net11">.NET 11</span>
## Generating TypeScript & C# Models from OpenAPI

Instead of manually duplicating C# models into TypeScript interfaces in React/Vite, let the OpenAPI document drive generation:

* **In React / Vite (TypeScript):**
  * Tools like `openapi-typescript` and `openapi-fetch` read `/openapi/v1.json` directly and generate exact TypeScript types:
```bash
# In your Vite project:
npx openapi-typescript http://localhost:5248/openapi/v1.json -o src/api/schema.d.ts
```
  * In React components, API responses are **100% type-safe**. If a C# property name changes, TypeScript fails at build time!

* **In .NET (Client Services):**
  * Tools like Microsoft Kiota or Refit generate typed HTTP client methods directly from the OpenAPI spec:
```bash
kiota generate --openapi http://localhost:5248/openapi/v1.json --language CSharp
```

<!--
SPEAKER NOTES:
- Emphasize the practical win: no more hand-writing and updating TypeScript interfaces in React!
- When backend changes a model in Minimal APIs, running `openapi-typescript` immediately flags any frontend breaking changes.
- Eliminates manual sync headaches between backend and frontend teams.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 16: SHARED MODEL VALIDATION                                     -->
<!-- ===================================================================== -->

# Model-Level Validation <span class="badge net10">.NET 10</span> <span class="badge net11">.NET 11</span>
## Why Validation Belongs on the Model

Putting validation rules on the request model ensures they apply consistently across **INSERT (POST)** and **UPDATE (PUT)**, as well as programmatic assignments:

```csharp
public class OrderUpsertModel : IAsyncValidatableObject
{
    [Required, Range(1, int.MaxValue)]
    public int CustomerId { get; set; }

    [Required, MinLength(2)]
    public string Sku { get; set; } = string.Empty;

    // [.NET 11] Asynchronous validation: checks DB existence without blocking threads!
    public async IAsyncEnumerable<ValidationResult> ValidateAsync(
        ValidationContext context, 
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.Delay(10, ct); // Simulated async DB check: SELECT 1 FROM Customers...
        if (CustomerId == 404)
            yield return new ValidationResult($"Customer {CustomerId} does not exist.", [nameof(CustomerId)]);
    }
}
```

<!--
SPEAKER NOTES:
- Highlight the design benefit: putting validation rules on the model means you write the validation once.
- Both POST /api/orders and PUT /api/orders/{id} reuse the exact same validation rules without duplicating logic.
- .NET 11 `IAsyncValidatableObject` allows async database checks without thread-pool starvation.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 17: MINIMAL APIS - TYPEDRESULTS & OPENAPI                       -->
<!-- ===================================================================== -->

# Minimal APIs: TypedResults & OpenAPI 3.2 <span class="badge net9">.NET 9</span> <span class="badge net11">.NET 11</span>
## Strongly-Typed Status Responses & Scalar UI

```csharp
app.MapGet("/api/customers/{id:int}/orders", 
    async Task<Results<Ok<IEnumerable<OrderDto>>, NotFound<string>>> (int id, ...) =>
{
    var orders = await repo.GetOrdersByCustomerIdAsync(id);
    return orders.Any() 
        ? TypedResults.Ok(orders) 
        : TypedResults.NotFound($"Customer {id} has no orders.");
});
```

* **Why `TypedResults` Matters:**
  * Replaces untyped `Results.Ok(...)` with generic type metadata.
  * Built-in .NET OpenAPI generates exact schemas for `200` and `404` status codes automatically.
* **Built-in OpenAPI (Dropping Swashbuckle):**
  * `Microsoft.AspNetCore.OpenApi` natively generates the OpenAPI 3.2 document.
  * Paired with **Scalar** (`app.MapScalarApiReference()`) for clean API documentation.

<div class="callout-box">
<p>💻 <strong>Demo:</strong> <code>demos/MinimalApiDemo/</code> + <code>requests.http</code></p>
</div>

<!--
SPEAKER NOTES:
- TypedResults makes endpoints self-documenting.
- No need to maintain manual [ProducesResponseType] attributes.
- Swashbuckle was abandoned; Microsoft now maintains official OpenAPI tooling.
- [SWITCH TO DEMO]:
  Run: `dotnet run --project dotnet-11-presentation/demos/MinimalApiDemo/MinimalApiDemo.csproj --urls http://localhost:5248`
  Open `http://localhost:5248/scalar/v1` and execute requests from `requests.http`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 18: RUNTIME ASYNC                                               -->
<!-- ===================================================================== -->

# Runtime Async <span class="badge net11">.NET 11 Architecture</span>
## How CoreCLR Natively Manages `async` Methods

<div class="grid-2">
<div class="box-before">
<h4>Before .NET 11 (Compiler State Machine)</h4>

* The Roslyn compiler rewrote `async` methods into a hidden `struct` or `class` implementing `IAsyncStateMachine`.
* Local variables were hoisted into fields.
* Convoluted stack traces during debugging:
  `at OrderService.<GetOrdersAsync>d__1.MoveNext()`
</div>

<div class="box-after">
<h4>.NET 11 (Native CoreCLR Async)</h4>

* The **runtime itself natively manages execution suspension and resumption**.
* Eliminates the compiler-generated state machine dispatch overhead.
* **Fewer allocations** on every `await connection.QueryAsync()` call.
* **Clean stack traces:** Points directly to your actual method and line number in error logs!
</div>
</div>

<!--
SPEAKER NOTES:
- Since C# 5 (2012), async was a compiler transformation. The compiler created a state machine class with MoveNext().
- In .NET 11, CoreCLR natively suspends and resumes managed frames.
- This means fewer allocations on high-frequency Dapper calls, and clean stack traces in Datadog or Application Insights without cryptic `<Method>d__1.MoveNext()` lines.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 19: SUMMARY & PRACTICAL TAKEAWAYS                               -->
<!-- ===================================================================== -->

# Practical Takeaways
## Features We Can Start Using

* **Everyday Boilerplate Reductions:**
  * Use **collection expressions `[.. list]`** to clean up collection initialization.
  * Use the **`field` keyword** in C# 14 for simple sanitization/trimming without backing fields.
* **Working with Data After Dapper:**
  * Use **`CountBy`** and **`AggregateBy`** instead of heavy `.GroupBy()` calls.
  * Use **`LeftJoin`** when combining two in-memory stored procedure rowsets.
  * Consider **`HybridCache`** for hot queries to eliminate cache stampedes against the database.
* **API & Frontend Automation:**
  * Put validation on models so rules are shared between `POST` and `PUT`.
  * Return **`TypedResults`** so OpenAPI generates accurate schemas.
  * Use OpenAPI code generators in React/Vite to stop manually writing TypeScript DTOs.
* **Moving Forward with .NET 11:**
  * C# 15 Unions provide clean domain state machines and explicit result types without exceptions.

<!--
SPEAKER NOTES:
- Summarize the main takeaways.
- Emphasize that many of these features can be adopted right now in existing code to make it cleaner and more readable.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 20: QUESTIONS & DEMO PLAYGROUND                                 -->
<!-- ===================================================================== -->

# Questions & Discussion

### Running the Demos Locally:
```bash
# 1. C# Single-File Scripts:
dotnet run dotnet-11-presentation/demos/csharp-scripts/01_Unions_Basics.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/02_Unions_Results.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/03_Field_Keyword.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/04_Collection_Expressions.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/05_Linq_Aggregations.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/06_Linq_LeftJoin.cs -p:LangVersion=preview

# 2. Minimal API Project:
dotnet run --project dotnet-11-presentation/demos/MinimalApiDemo/MinimalApiDemo.csproj --urls http://localhost:5248
```

* Presentation Guide & Study Notes: [`PRESENTER_GUIDE.md`](file:///C:/dev/antigravity/whatsnewdotnet11/dotnet-11-presentation/PRESENTER_GUIDE.md)

<!--
SPEAKER NOTES:
- Open the floor for team questions.
- Thank everyone for attending.
-->
