#:property LangVersion=preview
using System;
using System.Collections.Generic;
using System.Linq;

// Demo 04: Modern LINQ Aggregations — CountBy, AggregateBy & Index (.NET 9)
// Run: dotnet run 04_Linq_Aggregations.cs

List<OrderLine> orderLines =
[
    new(LineId: 10, Customer: "Acme Corp",  Sku: "WIDGET-A", Quantity: 5,  UnitPrice: 10.00m),
    new(LineId: 11, Customer: "Acme Corp",  Sku: "GADGET-B", Quantity: 2,  UnitPrice: 25.00m),
    new(LineId: 12, Customer: "Globex Inc", Sku: "WIDGET-A", Quantity: 10, UnitPrice: 9.50m),
    new(LineId: 13, Customer: "Initech",    Sku: "TOOL-C",   Quantity: 1,  UnitPrice: 150.00m)
];

// 1. CountBy (.NET 9): Count rows per key without GroupBy
Console.WriteLine("1. CountBy (order lines per customer):");
foreach (var (customer, count) in orderLines.CountBy(x => x.Customer))
{
    Console.WriteLine($"   {customer,-12} : {count} line(s)");
}

// 2. AggregateBy (.NET 9): Sum spend per customer
//    seed: 0m is the starting decimal value (0.00) for each customer's running total
Console.WriteLine("\n2. AggregateBy (total spend per customer):");
var spendByCustomer = orderLines.AggregateBy(
    keySelector: line => line.Customer,
    seed: 0m,
    func: (runningTotal, line) => runningTotal + (line.Quantity * line.UnitPrice)
);

foreach (var (customer, totalSpend) in spendByCustomer)
{
    Console.WriteLine($"   {customer,-12} : {totalSpend:C}");
}

// 3. Index() (.NET 9): Tuple (index, item) without a manual 'int i = 0' loop counter
Console.WriteLine("\n3. Index (element position alongside item):");
foreach (var (index, line) in orderLines.Index())
{
    Console.WriteLine($"   [{index}] Line #{line.LineId} ({line.Sku})");
}

public sealed record OrderLine(int LineId, string Customer, string Sku, int Quantity, decimal UnitPrice);
