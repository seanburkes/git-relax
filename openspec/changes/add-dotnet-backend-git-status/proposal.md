# Change: Add .NET backend service with git status capability

## Why
We need a backend service to execute git commands on the local filesystem. This will serve as the foundation for all git operations in git-relax. Starting with git status provides a minimal, testable foundation.

## What Changes
- Scaffold .NET 8 Web API backend project in `apps/backend/`
- Add git operations domain package in `packages/domain-git/`
- Create git status service with LibGit2Sharp or git CLI wrapper
- Add API endpoint for git status: `GET /api/git/status?path={directory}`
- Implement path validation and error handling
- Add basic logging and health checks

## Impact
- Affected specs: git-operations (new spec)
- Affected code:
  - apps/backend/ (new .NET Web API project)
  - packages/domain-git/ (new shared domain package)
  - packages/shared/ (new shared types for git operations)
- Build targets: Add backend build, test, and serve targets to Nx workspace
