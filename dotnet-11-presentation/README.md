# What's New in .NET 11: Presentation & Demo Suite

A practical, developer-oriented presentation deck, study guide, and executable demo suite covering modern features in **.NET 8, 9, 10, and 11** (C# 12–15).

### Stack & Focus
* **Backend:** ASP.NET Core Minimal APIs + Dapper calling SQL / Oracle DB Stored Procedures
* **Frontend:** React + Vite (TypeScript contracts)
* **Design Philosophy:** Practical code, reducing boilerplate, in-memory data shaping, and API contract automation.

---

## Folder Structure

```
dotnet-11-presentation/
├── PRESENTER_GUIDE.md             # Presenter study guide, Q&A cheat sheet, and talking cues
├── README.md                      # Overview & quick start guide
├── slides/
│   ├── deck.md                    # 20-slide presentation in Marp Markdown format (light theme)
│   └── index.html                 # Standalone pre-compiled HTML slides (open directly in browser)
└── demos/
    ├── csharp-scripts/            # Standalone single-file C# scripts
    │   ├── 01_Unions_Basics.cs           # C# 15 Unions modeling a domain state machine
    │   ├── 02_Unions_Results.cs          # C# 15 Unions for explicit results without exceptions
    │   ├── 03_Field_Keyword.cs           # C# 14 semi-auto properties with 'field'
    │   ├── 04_Collection_Expressions.cs  # Collection expressions [..] and params ReadOnlySpan
    │   ├── 05_Linq_Aggregations.cs       # LINQ CountBy, AggregateBy (seed), and Index()
    │   ├── 06_Linq_LeftJoin.cs           # LINQ LeftJoin on single and composite keys
    │   └── csharp-scripts.csproj         # Project configuration for full IDE IntelliSense
    └── MinimalApiDemo/            # Minimal API Web Project (.slnx)
        ├── MinimalApiDemo.slnx    # XML-simplified solution file
        ├── MinimalApiDemo.csproj  # Target net11.0 with OpenAPI 3.2 & HybridCache
        ├── Program.cs             # Shared model validation, HybridCache, TypedResults, Scalar
        ├── appsettings.json       # Validated configuration options
        └── requests.http          # Executable HTTP requests for live demos
```

---

## Quick Start Runbook

### 1. View / Present the Slides
* **Option A (Standalone HTML - Zero Dependencies):**
  Open `slides/index.html` directly in your browser:
  ```powershell
  Start-Process dotnet-11-presentation/slides/index.html
  ```
* **Option B (Marp Preview):**
  ```bash
  npx @marp-team/marp-cli dotnet-11-presentation/slides/deck.md --preview
  ```

### 2. Run the C# Demo Scripts
```bash
dotnet run dotnet-11-presentation/demos/csharp-scripts/01_Unions_Basics.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/02_Unions_Results.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/03_Field_Keyword.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/04_Collection_Expressions.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/05_Linq_Aggregations.cs -p:LangVersion=preview
dotnet run dotnet-11-presentation/demos/csharp-scripts/06_Linq_LeftJoin.cs -p:LangVersion=preview
```

### 3. Launch Minimal API & Scalar UI
```bash
dotnet run --project dotnet-11-presentation/demos/MinimalApiDemo/MinimalApiDemo.csproj --urls http://localhost:5248
```
* **Scalar API UI:** Open `http://localhost:5248/scalar/v1` in your browser.
* **Fire Requests:** Execute requests in `dotnet-11-presentation/demos/MinimalApiDemo/requests.http`.

---

For in-depth architectural explanations, anticipated team questions, and slide-by-slide cues, see [PRESENTER_GUIDE.md](file:///C:/dev/antigravity/whatsnewdotnet11/dotnet-11-presentation/PRESENTER_GUIDE.md).
