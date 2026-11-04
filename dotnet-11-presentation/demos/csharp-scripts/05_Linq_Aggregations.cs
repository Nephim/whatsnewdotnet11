using System;
using System.Collections.Generic;
using System.Linq;

// ============================================================================
// Demo 05: Modern LINQ Aggregations (.NET 9)
// ============================================================================
// In-memory data shaping on rowsets returned by Dapper stored procedures:
// - CountBy: Fast frequency counting without GroupBy
// - AggregateBy: Accumulates running values per key (seed = initial accumulator value)
// - Index(): Returns (index, item) pairs without manual loop counters

Console.WriteLine("--- Modern LINQ Aggregations (.NET 9) ---");

var orders = new List<OrderLine>
{
    new(Id: 1, Customer: "Acme", Product: "Widget", Quantity: 5, Price: 10.00m),
    new(Id: 2, Customer: "Acme", Product: "Gadget", Quantity: 2, Price: 25.00m),
    new(Id: 3, Customer: "Globex", Product: "Widget", Quantity: 10, Price: 9.50m),
    new(Id: 4, Customer: "Initech", Product: "Tool", Quantity: 1, Price: 150.00m)
};

// 1. CountBy: Frequency count per key in a single efficient pass
Console.WriteLine("\n1. Count of order lines per customer (CountBy):");
foreach (var (customer, count) in orders.CountBy(o => o.Customer))
{
    Console.WriteLine($"   {customer,-10} : {count} line(s)");
}

// 2. AggregateBy: Running sum per key
// `seed: 0m` is the initial decimal starting value (0.00m) before accumulating
Console.WriteLine("\n2. Total revenue per customer (AggregateBy):");
var customerTotals = orders.AggregateBy(
    keySelector: o => o.Customer,
    seed: 0m, // Starting total for each customer
    func: (currentTotal, order) => currentTotal + (order.Quantity * order.Price)
);

foreach (var (customer, total) in customerTotals)
{
    Console.WriteLine($"   {customer,-10} : {total:C}");
}

// 3. Index(): Accessing zero-based index alongside each element
Console.WriteLine("\n3. Row numbering without manual 'int i = 0' counters (Index()):");
foreach (var (index, line) in orders.Index())
{
    Console.WriteLine($"   Line #{index + 1}: Order #{line.Id} ({line.Product} x {line.Quantity})");
}

public record OrderLine(int Id, string Customer, string Product, int Quantity, decimal Price);
