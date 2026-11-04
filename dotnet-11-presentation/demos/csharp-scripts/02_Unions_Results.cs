#:property LangVersion=preview
using System;

// Demo 02: C# 15 Union Types — Explicit Repository Results (.NET 11)
// Run: dotnet run 02_Unions_Results.cs

var repository = new OrderRepository();

PrintOutcome(repository.GetOrder(101)); // Exists
PrintOutcome(repository.GetOrder(999)); // Missing
PrintOutcome(repository.GetOrder(-5));  // Invalid ID

static void PrintOutcome(OrderResult result)
{
    string line = result switch
    {
        Success s         => $"[200 OK] Order #{s.Order.Id} ({s.Order.Customer}) - {s.Order.Total:C}",
        NotFound nf       => $"[404 Not Found] Order #{nf.OrderId} does not exist",
        ValidationError v => $"[400 Bad Request] Invalid '{v.Field}': {v.Message}"
    };

    Console.WriteLine(line);
}

public union OrderResult(Success, NotFound, ValidationError);

public sealed record Success(OrderDto Order);
public sealed record NotFound(int OrderId);
public sealed record ValidationError(string Field, string Message);
public sealed record OrderDto(int Id, string Customer, decimal Total);

public class OrderRepository
{
    public OrderResult GetOrder(int orderId)
    {
        if (orderId <= 0)
            return new ValidationError(nameof(orderId), "Order ID must be greater than zero.");

        // Simulated Dapper stored procedure lookup:
        if (orderId == 101)
            return new Success(new OrderDto(101, "Acme Corp", 4520.50m));

        return new NotFound(orderId);
    }
}
