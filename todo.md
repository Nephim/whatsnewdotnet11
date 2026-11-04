# Role & Objective
You are an expert .NET Architect and Developer Advocate. Your task is to build a modular presentation, a Presenter Prep Guide, and runnable demo code covering the best features of **.NET 11** alongside high-impact features from **.NET 8, 9, and 10**. 

First, fetch and read the live Microsoft documentation starting at:
`https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview`
Follow and inspect all linked sub-pages (C# 15, .NET 11 SDK, Runtime, Libraries, and ASP.NET Core 11) so all examples use accurate syntax and APIs.

---

# Audience & Tech Stack Context (Crucial)
* **Audience:** Junior-to-mid-level software engineers who haven't fully explored modern .NET features.
* **Current Environment:** Running a mix of .NET 6, .NET 8, and .NET 10 in production, planning to standardize and upgrade.
* **Tech Stack:** 
  * **Backend:** ASP.NET Core Minimal APIs (with Options Pattern) + **Dapper** calling **SQL Stored Procedures**.
  * **Frontend:** React built with **Vite**.
* **Strict Filtering Rules:**
  * **DO NOT INCLUDE:** Entity Framework Core (EF Core), Blazor, .NET MAUI, or Razor Pages (irrelevant to our stack).
  * **DO NOT INCLUDE Primary Constructors (C# 12):** Skip them completely, or only mention them briefly as an anti-pattern for DI because captured parameters cannot be marked `readonly` and remain mutable.
  * **DO FOCUS ON:** Features that improve Minimal APIs, shape in-memory `IEnumerable<T>` data returned from Dapper stored procedures, serialize cleanly to a React/TypeScript frontend, reduce boilerplate, and boost runtime performance.

---

# Thematic Structure (Modular for Splitting/Skipping)
Organize the presentation and demos by **Domain Area** (NOT chronologically by version). Clearly badge every slide/feature with the version it arrived in (`[.NET 8]`, `[.NET 9]`, `[.NET 10]`, `[.NET 11]`) so the team sees what they can use today vs. after upgrading. 

Design the deck in **5 self-contained modules** so it can be presented as a single 60-minute deep dive or easily split into Part 1 & Part 2 (or have individual slides commented out):

### Module 1: The Upgrade Landscape & Tooling (.NET SDK & CLI)
* **Lifecycle urgency:** .NET 6 is out of support, and both .NET 8 (LTS) and .NET 9 (STS) hit End of Support in November 2026—making .NET 10 (LTS) and .NET 11 (STS) critical.
* **File-based C# Apps (`dotnet run file.cs`):** Introduced in .NET 10 and enhanced in .NET 11 (great for quick utility scripts and our C# demos).
* **SDK & CLI Improvements:** `dotnet watch` hot reload updates, interactive CLI selection (`dotnet run`), terminal logger, and `.slnx` (XML-simplified solution files).

### Module 2: Modern C# Language (C# 12–15)
* **C# 15 Union Types (`.NET 11`):** Deep dive into `union` types and exhaustive `switch` expressions. Show how to return clean `Result` unions (e.g., `Success | NotFound | ValidationError`) from a Dapper repository layer up to a Minimal API without throwing exceptions.
* **The `field` Keyword (`C# 14 / .NET 10`):** Semi-auto properties without explicit backing fields.
* **Collection Expressions (`[.. list]`) & `params ReadOnlySpan<T>` (`C# 12–15`):** Clean syntax + zero-allocation `params` calls.
* **Collection Expression Arguments (`C# 15 / .NET 11`):** Passing capacity or comparers directly inside `[with(capacity: 10), ...]`.
* **Null-Conditional Assignment (`?.=` in `C# 14`) & Extension Blocks (`extension(T)`):** Modern quality-of-life improvements.

### Module 3: Data Shaping & Libraries (The Post-Dapper Powerhouse)
*Frame this around manipulating flat result sets returned by Dapper stored procedures in memory:*
* **All Modern LINQ Methods:**
  * `.NET 9`: `CountBy`, `AggregateBy`, `Index` (tuple indexing without manual counters).
  * `.NET 10`: `LeftJoin`, `RightJoin` (doing in-memory joins when joining two stored proc outputs).
  * `.NET 11`: `FullJoin` and tuple-returning `Join` / `GroupJoin` overloads.
* **System.Text.Json for React/Vite:**
  * C# 15 Union serialization support (`JsonUnionPolymorphism` / clean JSON contracts for TypeScript).
  * Strict JSON serialization options, `JsonSourceGeneration` for speed, and `PipeReader` support.
* **Caching Stored Proc Results:** `HybridCache` (`.NET 9–11`)—solving cache stampedes with L1/L2 caching in 3 lines of code.
* **Time & Identifiers:** `TimeProvider` (testable time in services) and `Guid.CreateVersion7()` (`.NET 9`—database-index-friendly sequential GUIDs).

### Module 4: ASP.NET Core & Minimal APIs (.NET 8–11)
* **Built-in Minimal API Validation (`.NET 10 & 11`):** `[ValidatableType]` and the new `.NET 11` **`IAsyncValidatableObject`** for async request validation in Minimal APIs.
* **TypedResults & Union Endpoints:** Returning strongly-typed multi-status responses so OpenAPI generates exact schemas for the React frontend.
* **OpenAPI 3.1 / 3.2 Built-in Support (`.NET 9–11`):** Dropping Swashbuckle, generating OpenAPI schemas natively, binary file response schemas in .NET 11, and pairing with Scalar/Swagger UI.
* **Options Pattern Enhancements:** `[ValidateObjectMembers]`, `[ValidateEnumeratedItems]`, and source-generated `IValidateOptions<T>` on startup (`ValidateOnStart()`).
* **Pipeline & Performance:** `[ShortCircuit]` route attributes, `IExceptionHandler`, Output Caching, and **Zstandard (`zstd`) compression** in .NET 11.

### Module 5: Under-the-Hood Runtime Performance (.NET 8–11)
* **Runtime Async (`.NET 11`):** Explain how the CoreCLR runtime now natively understands `async` methods (replacing compiler-generated state machine overhead), giving faster `await` execution, fewer allocations on every `connection.QueryAsync()`, and dramatically cleaner stack traces.
* **Dynamic PGO & DATAS GC:** How upgrading from .NET 6/8 to 10/11 automatically shrinks memory footprints (DATAS enabled by default) and optimizes hot code paths.
* **Zero-Allocation Primitives:** `SearchValues<T>` and Span/FrozenDictionary improvements (`FrozenDictionary<TKey, TValue>` for read-heavy lookup caches).

---

# Deliverables Required

Please generate the following inside a structured folder (`dotnet-11-presentation/`):

### 1. Presenter Prep & Cheat Sheet (`PRESENTER_GUIDE.md`)
Before I present, I want to get deeply acquainted with the material. Create a study guide for me that includes:
* A quick architectural explanation of *how* each feature works under the hood (especially Runtime Async, C# 15 Unions, and Minimal API source generators).
* Likely questions my team will ask (e.g., *"Why use C# Unions instead of throwing exceptions?"* or *"When should we use LINQ `LeftJoin` in C# vs doing it in the SQL stored proc?"*) with crisp answers.
* Exact CLI commands to run the slide deck and each demo.

### 2. Markdown Slide Deck (`slides/deck.md`)
* Use **Marp** (or **Slidev**) Markdown format with a clean, dark-mode developer theme and native C# syntax highlighting.
* Keep slide text concise and high-impact: use **"Before vs. After"** code comparisons right on the slides.
* **Speaker Notes:** Include HTML comments (`<!-- ... -->`) on **every single slide** containing **concise bullet-point talking cues** (no walls of text/scripts—I adapt on the fly and need quick bullet prompts to lean on, plus callouts for when to switch to a demo).
* Add clear section divider comments so I can easily comment out a slide or split the deck into Part 1 and Part 2.

### 3. Hybrid Demo Suite (`demos/`)
Feel free to check/update my `.NET CLI` environment if needed. Build two types of demos:
* **`demos/csharp-scripts/` (VS Code Single-File Scripts):**
  * Self-contained `.cs` files executable via `dotnet run <file>.cs` (or small runner projects if a preview feature flag `<LangVersion>preview</LangVersion>` is required).
  * `01_Unions.cs`: C# 15 Unions modeling a Dapper service outcome.
  * `02_LinqPowerhouse.cs`: Mocked flat Dapper records transformed using `CountBy`, `AggregateBy`, `Index`, `LeftJoin`, and `.NET 11` `FullJoin`.
  * `03_LanguageNiceties.cs`: `field` keyword, collection expressions, and `Guid.CreateVersion7()`.
* **`demos/MinimalApiDemo/` (Visual Studio / `.slnx` Web API Project):**
  * A clean Minimal API project (no live database required—use a mocked `DapperOrderRepository` that returns realistic `Task<IEnumerable<OrderDto>>` data).
  * Demonstrate: Options pattern with `ValidateOnStart()`, Minimal API endpoints with `.NET 11` `IAsyncValidatableObject`, `HybridCache` wrapping the repository call, `TypedResults`, and built-in OpenAPI 3.2.
  * Include a `requests.http` file so I can fire requests directly from Visual Studio or VS Code during the talk.