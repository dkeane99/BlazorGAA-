# Touchdown Fantasy 🏈

A polished fantasy American football league dashboard built with **C#**, **ASP.NET Core Blazor Interactive Server**, and **.NET 8**. Designed as a portfolio-ready Visual Studio solution for demonstrating component-based UI, dependency injection, LINQ filtering/sorting, domain models, and unit testing.

> **Important:** This repository uses fictional/sample fantasy data for demonstration. It does not connect to live NFL stats, implement authentication, or persist roster changes. Do not represent its projections or schedule as real-time data.

## Highlights

- Responsive front-office dashboard with season KPIs and projected lineup
- Roster overview with calculated starter projections
- Searchable/filterable/sortable player pool
- Head-to-head matchup comparison view
- League standings with points-for/against and streak indicators
- Insights page with a pragmatic production-readiness roadmap
- Centralized demo data service registered through dependency injection
- Unit tests for roster, projections, standings, and budget invariants
- Custom responsive CSS, navigation, and empty states

## Tech stack

- C# / .NET 8
- ASP.NET Core Blazor Web App, Interactive Server render mode
- Razor components
- xUnit
- Visual Studio 2022 or newer / .NET 8 SDK

## Run locally

1. Install the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
2. Clone the repository.
3. Open `TouchdownFantasy.sln` in Visual Studio.
4. Restore NuGet packages.
5. Set `TouchdownFantasy.Web` as the startup project and press **F5**.

Or use the CLI from the repository root:

```bash
dotnet restore TouchdownFantasy.sln
dotnet run --project src/TouchdownFantasy.Web
```

Open the HTTPS/HTTP URL printed by the application.

Run tests:

```bash
dotnet test TouchdownFantasy.sln
```

## Solution layout

```text
TouchdownFantasy/
├── TouchdownFantasy.sln
├── src/
│   └── TouchdownFantasy.Web/
│       ├── Components/
│       │   ├── Layout/
│       │   └── Pages/
│       ├── Models/
│       ├── Services/
│       ├── wwwroot/
│       ├── Program.cs
│       └── TouchdownFantasy.Web.csproj
└── tests/
    └── TouchdownFantasy.Tests/
```

## Architecture notes

- **Models:** small immutable records for players, roster slots, matchup teams, and standings.
- **Service layer:** `FantasyLeagueService` exposes a single, injectable source of demo data and computed projections.
- **UI:** pages are separate Razor components and share a navigation layout.
- **Tests:** xUnit checks core invariants without requiring a running web server.

## Suggested next iterations

1. Add EF Core and SQL Server/PostgreSQL persistence, with migrations.
2. Add authentication and per-league authorization.
3. Add repository/service interfaces and integration tests.
4. Integrate a licensed sports data API through `HttpClient`, with caching and rate-limit handling.
5. Implement lineup edits, waiver claims, trades, scoring settings, and league invitations.
6. Add GitHub Actions for restore, build, test, formatting, and dependency scanning.
7. Add structured logging, health checks, and configuration via user secrets/environment variables.

## GitHub setup

```bash
git init
git add .
git commit -m "Initial Touchdown Fantasy Blazor app"
git branch -M main
git remote add origin https://github.com/YOUR-USERNAME/TouchdownFantasy.git
git push -u origin main
```

## License

Choose a license before publishing if you want others to reuse or contribute to the project.
