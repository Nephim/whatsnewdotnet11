using System;
using System.Collections.Generic;
using System.Linq;

// ============================================================================
// Demo 06: Modern LINQ LeftJoin (.NET 10)
// ============================================================================
// Joins two in-memory collections (such as two rowsets returned by Dapper).
// Unmatched items on the right side evaluate to null.

Console.WriteLine("--- Modern LINQ LeftJoin (.NET 10) ---");

// Dataset 1: Simulated Order Lines
var orders = new List<OrderItem>
{
    new(OrderId: 101, TenantId: "US", Sku: "WIDGET-A", Quantity: 5),
    new(OrderId: 102, TenantId: "US", Sku: "GADGET-B", Quantity: 2),
    new(OrderId: 103, TenantId: "EU", Sku: "WIDGET-A", Quantity: 1),
    new(OrderId: 104, TenantId: "US", Sku: "UNKNOWN-X", Quantity: 3) // Missing from catalog
};

// Dataset 2: Product Catalog
var catalog = new List<ProductCatalogItem>
{
    new(TenantId: "US", Sku: "WIDGET-A", Title: "Heavy Widget (US)", Price: 10.00m),
    new(TenantId: "US", Sku: "GADGET-B", Title: "Smart Gadget (US)", Price: 25.00m),
    new(TenantId: "EU", Sku: "WIDGET-A", Title: "Heavy Widget (EU)", Price: 12.00m)
};

// ----------------------------------------------------------------------------
// Scenario 1: Basic LeftJoin matching on a single property (Sku)
// ----------------------------------------------------------------------------
Console.WriteLine("\n1. Single-Property LeftJoin (matching on Sku):");
var singlePropertyJoin = orders.LeftJoin(
    catalog,
    order => order.Sku,
    prod => prod.Sku,
    (order, prod) => new
    {
        order.OrderId,
        order.Sku,
        Title = prod != null ? prod.Title : "[Uncataloged / Missing Product]"
    }
);

foreach (var row in singlePropertyJoin)
{
    Console.WriteLine($"   Order #{row.OrderId} | SKU: {row.Sku,-10} | Title: {row.Title}");
}

// ----------------------------------------------------------------------------
// Scenario 2: Multi-Property LeftJoin (matching on TenantId AND Sku)
// ----------------------------------------------------------------------------
// To join on multiple conditions in LINQ, match on an anonymous object or tuple!
Console.WriteLine("\n2. Composite-Key LeftJoin (matching on TenantId + Sku):");
var multiPropertyJoin = orders.LeftJoin(
    catalog,
    order => new { order.TenantId, order.Sku },
    prod => new { prod.TenantId, prod.Sku },
    (order, prod) => new
    {
        order.OrderId,
        Region = order.TenantId,
        order.Sku,
        ProductTitle = prod?.Title ?? "[No matching regional product]"
    }
);

foreach (var row in multiPropertyJoin)
{
    Console.WriteLine($"   Order #{row.OrderId} [{row.Region}] | SKU: {row.Sku,-10} | {row.ProductTitle}");
}

// ----------------------------------------------------------------------------
// What LeftJoin CAN and CANNOT do:
// CAN: Join on 1 key or N composite keys with equality comparison.
// CAN: Preserve all left rows, with right side evaluating to null when missing.
// CANNOT: Perform non-equality joins (e.g. SQL 'ON a.Date BETWEEN b.Start AND b.End').
//         For non-equality conditions, use the database query or in-memory .Where().
// ----------------------------------------------------------------------------

public record OrderItem(int OrderId, string TenantId, string Sku, int Quantity);
public record ProductCatalogItem(string TenantId, string Sku, string Title, decimal Price);
