# 03-upgrade-data-and-test-projects-to-net10: upgrade-data-and-test-projects-to-net10

Upgrade remaining data-access and test projects to `net10.0`, completing the solution-wide target framework transition. Scope includes `Sem.Data.SprocAccess*` projects and all test projects so framework, package references, and test infrastructure align to .NET 10 across the repo.

Assessment context: the largest API issue concentration is in `Sem.Data.SprocAccess.SqlServer`, and package recommendations include .NET 10-stable alignment for selected `System.*` packages. This task completes those changes with minimal code churn.

**Done when**: all remaining projects (including tests) target `net10.0` and compile with API/package updates applied as needed.

## Scope Inventory

### Remaining projects requiring TFM update
- `Sem.Data.SprocAccess/Sem.Data.SprocAccess.csproj`
- `Sem.Data.SprocAccess.FileSystem/Sem.Data.SprocAccess.FileSystem.csproj`
- `Sem.Data.SprocAccess.SqlServer/Sem.Data.SprocAccess.SqlServer.csproj`
- `Sem.Data.SprocAccess.MicrosoftSqlServer/Sem.Data.SprocAccess.MicrosoftSqlServer.csproj`
- `Sem.Data.SprocAccess.FileSystemTests/Sem.Data.SprocAccess.FileSystemTests.csproj`
- `Sem.Data.SprocAccess.IntegrationTests/Sem.Data.SprocAccess.IntegrationTests.csproj`
- `Sem.Tools.CmdLine.TestProject/Sem.Tools.CmdLine.TestProject.csproj`
- `Sem.Tools.CmdLine.Tests/Sem.Tools.CmdLine.Tests.csproj`
- `Sem.Tools.Logging.Tests/Sem.Tools.Logging.Tests.csproj`
- `Sem.Tools.TestHelper.Tests/Sem.Tools.TestHelper.Tests.csproj`
- `Sem.Tools.Tests/Sem.Tools.Tests.csproj`

### Key dependency and risk signals
- Data layer dependency chain: `Sem.Data.SprocAccess` -> provider projects (`SqlServer`, `MicrosoftSqlServer`, `FileSystem`) -> test projects.
- `Sem.Data.SprocAccess.SqlServer` has the highest API issue density (source-compatibility findings around `System.Data.SqlClient` usage).
- `Sem.Data.SprocAccess.IntegrationTests` has one mandatory binary-incompatibility finding (`Api.0001`) plus TFM update requirement.
- Remaining test projects are mostly mechanical TFM updates, but must remain compatible with already-upgraded core projects from Task 02.

## Planned execution
1. Retarget all remaining `net8.0` projects to `net10.0`.
2. Keep package versions centralized in `Directory.Packages.props` and avoid per-project package churn.
3. Build all remaining upgraded projects and address compile issues inline where needed.
4. Leave full-solution final gate to Task 04.
