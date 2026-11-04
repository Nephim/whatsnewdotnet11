# What's New in .NET 11: Presentation & Demo Suite

A technical presentation deck, presenter study guide, and executable demo suite covering modern features across **.NET 8, 9, 10, and 11** (C# 12–15).

### Stack & Architectural Context
- **Backend:** ASP.NET Core Minimal APIs + Dapper calling SQL / Oracle DB Stored Procedures
- **Frontend:** React + Vite (TypeScript)
- **Focus:** Reducing boilerplate, in-memory data shaping with modern LINQ, explicit domain/result modeling with C# 15 unions, shared API validation, and OpenAPI 3.2 contract generation.

---

## Folder Structure

```
dotnet-11-presentation/
├── PRESENTER_GUIDE.md             # Presenter study guide, architectural notes, Q&A, and slide-by-slide cues
├── README.md                      # Overview & quick start runbook
├── slides/
│   ├── deck.md                    # 30-slide presentation in Marp Markdown format (5 modules, light theme)
│   ├── index.html                 # Standalone pre-compiled HTML slides (open directly in browser)
│   └── deck.html                  # Pre-compiled HTML slides copy
└── demos/
    ├── csharp-scripts/            # Ordered standalone single-file C# 15 scripts (run via `dotnet run <file>.cs`)
    │   ├── 01_Unions_DomainState.cs      # C# 15 Unions modeling a closed domain state machine
    │   ├── 02_Unions_Results.cs          # C# 15 Unions for explicit results without throwing exceptions
    │   ├── 03_LanguageFeatures.cs        # `field` keyword, collection expressions [..], params ReadOnlySpan<T>, extension blocks
    │   ├── 04_Linq_Aggregations.cs       # LINQ CountBy, AggregateBy (seed explained), and Index()
    │   └── 05_Linq_Joins.cs              # LINQ LeftJoin & RightJoin (single key and composite keys)
    └── MinimalApiDemo/            # Minimal API Web Project (.slnx)
        ├── MinimalApiDemo.slnx    # XML-based solution file
        ├── MinimalApiDemo.csproj  # Targets net11.0 with OpenAPI 3.2, Scalar, and HybridCache
        ├── Program.cs             # ValidateOnStart, HybridCache, shared POST/PUT model validation, TypedResults
        ├── appsettings.json       # Validated configuration options
        └── requests.http          # Executable HTTP requests for live demos
```

---

## Quick Start Runbook

### 1. View / Present the Slides
- **Option A (Standalone HTML — Zero Dependencies):**
  Open `slides/index.html` directly in your browser:
  ```powershell
  Start-Process dotnet-11-presentation/slides/index.html
  ```
- **Option B (Marp CLI Live Preview):**
  ```powershell
  npx @marp-team/marp-cli --no-stdin dotnet-11-presentation/slides/deck.md --preview
  ```
- **Option C (Marp CLI Server Mode on Directory):**
  ```powershell
  npx @marp-team/marp-cli -s dotnet-11-presentation/slides --preview
  ```

### 2. Run the C# Demo Scripts (Ordered `01` to `05`)
Each script uses `#:property LangVersion=preview` at the top of the file, so it runs directly with `dotnet run`:
```powershell
dotnet run dotnet-11-presentation/demos/csharp-scripts/01_Unions_DomainState.cs
dotnet run dotnet-11-presentation/demos/csharp-scripts/02_Unions_Results.cs
dotnet run dotnet-11-presentation/demos/csharp-scripts/03_LanguageFeatures.cs
dotnet run dotnet-11-presentation/demos/csharp-scripts/04_Linq_Aggregations.cs
dotnet run dotnet-11-presentation/demos/csharp-scripts/05_Linq_Joins.cs
```

### 3. Launch Minimal API & Scalar UI
```powershell
dotnet run --project dotnet-11-presentation/demos/MinimalApiDemo/MinimalApiDemo.csproj --urls http://localhost:5248
```
- **Scalar API UI:** Open `http://localhost:5248/scalar/v1` in your browser.
- **OpenAPI 3.2 Spec:** Open `http://localhost:5248/openapi/v1.json`.
- **Fire Requests:** Execute requests in `dotnet-11-presentation/demos/MinimalApiDemo/requests.http`.

---

For deep-dive architectural explanations, anticipated Q&A, and slide-by-slide cues, see [PRESENTER_GUIDE.md](file:///C:/dev/antigravity/whatsnewdotnet11/dotnet-11-presentation/PRESENTER_GUIDE.md).
