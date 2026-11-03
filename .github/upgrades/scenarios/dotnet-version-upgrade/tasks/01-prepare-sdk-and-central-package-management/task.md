# 01-prepare-sdk-and-central-package-management: prepare-sdk-and-central-package-management

Verify toolchain readiness for .NET 10 and establish central package management in a minimal, low-churn way. This task covers confirming `global.json`/SDK alignment (if present), adding central package configuration if needed, and preparing shared settings so all projects can move to a consistent target framework without per-project version drift.

Assessment context: all projects are SDK-style and currently on `net8.0`; package recommendations exist for a small subset of dependencies. Risk is low, but consistency settings affect every project build.

**Done when**: .NET 10 SDK prerequisites are satisfied and shared package/version management is configured consistently for the solution.

## Scope Inventory

- Projects affected: solution-wide preparation only (no individual project TFM edits in this task).
- Distinct concerns: SDK/toolchain readiness, global configuration discovery, package-version-management approach.
- Change signals: 16 SDK-style projects, 3 package upgrade recommendations, no SDK-style conversion required.
- Skill matches: building-projects (validate build-tool behavior after config changes).

## Research Findings

- `validate_dotnet_sdk_installation(net10.0)` confirms compatible .NET 10 SDK is installed.
- `validate_dotnet_sdk_in_globaljson` reports no `global.json` present, so no SDK pin adjustment is needed.
- Repository scan found no existing `Directory.Packages.props`, `Directory.Build.props`, or `Directory.Build.targets`.
- Existing package management is currently per-project; to preserve minimal churn, package centralization should be introduced only if it does not require broad non-upgrade refactoring.

## Planned Changes

1. Add minimal shared package-management configuration only if required for consistent .NET 10 migration behavior.
2. Keep changes limited to upgrade-enabling configuration; defer broad package-structure refactors if unnecessary.
