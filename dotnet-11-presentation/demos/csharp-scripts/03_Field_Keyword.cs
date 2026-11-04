using System;

// ============================================================================
// Demo 03: The `field` Keyword (C# 14 / .NET 10)
// ============================================================================
// Allows adding logic (trimming, validation) directly in auto-properties
// without needing manual private backing fields like `_sku`.

Console.WriteLine("--- C# 14: Semi-Auto Properties with `field` ---");

var product = new Product
{
    Sku = "   widget-a100   ",
    Price = -25.00m // Negative gets clamped to 0
};

Console.WriteLine($"Sanitized SKU: '{product.Sku}' (trimmed & upper-cased)");
Console.WriteLine($"Guarded Price: {product.Price:C} (negative was normalized to 0)");

public class Product
{
    // `field` is a compiler-synthesized backing store inside the accessor
    public string Sku
    {
        get => field;
        set => field = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim().ToUpperInvariant();
    } = string.Empty;

    public decimal Price
    {
        get => field;
        set => field = value < 0 ? 0m : value;
    }
}
