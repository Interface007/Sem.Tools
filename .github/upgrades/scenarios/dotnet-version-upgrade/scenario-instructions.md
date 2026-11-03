# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0

## Source Control
- **Source Branch**: master
- **Working Branch**: upgrade-dotnet-10
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## Upgrade Options

### Strategy
- Upgrade Strategy: Top-Down

### Project Structure
- Package Management: Central Package Management (CPM)

### Compatibility
- Unsupported API Handling: Fix Inline

## Strategy
**Selected**: Top-Down (Application-First)
**Rationale**: The solution has 16 projects and non-trivial API/package upgrade signals, so an incremental application-first flow reduces disruption versus a single large upgrade pass.

### Execution Constraints
- Upgrade entry-point/consumer projects first, and update required dependencies in the same wave.
- Avoid multi-targeting unless it becomes necessary to keep dependent projects buildable during transition.
- Keep API breaking-change remediation inline with each project/task (no deferred stubs).
- Validate build correctness after each major project group and run full-solution validation at the end.
- Keep commits after each completed task to preserve rollback points.

## User Preferences

### Execution Style
- Preserve existing behavior and keep changes minimal.
