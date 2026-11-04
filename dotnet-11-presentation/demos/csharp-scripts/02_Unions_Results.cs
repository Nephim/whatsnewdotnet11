using System;

// ============================================================================
// Demo 02: C# 15 Union Types - Returning Results Without Exceptions
// ============================================================================
// Stored procedures and repositories often return multiple expected outcomes:
// Found, Not Found, or Validation Error. Unions make these explicit.

Console.WriteLine("--- C# 15 Unions: Explicit Result Handling ---");

var repo = new OrderRepository();

Handle(repo.GetOrder(101)); // Exists
Handle(repo.GetOrder(999)); // Missing
Handle(repo.GetOrder(-5));  // Invalid input

static void Handle(OrderResult result)
{
    string output = result switch
    {
        Success s => $"[OK] Order #{s.Order.Id} for '{s.Order.Customer}', Amount: {s.Order.Amount:C}",
        NotFound nf => $"[404] Order #{nf.Id} was not found in the database",
        ValidationError err => $"[400] Validation failed on '{err.Field}': {err.Message}"
    };

    Console.WriteLine(output);
}

public union OrderResult(Success, NotFound, ValidationError);

public record Success(OrderDto Order);
public record NotFound(int Id);
public record ValidationError(string Field, string Message);

public record OrderDto(int Id, string Customer, decimal Amount);

public class OrderRepository
{
    public OrderResult GetOrder(int id)
    {
        if (id <= 0)
            return new ValidationError("id", "ID must be a positive integer.");

        // Simulate SQL stored procedure query:
        if (id == 101)
            return new Success(new OrderDto(101, "Acme Logistics", 420.00m));

        return new NotFound(id);
    }
}
