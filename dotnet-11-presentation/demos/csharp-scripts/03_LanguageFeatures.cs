#:property LangVersion=preview
using System;
using System.Collections.Generic;

// Demo 03: Modern C# Language Features (field, Collection Expressions, ?.=)
// Run: dotnet run 03_LanguageFeatures.cs

// 1. The 'field' keyword (C# 14 / .NET 10)
var product = new Product
{
    Sku = "   widget-99x  ",
    UnitPrice = -15.00m // Clamped to 0
};
Console.WriteLine($"1. 'field' keyword -> Sku: '{product.Sku}', Price: {product.UnitPrice:C}");

// 2. Collection expressions & spread operator [..] (C# 12 / .NET 8)
int[] baseIds = [101, 102, 103];
int[] extraIds = [201, 202];
int[] allIds = [.. baseIds, 999, .. extraIds];
Console.WriteLine($"2. Spread [..]     -> [{string.Join(", ", allIds)}]");

// 3. Null-conditional assignment ?.= (C# 14 / .NET 10)
Product? nullProduct = null;
nullProduct?.Sku = "ignored"; // Safely skipped when null

Product? activeProduct = product;
activeProduct?.Sku = "  updated-sku  ";
Console.WriteLine($"3. Null-cond ?.=   -> Updated Sku: '{product.Sku}'");

public class Product
{
    public string Sku
    {
        get => field;
        set => field = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim().ToUpperInvariant();
    } = string.Empty;

    public decimal UnitPrice
    {
        get => field;
        set => field = value < 0m ? 0m : value;
    }
}
