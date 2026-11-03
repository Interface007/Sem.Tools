# 02-upgrade-consumer-and-core-projects-to-net10: upgrade-consumer-and-core-projects-to-net10

Upgrade the primary consumer/application projects and their directly required core libraries to `net10.0`, applying inline fixes for API findings in this wave. Scope includes `Sem.MdDocGenerator`, `Sem.Tools.CmdLine`, `Sem.Tools`, `Sem.Tools.Logging`, `Sem.Tools.TestHelper`, and any directly coupled dependencies needed to keep these projects compiling and functioning.

Assessment context: API compatibility findings include source/binary/behavior changes concentrated around SQL client and crypto/data-protection related APIs; package upgrade recommendations are limited but should be applied where relevant in this wave.

**Done when**: consumer/application and core dependency projects target `net10.0` and compile with required inline compatibility fixes.

## Scope Inventory

### Projects in scope
- `Sem.MdDocGenerator/Sem.MdDocGenerator.csproj`
- `Sem.Tools.CmdLine/Sem.Tools.CmdLine.csproj`
- `Sem.Tools/Sem.Tools.csproj`
- `Sem.Tools.Logging/Sem.Tools.Logging.csproj`
- `Sem.Tools.TestHelper/Sem.Tools.TestHelper.csproj`

### Dependency signals
- `Sem.MdDocGenerator` references `Sem.Tools.CmdLine` and `Sem.Tools`.
- `Sem.Tools.CmdLine`, `Sem.Tools.Logging`, and `Sem.Tools.TestHelper` each reference `Sem.Tools`.
- `Sem.Tools` is the shared core and must be upgraded in the same wave as its direct consumers.

### Assessment findings used for this task
- All five in-scope projects are SDK-style and currently `net8.0` with mandatory `Project.0002` TFM-change requirement.
- `Sem.Tools` has additional compatibility findings:
  - `Api.0002` around `System.Security.Cryptography.ProtectedData` / `DataProtectionScope` usage in `EncryptionConverter.cs`.
  - `Api.0003` around `System.Text.Json` usage in `InheritanceConverter.cs`.
  - `NuGet.0002` recommendations to align `System.Security.Cryptography.ProtectedData` and `System.Text.Json` to stable net10-compatible versions.
- Other in-scope projects mainly require target framework update and dependency alignment.

## Planned execution
1. Update target frameworks for the five in-scope projects from `net8.0` to `net10.0`.
2. Keep API handling inline: compile and only apply minimal code changes if net10 introduces compile breaks in `Sem.Tools`.
3. Keep package changes minimal and centralized via `Directory.Packages.props`.
4. Validate by building the scoped projects (and then the full solution in final validation task).
