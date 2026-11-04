# Presenter Prep Guide & Architectural Study Sheet
## What's New in .NET 11: Modern .NET Features for Minimal APIs, Dapper & React

> **Target Audience:** Junior-to-mid-level software engineers looking for high-utility modern .NET upgrades across .NET 8, 9, 10, and 11 (C# 12–15).  
> **Tech Stack Context:** ASP.NET Core Minimal APIs + **Dapper** calling **SQL / Oracle DB Stored Procedures** + **React (Vite)** frontend.  
> **Presentation Flow:** Show the concept and syntax -> Explain how it works and why it matters -> Run the live demo (`01` through `05` + `MinimalApiDemo`).

---

## Table of Contents
1. [Presentation Structure & 5-Module Flow (30 Slides)](#1-presentation-structure--5-module-flow-30-slides)
2. [Exact CLI Commands & Runbook](#2-exact-cli-commands--runbook)
3. [Under-the-Hood Architectural Deep Dives](#3-under-the-hood-architectural-deep-dives)
   - [3.1 C# 15 Union Types (Domain State Machines & Explicit Result Pattern)](#31-c-15-union-types-domain-state-machines--explicit-result-pattern)
   - [3.2 C# 14 `field` Keyword, Collection Expressions & Extension Blocks](#32-c-14-field-keyword-collection-expressions--extension-blocks)
   - [3.3 Modern LINQ: `CountBy`, `AggregateBy` (`seed: 0m`), and `Index()`](#33-modern-linq-countby-aggregateby-seed-0m-and-index)
   - [3.4 LINQ `LeftJoin` & `RightJoin`: Single Key vs. Composite Key Joins](#34-linq-leftjoin--rightjoin-single-key-vs-composite-key-joins)
   - [3.5 `HybridCache`: Stampede Protection & Optional Tag Invalidation](#35-hybridcache-stampede-protection--optional-tag-invalidation)
   - [3.6 Shared Model Validation (`POST` & `PUT`) & `.NET 11` `IAsyncValidatableObject`](#36-shared-model-validation-post--put--net-11-iasyncvalidatableobject)
   - [3.7 Bonus: OpenAPI 3.2 Contract Generation for React/Vite & .NET Clients](#37-bonus-openapi-32-contract-generation-for-reactvite--net-clients)
   - [3.8 Native Runtime Async in .NET 11 CoreCLR](#38-native-runtime-async-in-net-11-coreclr)
4. [Anticipated Audience Q&A (With Crisp Answers)](#4-anticipated-audience-qa-with-crisp-answers)
5. [Slide-by-Slide Cheat Sheet & Demo Callouts (Slides 1–30)](#5-slide-by-slide-cheat-sheet--demo-callouts-slides-130)

---

## 1. Presentation Structure & 5-Module Flow (30 Slides)

The slide deck ([deck.md](file:///C:/dev/antigravity/whatsnewdotnet11/dotnet-11-presentation/slides/deck.md) / [index.html](file:///C:/dev/antigravity/whatsnewdotnet11/dotnet-11-presentation/slides/index.html)) uses Marp in high-contrast **light mode**. Every slide renders all content immediately with zero click-to-reveal fragment animations.

- **Module 1: Tooling & Developer Experience (Slides 1–6)**
  - Title & Agenda across 5 modules.
  - Release Cadence & Support Policy: Microsoft extended STS from 18 months to **24 months** starting with .NET 11, meaning both .NET 10 (LTS) and .NET 11 (STS) reach End of Support on **November 14, 2028**.
  - File-based C# execution (`dotnet run script.cs` with `#:property` / `#:package`).
  - `.slnx` XML solution format and Visual Studio / SDK workflow updates.
- **Module 2: C# Language Evolution — C# 12 to C# 15 (Slides 7–13)**
  - C# 15 `union` types for closed domain state machines (**Demo 01**).
  - C# 15 `union` types for explicit service result contracts without exception overhead (**Demo 02**).
  - C# 14 `field` keyword for semi-auto properties.
  - Collection expressions (`[.. items]`), `params ReadOnlySpan<T>`, and C# 14 `extension` blocks (**Demo 03**).
  - Architecture Note: Why Primary Constructors are an anti-pattern on DI service classes (captured parameters are mutable and lack `readonly` guarantees).
- **Module 3: Core Libraries, LINQ & Data Shaping (Slides 14–19)**
  - LINQ `CountBy`, `AggregateBy` (explaining `seed: 0m`), and `Index()` (**Demo 04**).
  - LINQ `LeftJoin` and `RightJoin` across single keys and multi-property composite keys (**Demo 05**).
  - `HybridCache` (L1 RAM + L2 SQL/Oracle DB, stampede coalescing, optional tags) and `System.Text.Json` source generation.
- **Module 4: Minimal APIs, Validation & Contract Generation (Slides 20–26)**
  - Fail-fast configuration startup validation (`ValidateDataAnnotations().ValidateOnStart()`).
  - Shared model validation across `POST` and `PUT` plus `.NET 11` `IAsyncValidatableObject`.
  - Strongly-typed `TypedResults`, built-in OpenAPI 3.2 (`/openapi/v1.json`), and Scalar UI (**Live Demo: MinimalApiDemo**).
  - **Bonus (2 Slides):** Automating TypeScript models in React/Vite (`openapi-typescript` + `openapi-fetch`) and typed C# clients (`Kiota` / `NSwag`).
- **Module 5: Runtime Engine & Upgrade Summary (Slides 27–30)**
  - .NET 11 CoreCLR Runtime Async (native async suspension, clean stack traces, reduced allocations) and JIT/GC improvements.
  - High-ROI adoption checklist and full demo command reference.

---

## 2. Exact CLI Commands & Runbook

### Viewing & Presenting the Slides
```powershell
# Option 1: Open the pre-compiled standalone HTML directly in any browser:
Start-Process dotnet-11-presentation/slides/index.html

# Option 2: Run live Marp preview on the markdown file:
npx @marp-team/marp-cli --no-stdin dotnet-11-presentation/slides/deck.md --preview

# Option 3: Run Marp server mode on the slides directory:
npx @marp-team/marp-cli -s dotnet-11-presentation/slides --preview
```

### Running the Ordered C# Demo Scripts (`01` to `05`)
Each script includes `#:property LangVersion=preview` at line 1 and runs directly with `dotnet run`:
```powershell
# Demo 01: C# 15 Unions - Domain State Machine & Exhaustive Pattern Matching
dotnet run dotnet-11-presentation/demos/csharp-scripts/01_Unions_DomainState.cs

# Demo 02: C# 15 Unions - Explicit Result Pattern Without Throwing Exceptions
dotnet run dotnet-11-presentation/demos/csharp-scripts/02_Unions_Results.cs

# Demo 03: C# 14 `field` Keyword, Collection Expressions, params ReadOnlySpan<T>, Extension Blocks
dotnet run dotnet-11-presentation/demos/csharp-scripts/03_LanguageFeatures.cs

# Demo 04: Modern LINQ Aggregations (CountBy, AggregateBy with seed: 0m, Index)
dotnet run dotnet-11-presentation/demos/csharp-scripts/04_Linq_Aggregations.cs

# Demo 05: Modern LINQ Joins (LeftJoin & RightJoin on Single and Composite Keys)
dotnet run dotnet-11-presentation/demos/csharp-scripts/05_Linq_Joins.cs
```

### Running the Minimal API Project
```powershell
dotnet run --project dotnet-11-presentation/demos/MinimalApiDemo/MinimalApiDemo.csproj --urls http://localhost:5248
```
- **Interactive Scalar API UI:** Open `http://localhost:5248/scalar/v1` in your browser.
- **Raw OpenAPI 3.2 JSON:** Open `http://localhost:5248/openapi/v1.json`.
- **Testing Endpoints (`POST`, `PUT`, Validation, HybridCache):** Open and run [requests.http](file:///C:/dev/antigravity/whatsnewdotnet11/dotnet-11-presentation/demos/MinimalApiDemo/requests.http).

---

## 3. Under-the-Hood Architectural Deep Dives

### 3.1 C# 15 Union Types (Domain State Machines & Explicit Result Pattern)
- **What is a `union`?** A `union` declares a closed, compiler-enforced set of case types. Unlike class inheritance (where any class can subclass a base type unless you use `abstract` + private constructors), a union restricts the permitted cases to the exact list in the declaration.
- **Two Core Use Cases:**
  1. **Domain State Modeling (`01_Unions_DomainState.cs`):** Modeling states with distinct payloads—e.g., `PaymentState(Pending, Authorized, Captured, Declined, Refunded)`—where `Authorized` carries an `AuthCode` and `Declined` carries a `Reason` without nullable properties that only apply to one state.
  2. **Explicit Service Results (`02_Unions_Results.cs`):** Returning `OrderLookupResult(Found, NotFound, ValidationFailed)` from Dapper repository/service methods instead of throwing custom exceptions for expected business outcomes.
- **Compiler Exhaustiveness:** In a `switch` expression over a union, the compiler verifies that every union case is handled. If someone adds a new case to the union later, every unhandled `switch` produces a compiler warning/error (`CS8509`) before the code ever runs.

---

### 3.2 C# 14 `field` Keyword, Collection Expressions & Extension Blocks
- **The `field` Keyword:** Previously, adding a `.Trim()`, clamping check, or null guard to one property required declaring a manual `private T _backingField;` and writing out both `get` and `set`. With C# 14, `field` accesses the compiler-generated backing field directly inside the `set`/`init`/`get` accessor while keeping the backing field scoped strictly to that property.
- **Collection Expressions (`[.. list]`):** Unifies array, `List<T>`, and `Span<T>` initialization and allows flattening multiple Dapper query lists (`[.. urgentOrders, .. standardOrders]`) in one pre-sized allocation.
- **`params ReadOnlySpan<T>`:** When a method takes `params T[]`, every call allocates a heap array. Changing the signature to `params ReadOnlySpan<T>` lets the compiler stack-allocate the arguments (`stackalloc`), resulting in zero heap allocations at the call site.
- **Extension Blocks (`extension(TargetType)`):** Groups traditional extension methods, **extension properties** (`order.IsHighValue`), and **static extension members** (`OrderRow.Empty`) in one cohesive block.

---

### 3.3 Modern LINQ: `CountBy`, `AggregateBy` (`seed: 0m`), and `Index()`
- **`CountBy` (.NET 9):** Counts occurrences per key in a single pass without allocating intermediate `IGrouping<TKey, TElement>` buckets like `GroupBy(...).Select(...)` does.
- **`AggregateBy` (.NET 9) & `seed: 0m`:**
  - `AggregateBy` maintains a running accumulator per key in a single pass.
  - **What is `seed: 0m`?** `seed` is the starting value of the accumulator for each new key before folding items into it (equivalent to `decimal sum = 0m;` before a loop). The `m` suffix denotes a C# `decimal` literal (`0.00m`), used for financial/currency values to avoid binary floating-point rounding errors.
  - You can also pass a `seedSelector` function (e.g., `key => new RegionSummary(0, 0m)`) when accumulating into a multi-field struct or record.
- **`Index()` (.NET 9):** Yields `(int Index, T Item)` tuples directly in a `foreach` loop, eliminating manual `int i = 0; ... i++` loop counters.

---

### 3.4 LINQ `LeftJoin` & `RightJoin`: Single Key vs. Composite Key Joins
- **Why In-Memory Joins Matter with Dapper:** Stored procedures often return multiple normalized result sets (e.g., `QueryMultipleAsync` returning Orders in result set 1 and Customers/Warehouses in result set 2). Previously, left-joining them in C# required `GroupJoin` + `SelectMany` + `DefaultIfEmpty()`.
- **Single-Key `LeftJoin` (.NET 10):** Preserves every outer (left) element and passes `null` (or `default`) for the inner (right) element when no match exists.
- **Multi-Property (Composite Key) `LeftJoin`:**
  - `LeftJoin` and `RightJoin` support joining on multiple properties by returning an anonymous type or value tuple in both key selectors:
    ```csharp
    orders.LeftJoin(
        warehouses,
        o => new { o.TenantId, o.RegionCode },
        w => new { w.TenantId, w.RegionCode },
        (o, w) => ...
    )
    ```
  - Anonymous types and value tuples implement structural `Equals` and `GetHashCode` across all fields.
- **Limitation:** LINQ joins are hash-based **equi-joins** (equality comparisons only). Non-equality range joins (`a.CreatedAt BETWEEN b.Start AND b.End`) must still be done in SQL or via `.Where()`.

---

### 3.5 `HybridCache`: Stampede Protection & Optional Tag Invalidation
- **The Cache Stampede Problem:** When a hot cache entry expires in `IMemoryCache` or `IDistributedCache`, 50 concurrent API requests see the cache miss simultaneously and fire 50 identical stored procedure calls against SQL Server or Oracle DB.
- **How `HybridCache` Works:**
  1. Provides a unified API over L1 (`IMemoryCache` in-process RAM) and optional L2 (`IDistributedCache` backed by SQL Server, Oracle DB, Redis, or Postgres).
  2. **Request Coalescing (Stampede Protection):** For concurrent callers requesting the same missing key, `HybridCache` executes the factory callback **once** and shares the resulting task across all waiting callers.
- **Are Tags Required?** **No.** Tags (`tags: ["orders"]`) are completely optional. Only pass tags if you need bulk invalidation later via `RemoveByTagAsync("orders")`.

---

### 3.6 Shared Model Validation (`POST` & `PUT`) & `.NET 11` `IAsyncValidatableObject`
- **Why Validate on the Shared Request Model?**
  - Defining DataAnnotations (`[Required]`, `[Range]`, `[RegularExpression]`) and `IValidatableObject` / `IAsyncValidatableObject` on a shared `OrderUpsertModel` means the exact same validation pipeline runs automatically for both `POST /api/orders` (create) and `PUT /api/orders/{id}` (update).
  - Eliminates duplicated `if (req.Quantity <= 0)` checks scattered across endpoints.
- **`.NET 11` `IAsyncValidatableObject`:**
  - Classic `IValidatableObject.Validate(...)` is synchronous, tempting developers to call `.Result` or `.GetAwaiter().GetResult()` when checking database state.
  - `.NET 11` adds `IAsyncValidatableObject.ValidateAsync(ValidationContext, CancellationToken)`, registered via `builder.Services.AddValidation()`, so async database or repository checks run natively before the endpoint handler executes.

---

### 3.7 Bonus: OpenAPI 3.2 Contract Generation for React/Vite & .NET Clients
- **Eliminating Manual DTOs and Hardcoded URLs:** When Minimal APIs use `TypedResults<Ok<OrderDto>, NotFound, ValidationProblem>` and `.WithName("GetCustomerOrders")`, ASP.NET Core emits exact request/response schemas, URL paths, and `operationId` names in `/openapi/v1.json`.
- **React / Vite Workflow:**
  - While `openapi-typescript` only generates a `.d.ts` type dictionary keyed by URL path, full generators like **Hey API (`@hey-api/openapi-ts`)** or **Orval (`orval`)** read both the URL paths and `operationId` from `/openapi/v1.json` and generate **named TypeScript SDK functions** (`await getCustomerOrders({ path: { customerId: 1 } })`) or **React Query hooks** (`useGetCustomerOrders(customerId)`).
  - You never write raw `"/api/customers/..."` path strings or duplicate `interface OrderDto` in React, and renaming a C# DTO property immediately fails `npm run build` (`tsc`).
- **.NET Service-to-Service Workflow:**
  - `<OpenApiReference>` (NSwag), Kiota, or Refit generates strongly-typed C# HTTP clients (`await ordersClient.GetCustomerOrdersAsync(1, ct)`) from the exact same `/openapi/v1.json` spec.

---

### 3.8 Native Runtime Async in .NET 11 CoreCLR
- **Compiler Async (C# 5–14) vs. Runtime Async (.NET 11):**
  - Historically, the Roslyn compiler rewrote every `async` method into a complex state-machine struct (`IAsyncStateMachine.MoveNext()`), which allocated state boxes on heap suspension and polluted exception stack traces with `<MethodName>d__5.MoveNext()`.
  - In .NET 11, CoreCLR understands async methods natively at the runtime/JIT level, managing continuations directly without compiler-emitted state-machine wrappers.
- **Practical Impact for Dapper + Minimal APIs:** Cleaner stack traces in production logs and lower memory allocation overhead across `await connection.QueryAsync(...)` chains.

---

## 4. Anticipated Audience Q&A (With Crisp Answers)

### Q1: "Should we target .NET 10 (LTS) or .NET 11 (STS) since .NET 11 is an odd-numbered release?"
> **Answer:**  
> "Microsoft updated the STS support lifecycle from 18 months to **24 months** starting with .NET 11. Because .NET 10 LTS is supported for 3 years (until November 14, 2028) and .NET 11 STS is supported for 2 years from November 2026 (also until **November 14, 2028**), both releases have the exact same end-of-support date. Adopting .NET 11 gives us C# 15 Unions, `IAsyncValidatableObject`, and Runtime Async with no support-window penalty."

### Q2: "Can we join on multiple columns using LINQ `LeftJoin`?"
> **Answer:**  
> "Yes. You pass an anonymous type or value tuple in both key selectors—for example `o => new { o.TenantId, o.RegionCode }` and `w => new { w.TenantId, w.RegionCode }`. C# anonymous types and tuples implement structural equality and hash codes across all properties. The only restriction is that LINQ joins are equi-joins (equality matches), not range joins."

### Q3: "What does `seed: 0m` mean in `AggregateBy`?"
> **Answer:**  
> "`seed` is the initial value of the accumulator created the first time a key is encountered—just like writing `decimal total = 0m;` before a `foreach` loop. The `m` suffix is C#'s literal for `decimal`, which we use for currency calculations to avoid floating-point precision issues."

### Q4: "Do we need Redis or tags to use `HybridCache`?"
> **Answer:**  
> "Neither is required. Out of the box, `HybridCache` gives you in-memory L1 caching plus automatic stampede protection (request coalescing) so 50 concurrent cache misses only trigger 1 SQL/Oracle query. If you want an L2 cache, you can back `IDistributedCache` with SQL Server or Oracle DB. And tags are completely optional—only pass them if you need group invalidation via `RemoveByTagAsync`."

### Q5: "Why do we discourage Primary Constructors on DI Service classes?"
> **Answer:**  
> "On `record` DTOs and union case types, primary constructors are great because record properties are `init`-only by default. On regular `class` services, however, primary constructor parameters are captured as ordinary **mutable** private fields—you cannot mark them `readonly`, and any method in the class can accidentally reassign `_db = null!`. For DI services, explicit `private readonly` fields remain safer."

---

## 5. Slide-by-Slide Cheat Sheet & Demo Callouts (Slides 1–30)

| Slide | Module | Title | Key Talking Point / Live Demo Action |
|:---:|:---|:---|:---|
| **1** | Intro | Title Slide | Set the technical scope: .NET 8 -> 11 & C# 12 -> 15 for Minimal APIs, Dapper, and React/Vite. |
| **2** | Intro | Agenda & Architectural Scope | Walk through the 5 modules and explain the "Example -> Explanation -> Live Demo" cadence. |
| **3** | Mod 1 | Module 1 Divider | Tooling & Developer Experience (.NET 10 & 11 SDK). |
| **4** | Mod 1 | Lifecycle & Support Policy | Point out the identical **Nov 14, 2028** EOL date for both .NET 10 LTS (36 mo) and .NET 11 STS (24 mo). |
| **5** | Mod 1 | File-Based C# Programs | Show `dotnet run script.cs` with `#:property` and `#:package`—no `.csproj` ceremony needed. |
| **6** | Mod 1 | `.slnx` & SDK Enhancements | Show how `.slnx` replaces GUID-heavy `.sln` files with 5 lines of clean XML. |
| **7** | Mod 2 | Module 2 Divider | C# Language Evolution (C# 12 -> C# 15). |
| **8** | Mod 2 | C# 15 Unions: Domain States | Show `union PaymentState` and compiler-enforced exhaustiveness (`CS8509`). **Run Demo `01_Unions_DomainState.cs`**. |
| **9** | Mod 2 | C# 15 Unions: Explicit Results | Contrast union returns with throwing exceptions (~100x faster, explicit signature). **Run Demo `02_Unions_Results.cs`**. |
| **10** | Mod 2 | C# 14 `field` Keyword | Show inline trimming/clamping inside `set`/`init` without declaring `private T _backingField`. |
| **11** | Mod 2 | Collection Expressions & Span | Show `[.. urgent, .. standard]` spread syntax and zero-allocation `params ReadOnlySpan<T>`. |
| **12** | Mod 2 | C# 14 Extension Blocks | Show `extension(OrderRow)` grouping instance extension properties and static extensions. **Run Demo `03_LanguageFeatures.cs`**. |
| **13** | Mod 2 | Primary Constructors Guidance | Explain why primary constructors are great for records/DTOs but an anti-pattern for DI services (lack of `readonly`). |
| **14** | Mod 3 | Module 3 Divider | Core Libraries, LINQ & Data Shaping. |
| **15** | Mod 3 | LINQ `CountBy` & `AggregateBy` | Explain single-pass aggregation and why `seed: 0m` initializes each key's `decimal` accumulator. |
| **16** | Mod 3 | LINQ Multi-Field & `Index()` | Show `seedSelector` for multi-field summaries and `.Index()` for tuple loop indexing. **Run Demo `04_Linq_Aggregations.cs`**. |
| **17** | Mod 3 | LINQ `LeftJoin` (Single Key) | Compare 8 lines of `GroupJoin + SelectMany + DefaultIfEmpty` vs. 1 clean `LeftJoin` call. |
| **18** | Mod 3 | LINQ Composite Joins & Limits | Show multi-property `new { TenantId, RegionCode }` joins and note the equi-join limitation. **Run Demo `05_Linq_Joins.cs`**. |
| **19** | Mod 3 | `HybridCache` & JSON SourceGen | Explain stampede request coalescing with SQL/Oracle L2 and clarify that tags are optional. |
| **20** | Mod 4 | Module 4 Divider | Minimal APIs, Validation & Contract Generation. |
| **21** | Mod 4 | Options `ValidateOnStart()` | Fail-fast startup validation so missing `appsettings.json` values fail at deploy time, not at 2 AM. |
| **22** | Mod 4 | Shared Model Validation | Show `OrderUpsertModel` validating both `POST` and `PUT` with `.NET 11` `IAsyncValidatableObject`. |
| **23** | Mod 4 | `TypedResults` & OpenAPI 3.2 | Show `Results<Ok<T>, NotFound, ValidationProblem>` feeding `/openapi/v1.json` and Scalar UI. |
| **24** | Mod 4 | Live Demo: MinimalApiDemo | **Run `MinimalApiDemo`**, open Scalar UI (`/scalar/v1`), and execute `requests.http` (`POST`, `PUT`, cache hits). |
| **25** | Mod 4 | Bonus 1: React / Vite OpenAPI | Show `openapi-typescript` + `openapi-fetch` turning C# DTO changes into compile-time TypeScript errors. |
| **26** | Mod 4 | Bonus 2: .NET Client CodeGen | Show `kiota generate` and `NSwag` for service-to-service typed C# HTTP clients. |
| **27** | Mod 5 | Module 5 Divider | Runtime Engine & Upgrade Summary. |
| **28** | Mod 5 | .NET 11 Runtime Async | Explain how CoreCLR native async removes state-machine noise from stack traces and cuts allocations. |
| **29** | Mod 5 | Adoption Checklist | Summarize the highest-ROI features to adopt immediately across our Dapper + Minimal API + React stack. |
| **30** | Mod 5 | Q&A & Command Reference | Leave on screen during Q&A so the team can see all demo commands at a glance. |
