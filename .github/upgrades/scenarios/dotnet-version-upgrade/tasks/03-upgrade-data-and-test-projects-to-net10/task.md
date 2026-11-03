# 03-upgrade-data-and-test-projects-to-net10: upgrade-data-and-test-projects-to-net10

Upgrade remaining data-access and test projects to `net10.0`, completing the solution-wide target framework transition. Scope includes `Sem.Data.SprocAccess*` projects and all test projects so framework, package references, and test infrastructure align to .NET 10 across the repo.

Assessment context: the largest API issue concentration is in `Sem.Data.SprocAccess.SqlServer`, and package recommendations include .NET 10-stable alignment for selected `System.*` packages. This task completes those changes with minimal code churn.

**Done when**: all remaining projects (including tests) target `net10.0` and compile with API/package updates applied as needed.
