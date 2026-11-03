# .NET Version Upgrade Plan

## Overview

**Target**: Upgrade the full Sem.Tools solution from .NET 8 to .NET 10 with minimal behavior change.
**Scope**: 16 SDK-style projects with mostly class libraries plus one primary application project and multiple test projects.

### Selected Strategy
**Top-Down (Application-First)** — Applications upgraded first, libraries updated as required to keep consumers buildable.
**Rationale**: The solution has 16 projects and includes API/package upgrade findings, so an incremental application-first flow reduces risk while keeping changes controlled.

Application vs library classification:
- Application/consumer priority: `Sem.MdDocGenerator/Sem.MdDocGenerator.csproj`, then `Sem.Tools.CmdLine/Sem.Tools.CmdLine.csproj` and direct consumers.
- Shared libraries: `Sem.Tools`, `Sem.Tools.Logging`, `Sem.Tools.TestHelper`, `Sem.Data.SprocAccess` and provider libraries.
- Test projects updated with their corresponding consumer/library wave.

Phase 2 trigger:
- Once all project files and dependent consumers are on `net10.0`, complete any remaining cleanup and run full validation.

## Upgrade Options

| Option | Selected | Why |
|--------|----------|-----|
| Upgrade Strategy | Top-Down | 16-project scope with API/package findings benefits from incremental app/consumer-first sequencing. |
| Package Management | Central Package Management (CPM) | All projects are SDK-style in a modern-to-modern upgrade, so central version control improves consistency. |
| Unsupported API Handling | Fix Inline | API compatibility findings should be resolved directly during upgrade tasks to avoid deferred stub cleanup. |

## Tasks

### 01-prepare-sdk-and-central-package-management

Verify toolchain readiness for .NET 10 and establish central package management in a minimal, low-churn way. This task covers confirming `global.json`/SDK alignment (if present), adding central package configuration if needed, and preparing shared settings so all projects can move to a consistent target framework without per-project version drift.

Assessment context: all projects are SDK-style and currently on `net8.0`; package recommendations exist for a small subset of dependencies. Risk is low, but consistency settings affect every project build.

**Done when**: .NET 10 SDK prerequisites are satisfied and shared package/version management is configured consistently for the solution.

### 02-upgrade-consumer-and-core-projects-to-net10

Upgrade the primary consumer/application projects and their directly required core libraries to `net10.0`, applying inline fixes for API findings in this wave. Scope includes `Sem.MdDocGenerator`, `Sem.Tools.CmdLine`, `Sem.Tools`, `Sem.Tools.Logging`, `Sem.Tools.TestHelper`, and any directly coupled dependencies needed to keep these projects compiling and functioning.

Assessment context: API compatibility findings include source/binary/behavior changes concentrated around SQL client and crypto/data-protection related APIs; package upgrade recommendations are limited but should be applied where relevant in this wave.

**Done when**: consumer/application and core dependency projects target `net10.0` and compile with required inline compatibility fixes.

### 03-upgrade-data-and-test-projects-to-net10

Upgrade remaining data-access and test projects to `net10.0`, completing the solution-wide target framework transition. Scope includes `Sem.Data.SprocAccess*` projects and all test projects so framework, package references, and test infrastructure align to .NET 10 across the repo.

Assessment context: the largest API issue concentration is in `Sem.Data.SprocAccess.SqlServer`, and package recommendations include .NET 10-stable alignment for selected `System.*` packages. This task completes those changes with minimal code churn.

**Done when**: all remaining projects (including tests) target `net10.0` and compile with API/package updates applied as needed.

### 04-final-build-and-upgrade-validation

Run full solution validation, resolve upgrade-related build issues introduced by the target framework change, and confirm a stable post-upgrade state. This includes a complete solution build and targeted follow-up fixes for any net10 migration regressions uncovered during compilation.

Assessment context: upgrade is low-to-medium risk overall, but cross-project consistency and API behavior differences require end-to-end verification before completion.

**Done when**: full solution build succeeds on .NET 10 and any upgrade-related compile issues are resolved or documented with explicit follow-up actions.
