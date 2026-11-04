#:property LangVersion=preview
using System;
using System.Collections.Generic;
using System.Linq;

// Demo 05: Modern LINQ Outer Joins — LeftJoin, Composite Keys & FullJoin (.NET 10 & 11)
// Run: dotnet run 05_Linq_Joins.cs

List<OrderItem> orders =
[
    new(OrderId: 101, TenantId: "DK", Sku: "WIDGET-A", Quantity: 5),
    new(OrderId: 102, TenantId: "DK", Sku: "GADGET-B", Quantity: 2),
    new(OrderId: 103, TenantId: "SE", Sku: "WIDGET-A", Quantity: 1),
    new(OrderId: 104, TenantId: "DK", Sku: "LEGACY-X", Quantity: 4) // Not in catalog
];

List<CatalogItem> catalog =
[
    new(TenantId: "DK", Sku: "WIDGET-A", Title: "Standard Widget (DK)"),
    new(TenantId: "DK", Sku: "GADGET-B", Title: "Smart Gadget (DK)"),
    new(TenantId: "SE", Sku: "WIDGET-A", Title: "Standard Widget (SE)"),
    new(TenantId: "DK", Sku: "SURPLUS-Z", Title: "Clearance Part (DK)") // No orders
];

// 1. Single-key LeftJoin (.NET 10)
Console.WriteLine("1. LeftJoin on a single property (Sku):");
var singleJoin = orders.Where(o => o.TenantId == "DK").LeftJoin(
    catalog.Where(c => c.TenantId == "DK"),
    order => order.Sku,
    prod  => prod.Sku,
    (order, prod) => new { order.OrderId, order.Sku, Title = prod?.Title ?? "[Missing from Catalog]" }
);

foreach (var row in singleJoin)
{
    Console.WriteLine($"   Order #{row.OrderId} | {row.Sku,-10} | {row.Title}");
}

// 2. Multi-condition LeftJoin (.NET 10) matching on composite keys (TenantId + Sku)
Console.WriteLine("\n2. LeftJoin on multiple properties (new { TenantId, Sku }):");
var compositeJoin = orders.LeftJoin(
    catalog,
    order => new { order.TenantId, order.Sku },
    prod  => new { prod.TenantId, prod.Sku },
    (order, prod) => new { order.OrderId, order.TenantId, order.Sku, Title = prod?.Title ?? "[Missing]" }
);

foreach (var row in compositeJoin)
{
    Console.WriteLine($"   Order #{row.OrderId} [{row.TenantId}] | {row.Sku,-10} | {row.Title}");
}

// 3. FullJoin: Reconciling both collections (orders without catalog + catalog without orders)
Console.WriteLine("\n3. FullJoin (both unmatched orders and unsold catalog items):");
var fullJoin = orders.Where(o => o.TenantId == "DK").FullJoin(
    catalog.Where(c => c.TenantId == "DK"),
    order => order.Sku,
    prod  => prod.Sku,
    (order, prod) => new
    {
        Sku = order?.Sku ?? prod!.Sku,
        Status = (order, prod) switch
        {
            (not null, not null) => $"Matched: Order #{order.OrderId} -> {prod.Title}",
            (not null, null)     => $"Orphan Order: Order #{order.OrderId} references unknown SKU",
            (null, not null)     => $"Unsold Catalog Item: '{prod.Title}' has 0 orders",
            _                    => ""
        }
    }
);

foreach (var row in fullJoin)
{
    Console.WriteLine($"   [{row.Sku,-10}] {row.Status}");
}

public sealed record OrderItem(int OrderId, string TenantId, string Sku, int Quantity);
public sealed record CatalogItem(string TenantId, string Sku, string Title);

public static class JoinExtensions
{
    public static IEnumerable<TResult> FullJoin<TLeft, TRight, TKey, TResult>(
        this IEnumerable<TLeft> left,
        IEnumerable<TRight> right,
        Func<TLeft, TKey> leftKeySelector,
        Func<TRight, TKey> rightKeySelector,
        Func<TLeft?, TRight?, TResult> resultSelector) where TKey : notnull
    {
        var rightLookup = right.ToLookup(rightKeySelector);
        var matchedKeys = new HashSet<TKey>();

        foreach (var l in left)
        {
            var key = leftKeySelector(l);
            var matches = rightLookup[key];
            if (matches.Any())
            {
                matchedKeys.Add(key);
                foreach (var r in matches)
                    yield return resultSelector(l, r);
            }
            else
            {
                yield return resultSelector(l, default);
            }
        }

        foreach (var group in rightLookup)
        {
            if (!matchedKeys.Contains(group.Key))
            {
                foreach (var r in group)
                    yield return resultSelector(default, r);
            }
        }
    }
}
