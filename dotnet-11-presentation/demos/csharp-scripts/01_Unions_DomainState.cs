#:property LangVersion=preview
using System;

// Demo 01: C# 15 Union Types — Domain State Modeling (.NET 11)
// Run: dotnet run 01_Unions_DomainState.cs

OrderState[] states =
[
    new Pending(OrderId: 101, CreatedAt: DateTime.UtcNow),
    new Paid(OrderId: 102, TransactionId: "TX-88412", Amount: 249.50m),
    new Shipped(OrderId: 103, Carrier: "DHL", TrackingNumber: "DHL-99201"),
    new Cancelled(OrderId: 104, Reason: "Customer requested cancellation")
];

foreach (var state in states)
{
    Console.WriteLine(FormatOrderStatus(state));
}

static string FormatOrderStatus(OrderState state) => state switch
{
    Pending p   => $"Order #{p.OrderId}: Pending since {p.CreatedAt:HH:mm}",
    Paid paid   => $"Order #{paid.OrderId}: Paid {paid.Amount:C} (Ref: {paid.TransactionId})",
    Shipped s   => $"Order #{s.OrderId}: Shipped via {s.Carrier} ({s.TrackingNumber})",
    Cancelled c => $"Order #{c.OrderId}: Cancelled ({c.Reason})"
    // Exhaustive: compiler verifies all union cases are handled without 'default'
};

public union OrderState(Pending, Paid, Shipped, Cancelled);

public sealed record Pending(int OrderId, DateTime CreatedAt);
public sealed record Paid(int OrderId, string TransactionId, decimal Amount);
public sealed record Shipped(int OrderId, string Carrier, string TrackingNumber);
public sealed record Cancelled(int OrderId, string Reason);
