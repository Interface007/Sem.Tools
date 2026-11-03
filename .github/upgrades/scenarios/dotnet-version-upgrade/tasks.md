# .NET Version Upgrade Progress
**Progress**: 1/4 tasks complete <progress value="25" max="100"></progress> 25%
**Status**: Not Started

This scenario upgrades the Sem.Tools solution from .NET 8 to .NET 10 using an incremental top-down approach. It applies shared configuration updates, project target framework updates, and inline compatibility fixes while keeping behavior changes minimal. Validation is performed with a full solution build at the end.

- ✅ 01-prepare-sdk-and-central-package-management: prepare-sdk-and-central-package-management ([Content](tasks/01-prepare-sdk-and-central-package-management/task.md), [Progress](tasks/01-prepare-sdk-and-central-package-management/progress-details.md))

## Tasks

- 🔲 01-prepare-sdk-and-central-package-management: Prepare SDK and central package management
- 🔲 02-upgrade-consumer-and-core-projects-to-net10: Upgrade consumer and core projects to net10
- 🔲 03-upgrade-data-and-test-projects-to-net10: Upgrade data and test projects to net10
- 🔲 04-final-build-and-upgrade-validation: Final build and upgrade validation
