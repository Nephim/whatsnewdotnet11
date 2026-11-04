---
marp: true
theme: default
paginate: true
header: "What's New in .NET 11 | Modern .NET & C# (8 – 11)"
footer: 'ASP.NET Core Minimal APIs • Dapper • React / Vite'
style: |
  section {
    background-color: #ffffff;
    color: #1f2328;
    font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, Arial, sans-serif;
    padding: 34px 46px 42px 46px;
    font-size: 21px;
    line-height: 1.4;
    text-align: left;
    justify-content: flex-start;
  }
  h1 {
    color: #0969da;
    font-size: 34px;
    margin: 0 0 6px 0;
    padding-bottom: 0;
    border-bottom: none;
    font-weight: 700;
  }
  h2 {
    color: #4d5562;
    font-size: 23px;
    margin: 0 0 14px 0;
    border-bottom: 2px solid #d0d7de;
    padding-bottom: 6px;
    font-weight: 600;
  }
  h3 {
    color: #0969da;
    font-size: 20px;
    margin: 8px 0 4px 0;
  }
  p, li {
    font-size: 19px;
    line-height: 1.42;
    color: #1f2328;
  }
  ul, ol {
    margin: 4px 0 8px 0;
    padding-left: 24px;
  }
  li + li {
    margin-top: 4px;
  }
  code {
    background-color: #eff1f3;
    color: #cf222e;
    padding: 2px 5px;
    border-radius: 4px;
    font-family: Consolas, "JetBrains Mono", ui-monospace, monospace;
    font-size: 88%;
  }
  pre, marp-pre {
    background-color: #f6f8fa !important;
    border: 1px solid #d0d7de !important;
    border-radius: 6px !important;
    padding: 10px 14px !important;
    margin: 6px 0 !important;
    font-size: 14.5px !important;
    line-height: 1.42 !important;
    overflow: hidden !important;
  }
  pre code, marp-pre code {
    background-color: transparent !important;
    color: #1f2328 !important;
    padding: 0 !important;
    margin: 0 !important;
    border: none !important;
    border-radius: 0 !important;
    font-size: inherit !important;
    line-height: inherit !important;
    white-space: pre !important;
  }
  .badge {
    display: inline-block;
    padding: 2px 8px;
    font-size: 12px;
    font-weight: 700;
    border-radius: 10px;
    text-transform: uppercase;
    vertical-align: middle;
    margin-left: 6px;
  }
  .net8  { background-color: #1a7f37; color: #ffffff; }
  .net9  { background-color: #0969da; color: #ffffff; }
  .net10 { background-color: #8250df; color: #ffffff; }
  .net11 { background-color: #cf222e; color: #ffffff; }
  .grid-2 {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 14px;
    margin-top: 6px;
  }
  .box-before {
    background-color: #fff8f8;
    border: 1px solid #ff8182;
    border-radius: 6px;
    padding: 8px 10px;
  }
  .box-after {
    background-color: #f6fff8;
    border: 1px solid #4ac26b;
    border-radius: 6px;
    padding: 8px 10px;
  }
  .box-before h4 { color: #cf222e; margin: 0 0 4px 0; font-size: 16px; }
  .box-after h4 { color: #1a7f37; margin: 0 0 4px 0; font-size: 16px; }
  .demo-bar {
    background-color: #ddf4ff;
    border-left: 4px solid #0969da;
    padding: 6px 12px;
    margin-top: 8px;
    border-radius: 0 6px 6px 0;
    font-size: 17px;
  }
  table {
    font-size: 16.5px;
    width: 100%;
    border-collapse: collapse;
    margin-top: 6px;
  }
  th, td {
    padding: 6px 10px !important;
    border: 1px solid #d0d7de !important;
  }
  th {
    background-color: #f6f8fa !important;
  }
---

<!-- ===================================================================== -->
<!-- SLIDE 1: TITLE SLIDE                                                  -->
<!-- ===================================================================== -->

# What's New in .NET 11
## Modern .NET & C# Features Across .NET 8, 9, 10 & 11

- **Target Tech Stack:**
  - **Backend:** ASP.NET Core Minimal APIs (with Options Pattern) + Dapper calling SQL Stored Procedures
  - **Frontend:** React + TypeScript built with Vite
- **Core Objectives:**
  - Reduce boilerplate in everyday C# models, repositories, and endpoints
  - Shape flat `IEnumerable<T>` results from Dapper stored procedures in memory
  - Automate API schema and client generation between Minimal APIs and React/Vite
  - Understand what arrived in `.NET 8`, `.NET 9`, `.NET 10`, and `.NET 11`

<!--
SPEAKER NOTES:
- Introduce the goal of the session: knowledge sharing across the features added from .NET 8 through .NET 11 (C# 12 to C# 15).
- Everything in this deck is filtered specifically for our stack: Minimal APIs, Dapper + stored procedures, and React/Vite. (No EF Core, Blazor, or MAUI).
- Each slide is badged with the .NET version where the feature was introduced so we know what can be used immediately in existing .NET 8 / 10 codebases vs. .NET 11.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 2: AGENDA & MODULE MAP                                          -->
<!-- ===================================================================== -->

# Agenda & Topic Modules
## Organized by Domain Area

1. **Module 1: Tooling, SDK & Release Cadence**
   - STS 2-year support alignment, single-file C# scripts (`dotnet run file.cs`), and `.slnx` solution files
2. **Module 2: Modern C# Language (C# 12 – 15)**
   - C# 15 Union types, the `field` keyword, collection expressions, `?.=`, and DI constructor rules
3. **Module 3: Data Shaping & Libraries (Working with Dapper Results)**
   - Modern LINQ (`CountBy`, `AggregateBy`, `Index`, `LeftJoin`, `FullJoin`), `HybridCache`, and JSON/OpenAPI codegen
4. **Module 4: ASP.NET Core & Minimal APIs (.NET 8 – 11)**
   - Shared model validation (`IAsyncValidatableObject`), `TypedResults`, OpenAPI 3.2, and Options validation
5. **Module 5: Under-the-Hood Runtime Improvements (.NET 8 – 11)**
   - Native Runtime Async in CoreCLR and `FrozenDictionary` lookup caches

<!--
SPEAKER NOTES:
- Walk through the 5 modules.
- Note that live code demos are placed right after the concepts they illustrate (`01` through `05` in `demos/csharp-scripts/`, plus the `MinimalApiDemo` web project).
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 3: MODULE 1 DIVIDER                                             -->
<!-- ===================================================================== -->

# Module 1: Tooling, SDK & Release Cadence
## .NET 11 Support Alignment, Single-File Apps & Visual Studio Tooling

- **2-Year STS Policy Change:** Why `.NET 11` and `.NET 10` share the same End-of-Support date
- **File-Based C# Programs:** Running standalone `.cs` files with `#:property` and `#:package` directives
- **Solution & IDE Upgrades:** XML-simplified `.slnx` solution files and Visual Studio Hot Reload

<!--
SPEAKER NOTES:
- Module 1 covers SDK and Visual Studio tooling changes before we jump into C# syntax.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 4: SUPPORT LIFECYCLE ALIGNMENT                                  -->
<!-- ===================================================================== -->

# .NET Release Cadence: STS vs. LTS <span class="badge net10">.NET 10 LTS</span> <span class="badge net11">.NET 11 STS</span>
## Microsoft's 2-Year STS Policy Aligns .NET 10 and .NET 11 EOL

- **Why STS Used to Be Avoided:**
  - Previously, Standard Term Support (STS) releases only received **18 months** of support, ending in May—forcing upgrades mid-year.
- **The Policy Change (Starting in .NET 9):**
  - Microsoft extended STS support from 18 months to **24 months (2 full years)** so all releases end in **November**.
- **What This Means for .NET 10 and .NET 11:**
  - **.NET 10 (LTS):** 3 years of support (Nov 2025 – **November 14, 2028**)
  - **.NET 11 (STS):** 2 years of support (Nov 2026 – **November 14, 2028**)
  - Both reach End of Support on the **exact same date**, so adopting `.NET 11` gives us C# 15 and Runtime Async without shortening our support window.

<!--
SPEAKER NOTES:
- Explain the practical reason Microsoft changed STS from 18 months to 24 months: teams skipped odd-numbered releases because a May EOL was awkward to schedule.
- Because .NET 10 (3 years from Nov 2025) and .NET 11 (2 years from Nov 2026) both end support in November 2028, targeting .NET 11 has the exact same support horizon as .NET 10.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 5: FILE-BASED C# APPS                                           -->
<!-- ===================================================================== -->

# File-Based C# Apps <span class="badge net10">.NET 10</span> <span class="badge net11">.NET 11</span>
## Standalone Scripts with `dotnet run file.cs`

<div class="grid-2">
<div class="box-before">
<h4>Before .NET 10 (Required a .csproj File)</h4>

```xml
<!-- Had to maintain a separate .csproj file -->
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net11.0</TargetFramework>
    <LangVersion>preview</LangVersion>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Dapper" Version="2.1.66" />
  </ItemGroup>
</Project>
```
</div>

<div class="box-after">
<h4>.NET 10 & 11 (Single .cs File with Directives)</h4>

```csharp
#:property LangVersion=preview
#:package Dapper@2.1.66

using Dapper;
using Microsoft.Data.SqlClient;

Console.WriteLine("Run directly via: dotnet run Script.cs");
```
</div>
</div>

- **`#:property` & `#:package` Directives:** Configure MSBuild properties, SDKs (`#:sdk Microsoft.NET.Sdk.Web`), and NuGet packages directly at the top of a standalone `.cs` file.
- Run directly via `dotnet run Script.cs` (all our demo scripts use this format).

<!--
SPEAKER NOTES:
- Point out the `#:property` and `#:package` directives at the top of the `.cs` file.
- You no longer need a separate `.csproj` file just to test a Dapper query, run a utility script, or enable `<LangVersion>preview</LangVersion>`.
- If you later want to convert a script into a full project in Visual Studio, you can run `dotnet project convert Script.cs`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 6: MODERN SOLUTION FILES & VISUAL STUDIO                        -->
<!-- ===================================================================== -->

# Visual Studio & Solution Tooling <span class="badge net9">.NET 9</span> <span class="badge net10">.NET 10</span>
## `.slnx` XML Solution Files & Hot Reload

<div class="grid-2">
<div class="box-before">
<h4>Legacy .sln File (GUIDs & Merge Conflicts)</h4>

```text
Microsoft Visual Studio Solution File, Format Version 12.00
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Api", "Api.csproj", "{8B2A...}"
EndProject
Global
  GlobalSection(ProjectConfigurationPlatforms) = postSolution
    {8B2A...}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
    {8B2A...}.Debug|Any CPU.Build.0 = Debug|Any CPU
  EndGlobalSection
EndGlobal
```
</div>

<div class="box-after">
<h4>Modern .slnx File (Clean XML)</h4>

```xml
<Solution>
  <Folder Name="/Solution Items/">
    <File Path="requests.http" />
  </Folder>
  <Project Path="MinimalApiDemo.csproj" />
</Solution>
```
</div>
</div>

- **`.slnx` in Visual Studio & CLI:** Eliminates project GUIDs and configuration matrices, making Git diffs trivial and preventing `.sln` merge conflicts.
- **Visual Studio Hot Reload:** Supports updating Minimal API route lambdas, modifying method bodies, and adding new methods while debugging without restarting the application.

<!--
SPEAKER NOTES:
- Compare the old `.sln` format with `.slnx`.
- `.slnx` only lists the projects and solution folders—no random GUIDs.
- You can migrate existing solutions in Visual Studio ("Save Solution As -> XML Solution File (.slnx)") or via `dotnet sln migrate`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 7: MODULE 2 DIVIDER                                             -->
<!-- ===================================================================== -->

# Module 2: Modern C# Language (C# 12 – 15)
## Reducing Boilerplate & Modeling Domain Logic

- **C# 15 Union Types (`.NET 11`):** Modeling domain states, events, and repository results with exhaustive `switch` expressions
- **The `field` Keyword (`C# 14 / .NET 10`):** Semi-auto properties without explicit backing fields
- **Collection Expressions & Null-Conditional Assignment (`C# 12–14`):** `[.. list]`, `?.=`, and extension blocks
- **DI Constructor Guideline:** Why we avoid Primary Constructors on service classes

<!--
SPEAKER NOTES:
- Module 2 focuses on everyday C# language features from C# 12 through C# 15.
- We will show Union types first (and run Demos 01 and 02), then look at property/collection syntax (and run Demo 03).
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 8: C# 15 UNION TYPES OVERVIEW                                   -->
<!-- ===================================================================== -->

# C# 15 Union Types <span class="badge net11">.NET 11 / C# 15</span>
## Closed Type Sets & Exhaustive Pattern Matching

A `union` declares a closed set of permitted case types. The compiler guarantees that a value is always one of the listed types:

```csharp
// Domain State Machine: Each state carries only the properties valid for that state
public union OrderState(Pending, Paid, Shipped, Cancelled);

public sealed record Pending(int OrderId, DateTime CreatedAt);
public sealed record Paid(int OrderId, string TransactionId, decimal Amount);
public sealed record Shipped(int OrderId, string Carrier, string TrackingNumber);
public sealed record Cancelled(int OrderId, string Reason);
```

- **Where Unions Fit Well:**
  - **Domain State Machines:** Order states (`Pending | Paid | Shipped | Cancelled`) without nullable columns that only apply to one state.
  - **Polymorphic Domain Events / Messages:** Queue payloads (`OrderCreated | PaymentCaptured | ShipmentDispatched`).
  - **Operation Outcomes:** Explicit return contracts (`Success | NotFound | ValidationError`).
- **Compiler-Enforced Exhaustiveness:** A `switch` expression over an `OrderState` does not need a `_ =>` default arm—and if a new state is added later, the compiler flags every unhandled `switch`.

<!--
SPEAKER NOTES:
- Emphasize that unions are a general-purpose modeling tool, not just for error handling.
- In domain modeling, instead of having a single class with 10 nullable properties (`TrackingNumber?`, `CancellationReason?`, `TransactionId?`) and guessing which ones are populated, each state is its own record in the union.
- When you pattern-match over the union, the compiler ensures every case is handled.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 9: UNIONS IN REPOSITORIES + DEMO 01 & 02                        -->
<!-- ===================================================================== -->

# C# 15 Unions: Explicit Results vs. Exceptions <span class="badge net11">C# 15</span>
## Returning Repository Outcomes to Minimal APIs

<div class="grid-2">
<div class="box-before">
<h4>Before (Exceptions or Null Ambiguity)</h4>

```csharp
public OrderDto GetOrder(int id) {
    var row = conn.QuerySingleOrDefault<OrderDto>(...);
    if (row is null)
        throw new NotFoundException($"Order {id}");
    return row;
}

// Endpoint must know what exceptions to catch:
try {
    return Results.Ok(repo.GetOrder(id));
} catch (NotFoundException ex) {
    return Results.NotFound(ex.Message);
}
```
</div>

<div class="box-after">
<h4>With C# 15 Union + Exhaustive Switch</h4>

```csharp
public union OrderResult(Success, NotFound, ValidationError);

public OrderResult GetOrder(int id) {
    if (id <= 0)
        return new ValidationError("id", "Invalid ID");
    var row = conn.QuerySingleOrDefault<OrderDto>(...);
    return row is not null ? new Success(row) : new NotFound(id);
}

// Endpoint: compiler enforces handling all 3 cases
return repo.GetOrder(id) switch {
    Success s         => TypedResults.Ok(s.Order),
    NotFound nf       => TypedResults.NotFound(),
    ValidationError v => TypedResults.BadRequest(v)
};
```
</div>
</div>

<div class="demo-bar">
💻 <strong>Live Demos:</strong> <code>dotnet run 01_Unions_DomainState.cs</code> &amp; <code>dotnet run 02_Unions_Results.cs</code>
</div>

<!--
SPEAKER NOTES:
- Compare throwing exceptions for expected cases (like a missing row in a Dapper query) vs. returning a union.
- With the union return type, the method signature explicitly documents every possible outcome, and each case implicitly converts to `OrderResult`.
- [SWITCH TO DEMO]:
  1. Open `demos/csharp-scripts/01_Unions_DomainState.cs` and run `dotnet run 01_Unions_DomainState.cs`. Show what happens if you comment out one case in the `switch` expression (compiler warning/error).
  2. Open `demos/csharp-scripts/02_Unions_Results.cs` and run `dotnet run 02_Unions_Results.cs`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 10: THE FIELD KEYWORD                                           -->
<!-- ===================================================================== -->

# The `field` Keyword <span class="badge net10">.NET 10 / C# 14</span>
## Semi-Auto Properties Without Explicit Backing Fields

<div class="grid-2">
<div class="box-before">
<h4>Before C# 14 (Manual Backing Field)</h4>

```csharp
public class ProductModel
{
    private string _sku = string.Empty;
    private decimal _unitPrice;

    public string Sku
    {
        get => _sku;
        set => _sku = value?.Trim().ToUpperInvariant()
                      ?? string.Empty;
    }

    public decimal UnitPrice
    {
        get => _unitPrice;
        set => _unitPrice = value < 0m ? 0m : value;
    }
}
```
</div>

<div class="box-after">
<h4>C# 14 (Contextual `field` Keyword)</h4>

```csharp
public class ProductModel
{
    public string Sku
    {
        get => field;
        set => field = value?.Trim().ToUpperInvariant()
                       ?? string.Empty;
    } = string.Empty;

    public decimal UnitPrice
    {
        get => field;
        set => field = value < 0m ? 0m : value;
    }
}
```
</div>
</div>

- **`field` Keyword:** Refers to the compiler-generated backing field directly inside `get`, `set`, or `init` accessors.
- Keeps the backing storage private to the property itself (no other method in the class can bypass the setter by touching `_sku`).

<!--
SPEAKER NOTES:
- Whenever we needed to trim strings, normalize casing, or guard against negative numbers on a DTO property, we previously had to write a private field and expand both `get` and `set`.
- Also note the encapsulation benefit: with a manual `_sku` field, other methods inside the class could accidentally write to `_sku` directly and bypass the setter logic. With `field`, the backing field is scoped strictly to the property accessors.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 11: COLLECTION EXPRESSIONS & NULL-CONDITIONAL ASSIGNMENT        -->
<!-- ===================================================================== -->

# Collection Expressions & `?.=` <span class="badge net8">.NET 8</span> <span class="badge net10">.NET 10</span>
## Cleaner Everyday Syntax (C# 12 – 14)

<div class="grid-2">
<div class="box-before">
<h4>Before (Verbose Initialization & Null Checks)</h4>

```csharp
// Merging collections required Concat / ToList:
var allIds = baseIds
    .Concat(new[] { 999 })
    .Concat(extraIds)
    .ToArray();

// Conditional property assignment required if-block:
if (activeOrder is not null)
{
    activeOrder.Status = "Processed";
}
```
</div>

<div class="box-after">
<h4>Modern C# (Spread `[..]` & `?.=`)</h4>

```csharp
// [C# 12] Collection expression + spread operator:
int[] allIds = [.. baseIds, 999, .. extraIds];
List<string> tags = ["Urgent", "Dapper"];

// [C# 14] Null-conditional assignment:
activeOrder?.Status = "Processed";
```
</div>
</div>

- **Collection Expressions (`[..]`):** Works uniformly across `T[]`, `List<T>`, `IEnumerable<T>`, and `ReadOnlySpan<T>`.
- **Null-Conditional Assignment (`?.=`):** Evaluates the right-hand side and assigns only when the left-hand target is non-null.
- **Extension Blocks (`extension(T)` in C# 14):** Allows adding extension **properties** (not just methods) to existing types.

<!--
SPEAKER NOTES:
- Collection expressions `[..]` are one of the highest-frequency syntax improvements in C# 12+: empty collections are simply `[]`, and merging lists uses `[.. listA, .. listB]`.
- In C# 14 (.NET 10), `?.` can now appear on the left-hand side of an assignment (`activeOrder?.Status = "Processed"`).
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 12: PRIMARY CONSTRUCTORS IN DI + DEMO 03                        -->
<!-- ===================================================================== -->

# Architecture Guideline: Primary Constructors
## Why We Avoid Primary Constructors on DI Service Classes

```csharp
// ❌ Avoid on DI services: captured parameters are mutable and cannot be marked 'readonly'
public class OrderService(IDapperOrderRepository repository, ILogger<OrderService> logger)
{
    public async Task ProcessAsync(int id)
    {
        // 'repository' is a mutable private field under the hood — it can be overwritten:
        // repository = null!; <-- Compiles without error!
    }
}
```

- **Where Primary Constructors Are Great:** Data structures, DTOs, and immutable `record` types (`public sealed record OrderDto(int Id, string Customer);`).
- **Why We Skip Them for DI Services:** Captured primary constructor parameters **cannot be marked `readonly`**. Stick to explicit `private readonly` fields in services so dependencies remain immutable.

<div class="demo-bar">
💻 <strong>Live Demo:</strong> <code>dotnet run 03_LanguageFeatures.cs</code> (<code>field</code> keyword, <code>[.. list]</code>, and <code>?.=</code>)
</div>

<!--
SPEAKER NOTES:
- Clarify the distinction: primary constructors on `record` types generate `init`-only properties, which is great.
- On regular `class` services, primary constructor parameters are captured as mutable fields with no `readonly` modifier allowed.
- [SWITCH TO DEMO]:
  Run `dotnet run 03_LanguageFeatures.cs` in `demos/csharp-scripts/`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 13: MODULE 3 DIVIDER                                            -->
<!-- ===================================================================== -->

# Module 3: Data Shaping & Libraries
## Working with Flat Dapper Stored Procedure Results

- **Modern LINQ Aggregations (`.NET 9`):** `CountBy`, `AggregateBy`, and `Index`
- **Modern LINQ Outer Joins (`.NET 10 & 11`):** `LeftJoin`, composite-key joins, and `FullJoin`
- **Caching Stored Procedure Outputs (`.NET 9–11`):** Stampede protection with `HybridCache`
- **JSON & OpenAPI Code Generation:** `System.Text.Json` source generation & automatic TypeScript/C# API clients

<!--
SPEAKER NOTES:
- In our architecture, Dapper executes stored procedures and returns flat rowsets (`IEnumerable<T>`).
- Module 3 covers the library improvements for aggregating, joining, caching, and serializing those results.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 14: MODERN LINQ AGGREGATIONS                                    -->
<!-- ===================================================================== -->

# Modern LINQ: `CountBy`, `AggregateBy` & `Index` <span class="badge net9">.NET 9</span>
## Aggregating Without Intermediate `GroupBy` Allocations

<div class="grid-2">
<div class="box-before">
<h4>Before .NET 9 (GroupBy + Select / ToDictionary)</h4>

```csharp
// Allocates intermediate IGrouping<TKey, TElement> buckets:
var counts = orderLines
    .GroupBy(x => x.Customer)
    .ToDictionary(g => g.Key, g => g.Count());

var spend = orderLines
    .GroupBy(x => x.Customer)
    .ToDictionary(
        g => g.Key,
        g => g.Sum(x => x.Quantity * x.UnitPrice)
    );
```
</div>

<div class="box-after">
<h4>.NET 9 (Single-Pass Key Aggregation)</h4>

```csharp
// 1. CountBy: Frequency count per key
var counts = orderLines.CountBy(x => x.Customer);

// 2. AggregateBy: Accumulate value per key
//    seed: 0m is the initial decimal (0.00) per customer
var spend = orderLines.AggregateBy(
    keySelector: x => x.Customer,
    seed: 0m,
    func: (runningTotal, x) =>
        runningTotal + (x.Quantity * x.UnitPrice)
);
```
</div>
</div>

- **`seed: 0m` in `AggregateBy`:** Defines the starting value for each key's accumulator (`0m` is C#'s `decimal` zero literal for currency). For each matching row, `func` adds the row's amount to `runningTotal`.
- **`Index()` (`.NET 9`):** `foreach (var (index, line) in orderLines.Index())` yields `(int Index, T Item)` tuples when you need an element's position alongside the item itself, replacing manual `int i = 0; i++` counters.

<div class="demo-bar">
💻 <strong>Live Demo:</strong> <code>dotnet run 04_Linq_Aggregations.cs</code>
</div>

<!--
SPEAKER NOTES:
- Walk through `CountBy` and `AggregateBy`.
- Point out `seed: 0m`: whenever a new customer key is encountered, its total starts at `0m` (decimal zero), and each order line updates that customer's running total.
- Show `Index()`: useful whenever you iterate a list and need the 0-based position alongside the element (for example, setting a `LineNumber` or logging).
- [SWITCH TO DEMO]:
  Run `dotnet run 04_Linq_Aggregations.cs`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 15: MODERN LINQ OUTER JOINS                                     -->
<!-- ===================================================================== -->

# Modern LINQ: `LeftJoin`, `RightJoin` & `FullJoin` <span class="badge net10">.NET 10</span> <span class="badge net11">.NET 11</span>
## Joining Two Stored Procedure Result Sets in Memory

<div class="grid-2">
<div class="box-before">
<h4>Before .NET 10 (GroupJoin + DefaultIfEmpty)</h4>

```csharp
var enriched =
    from line in orderLines
    join prod in catalog
      on line.Sku equals prod.Sku into prodGroup
    from prod in prodGroup.DefaultIfEmpty()
    select new {
        line.OrderId,
        line.Sku,
        Title = prod?.Title ?? "[Missing]"
    };
```
</div>

<div class="box-after">
<h4>.NET 10 & 11 (First-Class Outer Join Methods)</h4>

```csharp
// [.NET 10] Native LeftJoin (prod is null if unmatched):
var enriched = orderLines.LeftJoin(
    catalog,
    line => line.Sku,
    prod => prod.Sku,
    (line, prod) => new {
        line.OrderId,
        line.Sku,
        Title = prod?.Title ?? "[Missing]"
    }
);
```
</div>
</div>

- **Why Join in C#?** When a stored procedure returns multiple result sets (`QueryMultipleAsync`) or when combining Dapper rows with cached reference data in memory.
- **`.NET 10`:** Added `LeftJoin` and `RightJoin` to `System.Linq.Enumerable`.
- **`.NET 11`:** Added `FullJoin` (retaining unmatched rows from *both* the left and right collections).

<!--
SPEAKER NOTES:
- Previously, writing a left outer join in LINQ required `GroupJoin` + `SelectMany` + `DefaultIfEmpty()`, which nobody could write from memory.
- In .NET 10, `LeftJoin` and `RightJoin` are standard LINQ methods with the exact same parameter order as `Join`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 16: LEFTJOIN COMPOSITE KEYS & CAPABILITIES + DEMO 05            -->
<!-- ===================================================================== -->

# `LeftJoin`: Multiple Conditions & Capabilities <span class="badge net10">.NET 10</span>
## Joining on Composite Keys and Understanding Limits

```csharp
// Joining on MULTIPLE properties: return an anonymous object (or tuple) in both key selectors
var regionalJoin = orders.LeftJoin(
    catalog,
    order => new { order.TenantId, order.Sku }, // Left composite key
    prod  => new { prod.TenantId,  prod.Sku  }, // Right composite key
    (order, prod) => new
    {
        order.OrderId,
        order.TenantId,
        ProductTitle = prod?.Title ?? "[No matching regional product]"
    }
);
```

- **How Multi-Condition Joins Work:** Anonymous types (`new { a, b }`) and value tuples (`(a, b)`) implement structural `Equals` and `GetHashCode` automatically, so LINQ hashes and matches all properties together.
- **What `LeftJoin` CAN Do:** Single keys, multi-property composite keys, and custom `IEqualityComparer<TKey>` (e.g., `StringComparer.OrdinalIgnoreCase`).
- **What `LeftJoin` CANNOT Do:** Non-equality conditions (such as `order.Date >= promo.Start && order.Date <= promo.End`). Non-equi joins must be done in the SQL stored procedure or via `.Where()`.

<div class="demo-bar">
💻 <strong>Live Demo:</strong> <code>dotnet run 05_Linq_Joins.cs</code> (Single key, Composite key &amp; <code>FullJoin</code>)
</div>

<!--
SPEAKER NOTES:
- Explain how multi-column joins work in LINQ: C# anonymous types override `Equals` and `GetHashCode` across all their properties, so `new { order.TenantId, order.Sku }` acts as a composite hash key in `LeftJoin`.
- Also be clear about the limitation: like `Enumerable.Join`, `LeftJoin` is a hash equi-join (it only matches `keyA == keyB`), so range joins (`BETWEEN`, `<`, `>`) belong in SQL.
- [SWITCH TO DEMO]:
  Run `dotnet run 05_Linq_Joins.cs`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 17: HYBRIDCACHE                                                 -->
<!-- ===================================================================== -->

# Caching Stored Proc Results: `HybridCache` <span class="badge net9">.NET 9</span> <span class="badge net11">.NET 11</span>
## Preventing Database Cache Stampedes

- **The Problem with `IMemoryCache`:** When a cached key expires under load, 50 concurrent HTTP requests will all see a cache miss and execute the same SQL / Oracle DB stored procedure simultaneously (*Cache Stampede*).
- **How `HybridCache` Solves It:** Coalesces concurrent callers per key—**only 1 request executes the Dapper query**, while the other 49 await the same task and receive the result.

```csharp
// Minimal usage (tags are optional):
var orders = await hybridCache.GetOrCreateAsync(
    $"customer-orders-{customerId}",
    async ct => await dapperRepo.GetOrdersByCustomerIdAsync(customerId, ct),
    cancellationToken: ct
);

// Optional: attach tags if you want to invalidate a group of keys later
var taggedOrders = await hybridCache.GetOrCreateAsync(
    $"customer-orders-{customerId}",
    async ct => await dapperRepo.GetOrdersByCustomerIdAsync(customerId, ct),
    tags: [$"customer-{customerId}", "orders"], // Optional parameter
    cancellationToken: ct
);
```

<!--
SPEAKER NOTES:
- Highlight the main reason to use `HybridCache` over raw `IMemoryCache`: stampede protection (request coalescing) is built in.
- If 50 requests arrive for the same uncached key at the same millisecond, your SQL or Oracle database only runs the stored procedure once.
- Point out that `tags` are completely optional—only pass them if you want to evict related keys together via `RemoveByTagAsync`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 18: SYSTEM.TEXT.JSON IMPROVEMENTS                               -->
<!-- ===================================================================== -->

# `System.Text.Json`: Source Generation & Contracts <span class="badge net9">.NET 9</span> <span class="badge net11">.NET 11</span>
## Compile-Time Serialization & Strict Schema Options

<div class="grid-2">
<div class="box-before">
<h4>Default Reflection Serializer</h4>

- Inspects DTO properties via `System.Reflection` at runtime on the first request.
- Serialization configuration issues (e.g., unsupported types or cycles) are only discovered at runtime when an endpoint is hit.
</div>

<div class="box-after">
<h4>Compile-Time Source Generator</h4>

```csharp
[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    RespectNullableAnnotations = true)]
[JsonSerializable(typeof(IReadOnlyList<OrderDto>))]
internal partial class AppJsonContext : JsonSerializerContext;
```
</div>
</div>

- **What `JsonSerializerContext` Actually Does:** A Roslyn source generator writes the exact property-by-property UTF-8 serialization C# code at **compile time**—eliminating runtime reflection and warming overhead.
- **`.NET 9–11` Additions:**
  - **`RespectNullableAnnotations = true`:** Throws a validation error if a JSON payload passes `null` into a non-nullable C# property (`string Sku` vs `string? Notes`).
  - **`[JsonPolymorphic]` / Discriminated Unions:** Emits a `"$type"` discriminator property for nested polymorphic properties (note: keep top-level endpoint responses consistent per status code using `TypedResults`).

<!--
SPEAKER NOTES:
- Explain specifically what JSON source generation does: instead of inspecting properties via reflection at runtime, Roslyn generates the C# serialization code during build.
- Also highlight `RespectNullableAnnotations` (.NET 9+): previously, even if a C# record had `string Sku` (non-nullable), `System.Text.Json` happily deserialized `{"sku": null}` into `null`. Enabling `RespectNullableAnnotations` enforces non-nullable properties during deserialization.
- On union/polymorphic JSON: useful for nested polymorphic fields inside a DTO, whereas for endpoint responses we should return consistent DTO shapes per HTTP status code rather than varying 200 OK shapes.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 19: BONUS - OPENAPI TO REACT / VITE CODEGEN                     -->
<!-- ===================================================================== -->

# Bonus: Generating React / Vite Clients from OpenAPI
## Named Functions & TypeScript Models Directly from `/openapi/v1.json`

The OpenAPI spec includes **both** the DTO schemas and the endpoint URL paths + `operationId` (from `.WithName("GetCustomerOrders")` in Minimal APIs). Tools like **Orval** or **Hey API (`@hey-api/openapi-ts`)** generate named functions and React hooks so you never write URL paths by hand:

```bash
# Generate typed client functions & DTO models from the .NET OpenAPI spec:
npx @hey-api/openapi-ts -i http://localhost:5248/openapi/v1.json -o src/api
```

```typescript
// Generated from .WithName("GetCustomerOrders") — URL path and types are baked in:
import { getCustomerOrders, createOrder, type OrderDto } from "./api";

// 1. Call the generated function directly (no raw "/api/..." path strings!):
const { data: orders } = await getCustomerOrders({ path: { customerId: 1 } });

// 2. Or with Orval + React Query, generate ready-to-use hooks:
const { data: orders, isLoading } = useGetCustomerOrders(customerId);
// 'orders' is automatically typed as OrderDto[]!
```

- **Why This Matters:** Both URL routes and DTO properties come straight from .NET. If a C# property or endpoint signature changes, `npm run build` in Vite immediately fails with a TypeScript compile error.

<!--
SPEAKER NOTES:
- Why did `openapi-typescript` require passing the URL string? Because `openapi-typescript` only generates a `.d.ts` type dictionary keyed by URL path.
- If you use a full client generator like `@hey-api/openapi-ts`, `orval`, or `nswag`, it reads the URL path AND the `operationId` (set via `.WithName("GetCustomerOrders")` on the Minimal API endpoint) from `/openapi/v1.json` and generates actual named TypeScript functions (`getCustomerOrders`, `createOrder`) or React Query hooks (`useGetCustomerOrders`).
- That way, React components never hardcode URL paths or manually define `interface OrderDto`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 20: BONUS - OPENAPI TO .NET CLIENT CODEGEN                      -->
<!-- ===================================================================== -->

# Bonus: Generating C# Clients from OpenAPI in .NET
## Typed Service-to-Service Calls Without Manual `HttpClient` Boilerplate

When one .NET service calls another internal API, we can generate the C# models and typed client directly from its OpenAPI specification:

```xml
<!-- Option A: Built-in MSBuild OpenApiReference in .csproj (NSwag) -->
<ItemGroup>
  <OpenApiReference Include="openapi.json" Namespace="OrdersClient" ClassName="OrdersApiClient" />
</ItemGroup>
```

```csharp
// Option B: Kiota / NSwag / Refit generated client usage in DI:
builder.Services.AddHttpClient<IOrdersApiClient, OrdersApiClient>(
    client => client.BaseAddress = new Uri("https://orders-api.internal"));

// Calling the API uses strongly-typed models and return types automatically:
IReadOnlyList<OrderDto> orders = await ordersClient.GetCustomerOrdersAsync(customerId: 1, ct);
```

- **Consistent Workflow Across Stack:** The Minimal API's OpenAPI document becomes the single source of truth for **both** React/Vite TypeScript clients and .NET C# clients.

<!--
SPEAKER NOTES:
- Just like on the React side, if one .NET service calls another API, we don't need to hand-write `HttpClient.GetFromJsonAsync<OrderDto>("/api/...")` and duplicate the DTO classes.
- Adding an `<OpenApiReference>` in Visual Studio (Connected Services -> OpenAPI) or using Kiota/Refit generates the models and typed client methods automatically.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 21: SEQUENTIAL IDENTIFIERS: GUID V7                             -->
<!-- ===================================================================== -->

# Database-Friendly GUIDs: `Guid.CreateVersion7()` <span class="badge net9">.NET 9</span>
## Timestamp-Ordered GUIDs in One Method Call

```csharp
// Standard v4 GUID (completely random bits — causes B-Tree index page splits if used as clustered key):
Guid randomV4 = Guid.NewGuid();          // e.g. f47ac10b-58cc-4372-a567-0e02b2c3d479

// [.NET 9] Version 7 GUID (first 48 bits are a Unix millisecond timestamp — sorts chronologically):
Guid sequentialV7 = Guid.CreateVersion7(); // e.g. 0192f7b4-8c10-7a32-9b11-4d3e2f1a0b9c
Guid nextV7       = Guid.CreateVersion7(); // e.g. 0192f7b4-8c11-7401-8c22-9a8b7c6d5e4f
```

- **When to Use It:** Whenever C# code generates a `Guid` primary key or correlation ID that gets indexed in a database table—`Guid.CreateVersion7()` inserts sequentially at the end of the index instead of fragmenting random pages.

<!--
SPEAKER NOTES:
- Keep this brief: if you ever generate GUIDs in C# that are stored in an indexed database column, use `Guid.CreateVersion7()` instead of `Guid.NewGuid()` so rows sort in creation order.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 22: MODULE 4 DIVIDER                                            -->
<!-- ===================================================================== -->

# Module 4: ASP.NET Core & Minimal APIs (.NET 8 – 11)
## Startup Options, Model Validation, TypedResults & OpenAPI 3.2

- **Options Pattern Startup Validation (`.NET 8–10`):** `ValidateOnStart()` and `[ValidateEnumeratedItems]`
- **Shared Model Validation (`.NET 10 & 11`):** Why validation belongs on the model + `.NET 11` `IAsyncValidatableObject`
- **`TypedResults` & Union Endpoints:** Strongly-typed multi-status responses for exact OpenAPI schemas
- **Built-in OpenAPI 3.1 / 3.2 (`.NET 9–11`):** Dropping Swashbuckle and pairing with Scalar UI

<!--
SPEAKER NOTES:
- Module 4 covers ASP.NET Core Minimal APIs, starting with startup configuration validation and progressing into request model validation and OpenAPI generation.
- At the end of this module we will run the `MinimalApiDemo` Visual Studio project and execute requests against it using `requests.http`.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 23: OPTIONS PATTERN ENHANCEMENTS                                -->
<!-- ===================================================================== -->

# Options Pattern: Startup & Deep Validation <span class="badge net8">.NET 8</span> <span class="badge net10">.NET 10</span>
## Catching Misconfigured `appsettings.json` on Application Startup

```csharp
// In Program.cs — fails immediately on startup if configuration is invalid:
builder.Services.AddOptions<OrderProcessingOptions>()
    .BindConfiguration("OrderProcessing")
    .ValidateDataAnnotations()
    .ValidateOnStart();
```

```csharp
public class OrderProcessingOptions
{
    [Range(1, 500)]
    public int BatchSizeLimit { get; set; } = 100;

    [Required]
    public string RegionEndpoint { get; set; } = string.Empty;

    // [.NET 8+] Validates nested objects and every item inside a collection:
    [ValidateObjectMembers]
    public RetryPolicyOptions RetryPolicy { get; set; } = new();

    [ValidateEnumeratedItems]
    public List<WebhookChannelOptions> NotificationChannels { get; set; } = [];
}
```

<!--
SPEAKER NOTES:
- Without `ValidateOnStart()`, a missing or invalid setting in `appsettings.json` isn't noticed until a user hits the specific code path that resolves `IOptions<OrderProcessingOptions>`.
- Adding `[ValidateObjectMembers]` and `[ValidateEnumeratedItems]` ensures validation also traverses nested objects and lists, and source-generated `[OptionsValidator]` makes it reflection-free.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 24: MODEL VALIDATION & IASYNCVALIDATABLEOBJECT                  -->
<!-- ===================================================================== -->

# Model-Level Validation & `IAsyncValidatableObject` <span class="badge net10">.NET 10</span> <span class="badge net11">.NET 11</span>
## Reusing Validation Across Insert, Update & Code Assignments

- **Why Validate on the Model Instead of the Endpoint?**
  - Defining rules on the model (`[Required]`, `[Range]`, `IAsyncValidatableObject`) means the exact same validation runs for **Insert (`POST`)**, **Update (`PUT`)**, and when constructing or testing models in code.

```csharp
// [.NET 10] Source-generated Minimal API validation + [.NET 11] IAsyncValidatableObject
public class OrderUpsertModel : IAsyncValidatableObject
{
    [Required, Range(1, int.MaxValue)]
    public int CustomerId { get; set; }

    [Required, MinLength(2)]
    public string Sku { get; set; } = string.Empty;

    [Range(1, 1000)]
    public int Quantity { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext context) => [];

    // [.NET 11] Asynchronous validation for DB/service checks without blocking threads:
    public async IAsyncEnumerable<ValidationResult> ValidateAsync(
        ValidationContext context, [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.Delay(10, ct); // e.g., check if CustomerId or Sku is active in DB
        if (Sku.StartsWith("DISCONTINUED-", StringComparison.OrdinalIgnoreCase))
            yield return new ValidationResult($"SKU '{Sku}' is discontinued.", [nameof(Sku)]);
    }
}
```

<!--
SPEAKER NOTES:
- Just as DataAnnotations validate our startup `appsettings.json` options, .NET 10 and 11 bring first-class DataAnnotations validation to Minimal API request models.
- Highlight the architectural point: if you write `if (req.Quantity <= 0)` inside your `MapPost` lambda, someone will inevitably forget to copy that check into `MapPut` or a background job.
- Putting data annotations and `IAsyncValidatableObject` on `OrderUpsertModel` keeps the invariant in one place for both inserts and updates.
- In .NET 10, Minimal APIs gained built-in `AddValidation()` (using a compile-time source generator via `[ValidatableType]`), and .NET 11 adds `IAsyncValidatableObject` so custom validation can `await` database checks cleanly.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 25: TYPEDRESULTS & BUILT-IN OPENAPI 3.2                         -->
<!-- ===================================================================== -->

# `TypedResults` & Built-in OpenAPI 3.2 <span class="badge net9">.NET 9</span> <span class="badge net11">.NET 11</span>
## Exact Multi-Status Schemas Without Swashbuckle

```csharp
// Return signature declares the exact HTTP status codes and payload types:
app.MapGet("/api/customers/{customerId:int}/orders",
    async Task<Results<Ok<IEnumerable<OrderDto>>, NotFound<string>>> (
        int customerId, IDapperOrderRepository repo, CancellationToken ct) =>
{
    var orders = await repo.GetOrdersByCustomerIdAsync(customerId, ct);
    return orders.Any()
        ? TypedResults.Ok(orders)
        : TypedResults.NotFound($"No orders found for customer {customerId}");
});
```

- **`TypedResults` vs `Results`:**
  - `Results.Ok(...)` returns an untyped `IResult`, hiding the response type from OpenAPI unless you manually add `.Produces<T>(200)`.
  - `TypedResults.Ok(...)` preserves generic type metadata in the return signature (`Results<Ok<T>, NotFound<string>>`), so OpenAPI automatically documents every status code.
- **Built-in OpenAPI 3.1 / 3.2 (`Microsoft.AspNetCore.OpenApi`):**
  - Replaces Swashbuckle natively (`builder.Services.AddOpenApi()` + `app.MapOpenApi()`), and in `.NET 11` adds binary file response schemas (`TypedResults.File`). Pairs with **Scalar** or Swagger UI.

<!--
SPEAKER NOTES:
- Show how `Task<Results<Ok<IEnumerable<OrderDto>>, NotFound<string>>>` does two things at once:
  1. The C# compiler verifies your endpoint only returns those declared status types.
  2. Built-in OpenAPI reads that return type and populates the `200` and `404` schemas in `/openapi/v1.json` without needing `[ProducesResponseType]` attributes.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 26: PIPELINE FEATURES & MINIMAL API DEMO                        -->
<!-- ===================================================================== -->

# Pipeline Improvements & Live Web API Demo <span class="badge net8">.NET 8</span> <span class="badge net11">.NET 11</span>
## `[ShortCircuit]`, `IExceptionHandler` & `MinimalApiDemo`

- **`ShortCircuit()` on Probe Routes (`.NET 8+`):**
  ```csharp
  // Executes immediately after routing, bypassing authentication, logging, and CORS middleware:
  app.MapGet("/health", () => Results.Ok(new { status = "Healthy" })).ShortCircuit();
  ```
- **`IExceptionHandler` (`.NET 8+`):** Clean, DI-friendly interface for centralized exception-to-`ProblemDetails` handling, replacing custom `try/catch` middleware classes.

<div class="demo-bar">
💻 <strong>Live Demo (Visual Studio / <code>.slnx</code>):</strong> <code>demos/MinimalApiDemo/</code>
<br/>• Inspect <code>MinimalApiDemo.slnx</code> &amp; <code>Program.cs</code> (Options <code>ValidateOnStart</code>, <code>HybridCache</code>, <code>IAsyncValidatableObject</code> on <code>POST</code> &amp; <code>PUT</code>, <code>TypedResults</code>)
<br/>• Run API &amp; open Scalar UI (<code>/scalar/v1</code>) + fire requests from <code>requests.http</code>
</div>

<!--
SPEAKER NOTES:
- Point out `.ShortCircuit()` for health checks and static probes so they don't run through auth/logging middleware.
- [SWITCH TO DEMO]:
  1. Open `demos/MinimalApiDemo/MinimalApiDemo.slnx` (or `Program.cs` and `requests.http`).
  2. Start the server: `dotnet run --project dotnet-11-presentation/demos/MinimalApiDemo/MinimalApiDemo.csproj --urls http://localhost:5248`.
  3. Open `requests.http` and fire:
     - `GET /health`
     - `GET /api/customers/1/orders` (cached via `HybridCache`)
     - `POST /api/orders` and `PUT /api/orders/101` (sharing `OrderUpsertModel` validation)
     - `POST /api/orders` with `DISCONTINUED-PART` to see `.NET 11` `IAsyncValidatableObject` return a 400 `ValidationProblem`.
  4. Show `/scalar/v1` and `/openapi/v1.json` in the browser.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 27: MODULE 5 DIVIDER                                            -->
<!-- ===================================================================== -->

# Module 5: Under-the-Hood Runtime Improvements
## What We Get Automatically When Upgrading the Runtime

- **Runtime Async (`.NET 11`):** CoreCLR natively understands `async` methods—cleaner stack traces and lower `await` overhead on every `connection.QueryAsync()`
- **Read-Heavy Lookup Caches (`.NET 8–9`):** `FrozenDictionary<TKey, TValue>` and `SearchValues<T>`

<!--
SPEAKER NOTES:
- Module 5 is a quick look under the hood at what changes in the runtime itself when we target .NET 11.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 28: RUNTIME ASYNC                                               -->
<!-- ===================================================================== -->

# Runtime Async <span class="badge net11">.NET 11 Runtime</span>
## Native CoreCLR Async Execution (Replacing Compiler State Machines)

<div class="grid-2">
<div class="box-before">
<h4>Before .NET 11 (Compiler State Machine)</h4>

- Since C# 5 (2012), the Roslyn compiler rewrote every `async` method into a generated `IAsyncStateMachine` struct (`<GetOrdersAsync>d__4`).
- Whenever a Dapper `await connection.QueryAsync(...)` suspended for I/O, the state machine had to be boxed onto the heap.
- Produced noisy stack traces filled with `.MoveNext()` frames.
</div>

<div class="box-after">
<h4>.NET 11 (CoreCLR Runtime Async)</h4>

- The **CoreCLR runtime and JIT natively manage `async` method suspension and resumption**.
- Eliminates compiler-generated state machine dispatch overhead.
- **Fewer allocations** across async-heavy Dapper repository and Minimal API pipelines.
- **Cleaner stack traces:** Exception logs point directly to your method signatures without `<Method>d__4.MoveNext()` noise.
</div>
</div>

<!--
SPEAKER NOTES:
- Explain why this matters to every developer on the team even if we don't have extreme throughput requirements:
  1. Stack traces in logs and the Visual Studio debugger are much cleaner because the compiler state machine (`<Method>d__MoveNext`) is gone.
  2. Every `await connection.QueryAsync()` in Dapper and every async Minimal API handler runs with less state-machine boxing overhead automatically—with zero code changes required.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 29: FROZENDICTIONARY & SEARCHVALUES                             -->
<!-- ===================================================================== -->

# Read-Only Lookup Caches: `FrozenDictionary` <span class="badge net8">.NET 8</span> <span class="badge net9">.NET 9</span>
## Fast, Immutable In-Memory Reference Tables

```csharp
using System.Collections.Frozen;

// Ideal for lookup tables loaded once at startup and read on every request:
private static readonly FrozenDictionary<string, int> StatusPriorityMap =
    new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
    {
        ["Pending"]   = 1,
        ["Processing"] = 2,
        ["Shipped"]   = 3,
        ["Completed"] = 4
    }.ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
```

- **`FrozenDictionary<TKey, TValue>` (`.NET 8+`):**
  - Takes slightly longer to construct once at startup in exchange for **significantly faster `.TryGetValue()` lookups** and guaranteed immutability.
- **`SearchValues<T>` (`.NET 8 & 9`):**
  - Precomputes vectorized character or substring search tables (`SearchValues.Create(["ADMIN-", "SYS-"], StringComparison.OrdinalIgnoreCase)`) for fast validation checks.

<!--
SPEAKER NOTES:
- Whenever we have a static `Dictionary<TKey, TValue>` or lookup map initialized once at startup and read many times, `.ToFrozenDictionary()` is a drop-in replacement that is both immutable and faster for reads.
-->

---

<!-- ===================================================================== -->
<!-- SLIDE 30: FEATURE CHEAT SHEET BY VERSION & Q&A                        -->
<!-- ===================================================================== -->

# Feature Reference by .NET Version & Q&A
## What We Can Use in Existing Projects vs. .NET 11

| Version | Language & Tooling | Libraries, Data & Minimal APIs |
| :--- | :--- | :--- |
| **.NET 8** `(C# 12)` | Collection expressions `[.. list]` | `ValidateOnStart()`, `[ValidateEnumeratedItems]`, `[ShortCircuit]`, `FrozenDictionary` |
| **.NET 9** `(C# 13)` | `.slnx` XML solution files | LINQ `CountBy`, `AggregateBy`, `Index()`, `HybridCache`, Built-in OpenAPI, `Guid.CreateVersion7()` |
| **.NET 10** `(C# 14)` | `dotnet run file.cs`, `field` keyword, `?.=`, `extension(T)` | LINQ `LeftJoin` & `RightJoin`, Minimal API `AddValidation()` (`[ValidatableType]`) |
| **.NET 11** `(C# 15)` | **C# 15 Union Types** (`union` & exhaustive `switch`), **2-Year STS (Nov 2028 EOL)** | **CoreCLR Runtime Async**, **`IAsyncValidatableObject`**, LINQ `FullJoin`, OpenAPI 3.2 binary schemas |

<!--
SPEAKER NOTES:
- Use this table as a wrap-up reference during Q&A.
- Point out that features in the .NET 8, 9, and 10 rows can already be used in our .NET 8 / 10 codebases today, while upgrading to .NET 11 unlocks C# 15 Unions, `IAsyncValidatableObject`, and Runtime Async with the same November 2028 support window as .NET 10.
-->
