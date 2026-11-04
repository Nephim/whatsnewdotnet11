# Presenter Prep Guide & Architectural Study Sheet
## What's new in .NET 11: Modern .NET Features for Minimal APIs, Dapper & React

> **Audience:** Junior-to-mid-level software engineers looking for practical modern .NET upgrades.  
> **Tech Stack Context:** ASP.NET Core Minimal APIs + **Dapper** calling **SQL / Oracle DB Stored Procedures** + **React (Vite)** frontend.  
> **Scope:** Down-to-earth developer focus on reducing boilerplate, in-memory data shaping, shared model validation, and contract synchronization with React/Vite.

---

## Table of Contents
1. [Presentation Strategy & Slide Flow](#1-presentation-strategy--slide-flow)
2. [Exact CLI Commands & Runbook](#2-exact-cli-commands--runbook)
3. [Under-the-Hood Architectural Explanations](#3-under-the-hood-architectural-explanations)
   * [3.1 C# 15 Union Types (Domain States & Result Pattern)](#31-c-15-union-types-domain-states--result-pattern)
   * [3.2 Semi-Auto Properties & The `field` Keyword](#32-semi-auto-properties--the-field-keyword)
   * [3.3 Modern LINQ: `CountBy`, `AggregateBy`, and `Index`](#33-modern-linq-countby-aggregateby-and-index)
   * [3.4 LINQ `LeftJoin`: Single & Multi-Property Joins](#34-linq-leftjoin-single--multi-property-joins)
   * [3.5 HybridCache: Stampede Protection & Optional Tags](#35-hybridcache-stampede-protection--optional-tags)
   * [3.6 Automating API Contracts: React/Vite & .NET OpenAPI Generation](#36-automating-api-contracts-reactvite--net-openapi-generation)
   * [3.7 Shared Model Validation & Async Checks (.NET 11)](#37-shared-model-validation--async-checks-net-11)
   * [3.8 Runtime Async in .NET 11 CoreCLR](#38-runtime-async-in-net-11-coreclr)
4. [Anticipated Audience Q&A (With Crisp Answers)](#4-anticipated-audience-qa-with-crisp-answers)
5. [Slide-by-Slide Cheat Sheet & Demo Guide](#5-slide-by-slide-cheat-sheet--demo-guide)

---

## 1. Presentation Strategy & Slide Flow

The slide deck (`slides/deck.md`) is designed in **Marp format** in clean, high-contrast **light mode** (optimal for big conference screens and projectors). All bullet points appear immediately upon opening each slide (no distracting click-to-reveal animations).

### Presentation Structure (20 Slides):
* **Slides 1–5: Tooling & Setup**
  * Practical title and stack alignment.
  * Microsoft's 2-year STS policy (showing why .NET 11 has the same Nov 2028 end-of-support as .NET 10 LTS).
  * Single-file C# apps (`dotnet run script.cs`) and `.slnx` XML solution files.
* **Slides 6–10: C# Language Features**
  * C# 15 Union types for domain state machines.
  * C# 15 Union types for explicit result returns (avoiding exceptions).
  * The `field` keyword for semi-auto properties.
  * Collection expressions `[.. list]` and `params ReadOnlySpan<T>`.
  * Architecture guideline: Why we avoid primary constructors in DI classes.
* **Slides 11–15: Data Shaping & Libraries**
  * LINQ `CountBy`, `AggregateBy` (explaining `seed: 0m`), and `Index()`.
  * LINQ `LeftJoin` (single key and composite keys).
  * `HybridCache` with database backend (SQL / Oracle DB) and optional tags.
  * System.Text.Json source generation.
  * **Bonus:** OpenAPI client & model generation in React/Vite and .NET.
* **Slides 16–18: APIs & Runtime**
  * Shared model-level validation (reusing rules across `POST` and `PUT`).
  * Minimal APIs: `TypedResults` and built-in OpenAPI 3.2.
  * Native Runtime Async in .NET 11 CoreCLR.
* **Slides 19–20: Takeaways & Discussion**
  * Practical summary of what to adopt immediately.
  * Open discussion and demo commands.

---

## 2. Exact CLI Commands & Runbook

### Viewing & Presenting the Slides
```powershell
# Option 1: Open the pre-compiled standalone HTML directly in any browser:
Start-Process dotnet-11-presentation/slides/index.html

# Option 2: Run live Marp preview on the markdown file:
npx @marp-team/marp-cli dotnet-11-presentation/slides/deck.md --preview

# Option 3: Run Marp server mode on the directory:
npx @marp-team/marp-cli -s dotnet-11-presentation/slides --preview
```

### Running the C# Demo Scripts
All demo scripts are self-contained and run on .NET 11:
```powershell
# Demo 01: C# 15 Unions - Domain State Machine
dotnet run dotnet-11-presentation/demos/csharp-scripts/01_Unions_Basics.cs -p:LangVersion=preview

# Demo 02: C# 15 Unions - Result Pattern Without Exceptions
dotnet run dotnet-11-presentation/demos/csharp-scripts/02_Unions_Results.cs -p:LangVersion=preview

# Demo 03: Semi-Auto Properties with `field` (C# 14)
dotnet run dotnet-11-presentation/demos/csharp-scripts/03_Field_Keyword.cs -p:LangVersion=preview

# Demo 04: Collection Expressions & params ReadOnlySpan<T>
dotnet run dotnet-11-presentation/demos/csharp-scripts/04_Collection_Expressions.cs -p:LangVersion=preview

# Demo 05: Modern LINQ Aggregations (CountBy, AggregateBy, Index)
dotnet run dotnet-11-presentation/demos/csharp-scripts/05_Linq_Aggregations.cs -p:LangVersion=preview

# Demo 06: Modern LINQ LeftJoin (Single & Composite Keys)
dotnet run dotnet-11-presentation/demos/csharp-scripts/06_Linq_LeftJoin.cs -p:LangVersion=preview
```

### Running the Minimal API Project
```powershell
dotnet run --project dotnet-11-presentation/demos/MinimalApiDemo/MinimalApiDemo.csproj --urls http://localhost:5248
```
* **Interactive Scalar Docs:** Open `http://localhost:5248/scalar/v1` in your browser.
* **Raw OpenAPI 3.2 JSON:** Open `http://localhost:5248/openapi/v1.json`.
* **Testing Endpoints:** Execute requests in `dotnet-11-presentation/demos/MinimalApiDemo/requests.http`.

---

## 3. Under-the-Hood Architectural Explanations

### 3.1 C# 15 Union Types (Domain States & Result Pattern)
* **What is a union?** A `union` represents a closed set of permitted types. Unlike traditional object inheritance where any class in any assembly can derive from a base class, a union declaration strictly bounds the possible types.
* **Use Cases Beyond Results:**
  1. **Domain State Machines:** E.g., `OrderState(Pending, Shipped, Delivered, Cancelled)`.
  2. **Event Types:** In event-driven or messaging workflows, representing specific message payloads.
  3. **Operation Results:** `OrderResult(Success, NotFound, ValidationError)` without throwing exceptions.
* **Compiler Exhaustiveness:** In a `switch` expression, the C# compiler verifies that every case is handled. If a developer adds a new state tomorrow, unhandled switches fail to compile, preventing runtime bugs.

---

### 3.2 Semi-Auto Properties & The `field` Keyword
* **The Problem:** In C# 1 through 13, if you wanted to sanitize, trim, or validate a property, you had to declare a manual backing field:
  ```csharp
  private string _sku = string.Empty;
  public string Sku { get => _sku; set => _sku = value.Trim(); }
  ```
* **C# 14 Solution:** The contextual keyword `field` gives you direct access to the compiler-synthesized backing store inside the accessor body:
  ```csharp
  public string Sku { get => field; set => field = value.Trim(); } = string.Empty;
  ```

---

### 3.3 Modern LINQ: `CountBy`, `AggregateBy`, and `Index`
* **`CountBy` (.NET 9):** Counts occurrences of keys directly in a single pass without allocating `IGrouping<TKey, TElement>` buckets.
* **`AggregateBy` (.NET 9):**
  * Performs running accumulation per key.
  * **What is `seed: 0m`?** `seed` is the initial starting value of the accumulator for each key before processing items. `0m` is simply the C# literal for `decimal` zero (used for financial calculations to prevent floating point inaccuracies).
* **`Index()` (.NET 9):**
  * When you need the zero-based index of an item alongside the item itself, `Index()` yields `(int Index, TSource Item)`.
  * Eliminates the need to maintain a separate `int i = 0; i++` counter outside of `foreach` loops.

---

### 3.4 LINQ `LeftJoin`: Single & Multi-Property Joins
* **How `LeftJoin` Works (.NET 10):**
  Includes all items from the left (outer) sequence. If no matching item exists in the right (inner) sequence, the right element evaluates to `null` (or `default(T)`).
* **Can it join on multiple properties?** **YES!**
  Just like standard LINQ `Join`, you match on an anonymous type or tuple:
  ```csharp
  var result = orders.LeftJoin(
      catalog,
      order => new { order.TenantId, order.Sku },
      prod  => new { prod.TenantId, prod.Sku },
      (order, prod) => new { order.OrderId, Title = prod?.Title ?? "Uncataloged" }
  );
  ```
* **What can it NOT do?**
  LINQ joins are **equi-joins** (matching on equality of keys). They cannot perform arbitrary non-equality joins (like SQL `ON a.Date BETWEEN b.Start AND b.End`). For non-equality conditions, perform the join in the SQL stored procedure or use `.Where()` in memory.

---

### 3.5 HybridCache: Stampede Protection & Optional Tags
* **The Problem (Cache Stampede):** When a hot cache key expires in an ordinary `IMemoryCache`, 50 simultaneous web requests will all query the underlying SQL or Oracle DB at the same millisecond.
* **How `HybridCache` Solves It:**
  1. Combines local fast RAM (L1) with an external store (L2, such as SQL, Oracle DB, or distributed cache).
  2. Implements **request coalescing / atomic locking**: only one request executes the factory database query; other concurrent callers wait and share the resulting data.
* **Tags are Optional:** Tagging (`tags: [$"customer-{id}"]`) is completely optional. You only provide tags if you plan to invalidate groups of related keys at once via `RemoveByTagAsync`.

---

### 3.6 Automating API Contracts: React/Vite & .NET OpenAPI Generation
* **The Problem:** Backend developers write C# DTOs, and frontend React developers manually recreate TypeScript interfaces. When a property name or type changes, bugs slip through until runtime.
* **The Modern Workflow:**
  1. ASP.NET Core natively produces the OpenAPI 3.2 document at `/openapi/v1.json`.
  2. In React/Vite: Run `openapi-typescript` to automatically generate TypeScript definitions:
     ```bash
     npx openapi-typescript http://localhost:5248/openapi/v1.json -o src/api/schema.d.ts
     ```
  3. React fetch clients use these types. If backend changes `CustomerId` to `ClientId`, TypeScript fails during frontend build!
  4. In .NET: Tools like Microsoft Kiota or NSwag generate typed client classes for external service consumers.

---

### 3.7 Shared Model Validation & Async Checks (.NET 11)
* **Why Put Validation on the Model?**
  * Placing validation rules (`[Required]`, `[Range]`, `IAsyncValidatableObject`) on the request model means the exact same rules validate both `POST` (create), `PUT` (update), and programmatic assignments.
  * Eliminates duplicate validation code across endpoints.
* **.NET 11 `IAsyncValidatableObject`:**
  * Allows performing asynchronous checks (such as verifying that a customer exists in the database) without blocking thread-pool threads with `.Result` or `.Wait()`.

---

### 3.8 Runtime Async in .NET 11 CoreCLR
* **The Architecture Change:**
  * For over a decade, `async`/`await` in C# was lowered by the Roslyn compiler into a bulky state-machine struct/class implementing `IAsyncStateMachine`.
  * In .NET 11, the CoreCLR runtime engine itself natively manages async frame suspension and resumption.
* **Everyday Benefits:**
  * **Clean stack traces:** Exception traces point directly to your actual code lines instead of cryptic `<GetOrderAsync>d__1.MoveNext()`.
  * **Lower allocation overhead:** Reduces GC allocation pressure on every `await connection.QueryAsync()` call.

---

## 4. Anticipated Audience Q&A (With Crisp Answers)

### Q1: "Can we join on multiple columns using LINQ `LeftJoin`?"
> **Answer:**  
> "Yes, absolutely. You use anonymous types or tuples for the key selectors on both sides, for example: `order => new { order.TenantId, order.Sku }` and `prod => new { prod.TenantId, prod.Sku }`. C# anonymous types implement value equality, so LINQ matches them across all properties."

---

### Q2: "What is the `seed: 0m` in `AggregateBy`?"
> **Answer:**  
> "`seed` is just the starting accumulator value for each key before adding items, exactly like initializing `decimal total = 0m;` before a loop. The `m` suffix specifies a C# `decimal` literal, which is standard for currency calculations to prevent floating point rounding errors."

---

### Q3: "Why use C# 15 Unions instead of throwing exceptions for missing records?"
> **Answer:**  
> "Throwing an exception for an expected business outcome like 'Order not found' forces the CLR to capture an OS stack trace, which is ~100x slower than returning a value. Furthermore, exceptions hide return branches from the method signature. Unions make all expected outcomes explicit in the method signature, and the compiler guarantees that callers handle every case."

---

### Q4: "Do we have to use tags with `HybridCache`?"
> **Answer:**  
> "No, tags are completely optional. If you just call `GetOrCreateAsync(key, factory)`, you get full cache stampede protection and two-tier caching. Tags are only needed if you want the ability to invalidate a group of related cache keys in a single call (e.g. `RemoveByTagAsync('customer-101')`)."

---

### Q5: "How does OpenAPI client generation help our React/Vite frontend?"
> **Answer:**  
> "Currently, frontend developers manually create TypeScript interfaces that mirror our C# DTOs. When a backend property is renamed, the mismatch isn't discovered until runtime. By using `openapi-typescript` in Vite, TypeScript models are generated directly from `/openapi/v1.json`. If backend models change, the React build fails immediately, catching breaking changes before deployment."

---

## 5. Slide-by-Slide Cheat Sheet & Demo Guide

| Slide # | Title / Topic | Presenter Cue / Talking Point | Embedded Demo Callout |
|:---:|:---|:---|:---|
| **1–2** | Title & Roadmap | Down to earth: reducing boilerplate and simplifying code. | N/A |
| **3** | Lifecycle & Support | STS is now 2 years: .NET 11 has the same Nov 2028 EOL as .NET 10 LTS. | N/A |
| **4** | Single-File C# Apps | `dotnet run script.cs` — great for quick utilities and test harnesses. | N/A |
| **5** | `.slnx` & Visual Studio | Clean XML solution format; solves merge conflicts. VS Hot Reload. | N/A |
| **6** | C# 15 Unions: Overview | Closed set of types; domain state machines; exhaustive `switch`. | N/A |
| **7** | C# 15 Unions: Results | Explicit results without throwing exceptions. | **Run `01_Unions_Basics.cs` & `02_Unions_Results.cs`** |
| **8** | The `field` Keyword | Semi-auto properties: sanitize and validate without backing fields. | **Run `03_Field_Keyword.cs`** |
| **9** | Collection Expressions | `[.. list]` spread syntax; `params ReadOnlySpan<T>`. | **Run `04_Collection_Expressions.cs`** |
| **10** | Primary Constructor Note| Anti-pattern in DI services (parameters remain mutable). | N/A |
| **11** | LINQ Aggregations | `CountBy`, `AggregateBy` (seed = 0m), and `Index()`. | **Run `05_Linq_Aggregations.cs`** |
| **12** | LINQ `LeftJoin` | Single key and composite key (`new { ... }`) joins in memory. | **Run `06_Linq_LeftJoin.cs`** |
| **13** | `HybridCache` | Solves cache stampedes with DB store; tags are optional. | N/A |
| **14** | System.Text.Json | JSON Source Generation: compile-time verification & faster startup. | N/A |
| **15** | OpenAPI Automation | Generating TypeScript types for React/Vite from `/openapi/v1.json`. | N/A |
| **16** | Shared Model Validation | Model validation works for both POST (insert) and PUT (update). | N/A |
| **17** | TypedResults & OpenAPI | Strongly-typed status responses; Scalar UI docs. | **Run `MinimalApiDemo` + `requests.http`** |
| **18** | Runtime Async | Native CoreCLR async: clean stack traces, lower allocations. | N/A |
| **19–20**| Takeaways & Q&A | Practical summary of what to use today. Open discussion. | N/A |
