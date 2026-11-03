# 04-final-build-and-upgrade-validation: final-build-and-upgrade-validation

Run full solution validation, resolve upgrade-related build issues introduced by the target framework change, and confirm a stable post-upgrade state. This includes a complete solution build and targeted follow-up fixes for any net10 migration regressions uncovered during compilation.

Assessment context: upgrade is low-to-medium risk overall, but cross-project consistency and API behavior differences require end-to-end verification before completion.

**Done when**: full solution build succeeds on .NET 10 and any upgrade-related compile issues are resolved or documented with explicit follow-up actions.

## Scope Inventory

- Validation scope: full solution (`Sem.Tools.sln`) after all project retargeting and central package management changes.
- Required checks:
  1. Full solution build on `net10.0`.
  2. Full solution test execution.
  3. Confirm no remaining `net8.0` target frameworks in project files.
  4. Document any manual follow-up constraints (SDK/tooling) if present.

## Research Findings

- Tasks 01-03 completed with successful intermediate builds and tests.
- Current branch is `upgrade-dotnet-10` with all intended project/props updates staged through prior commits.
- This task is final gate/evidence capture; if validation remains green, only workflow artifact updates are expected.
