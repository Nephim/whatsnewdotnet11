using System;
using System.Collections.Generic;

// ============================================================================
// Demo 04: Collection Expressions & params ReadOnlySpan<T> (C# 12 & 13)
// ============================================================================
// 1. [.. list] spread operator replaces Concat(), AddRange(), and new List<T>()
// 2. params ReadOnlySpan<T> avoids hidden heap array allocations on method calls

Console.WriteLine("--- Collection Expressions & ReadOnlySpan ---");

// 1. Combining collections with spread operator [..]
int[] defaultCategories = [10, 20, 30];
int[] seasonalCategories = [50, 60];

int[] allCategories = [.. defaultCategories, 99, .. seasonalCategories];
Console.WriteLine($"Combined categories: [{string.Join(", ", allCategories)}]");

// 2. params ReadOnlySpan<T>: stack-allocated argument passing
PrintTags("Audit", "Urgent", "Dispatched");

static void PrintTags(params ReadOnlySpan<string> tags)
{
    Console.Write("Active tags: ");
    for (int i = 0; i < tags.Length; i++)
    {
        Console.Write($"[{tags[i]}] ");
    }
    Console.WriteLine();
}
