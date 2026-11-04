using System;

// ============================================================================
// Demo 01: C# 15 Union Types - Domain State Machine
// ============================================================================
// Unions represent a closed set of possible types.
// Here we model an order's lifecycle states cleanly.

Console.WriteLine("--- C# 15 Unions: Order State Machine ---");

OrderState s1 = new Pending(101, DateTime.UtcNow);
OrderState s2 = new Shipped(101, "DHL-987654");
OrderState s3 = new Cancelled(101, "Customer request");

PrintState(s1);
PrintState(s2);
PrintState(s3);

static void PrintState(OrderState state)
{
    // The compiler enforces exhaustiveness: all cases must be handled!
    string message = state switch
    {
        Pending p   => $"Order #{p.OrderId} is PENDING (created at {p.CreatedAt:t})",
        Shipped s   => $"Order #{s.OrderId} is SHIPPED (tracking: {s.TrackingNumber})",
        Delivered d => $"Order #{d.OrderId} was DELIVERED at {d.DeliveredAt:t}",
        Cancelled c => $"Order #{c.OrderId} was CANCELLED (reason: '{c.Reason}')"
    };

    Console.WriteLine(message);
}

// C# 15 union definition
public union OrderState(Pending, Shipped, Delivered, Cancelled);

public record Pending(int OrderId, DateTime CreatedAt);
public record Shipped(int OrderId, string TrackingNumber);
public record Delivered(int OrderId, DateTime DeliveredAt);
public record Cancelled(int OrderId, string Reason);
