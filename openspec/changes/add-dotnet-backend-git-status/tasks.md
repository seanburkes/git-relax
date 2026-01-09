## 1. Project Setup

- [ ] 1.1 Scaffold .NET 8 Web API project in `apps/backend/`
- [ ] 1.2 Add backend to Nx workspace configuration
- [ ] 1.3 Create `packages/domain-git/` package for shared git domain types
- [ ] 1.4 Configure build targets for backend in `project.json`
- [ ] 1.5 Set up .NET project references and solution file
- [x] 1.6 Add LibGit2Sharp NuGet package or git CLI wrapper (using git CLI wrapper)

## 2. Git Status Service

- [ ] 2.1 Create `GitStatusRequest` and `GitStatusResponse` DTOs
- [ ] 2.2 Create `IGitStatusService` interface
- [ ] 2.3 Implement `GitStatusService` with LibGit2Sharp or git CLI
- [ ] 2.4 Add path validation (check if directory exists)
- [ ] 2.5 Add git repository validation (check if it's a valid git repo)
- [ ] 2.6 Implement error handling for common scenarios:
  - Invalid directory path
  - Not a git repository
  - Permission denied
  - Repository corruption
- [ ] 2.7 Add logging for git operations and errors

## 3. API Endpoint

- [ ] 3.1 Create `GitController` with minimal API or controller
- [ ] 3.2 Add `GET /api/git/status` endpoint with query parameter `path`
- [ ] 3.3 Add request validation (ensure path is provided)
- [ ] 3.4 Add Swagger/OpenAPI documentation for endpoint
- [ ] 3.5 Configure CORS for frontend communication

## 4. Domain Types (Shared)

- [ ] 4.1 Create shared types in `packages/domain-git/`:
  - `GitFileStatus` enum (Added, Modified, Deleted, Renamed, etc.)
  - `GitFileChange` model (path, status, staging status)
  - `GitStatus` model (branch, commit hash, files)
- [ ] 4.2 Add TypeScript type definitions for frontend integration
- [ ] 4.3 Export types from domain-git package

## 5. Testing

- [ ] 5.1 Create unit test project for backend (`apps/backend.Tests/`)
- [ ] 5.2 Add unit tests for `GitStatusService`:
  - Test valid repository path
  - Test invalid directory path
  - Test non-git directory
  - Test empty repository
  - Test repository with changes
- [ ] 5.3 Add integration tests for API endpoint
- [ ] 5.4 Add test fixtures for git repository scenarios

## 6. Development Experience

- [ ] 6.1 Add health check endpoint (`/health`)
- [ ] 6.2 Configure development settings (launchSettings.json)
- [ ] 6.3 Add README for backend with build/run instructions
- [ ] 6.4 Configure VS Code launch profiles for backend

## 7. Documentation

- [ ] 7.1 Document API endpoint in spec
- [ ] 7.2 Add usage examples to README
- [ ] 7.3 Document error response formats
- [ ] 7.4 Add architecture diagram for backend structure

## 8. Verification

- [ ] 8.1 Run backend locally: `dotnet run`
- [ ] 8.2 Test API endpoint with curl or Postman
- [ ] 8.3 Run all tests: `nx test backend`
- [ ] 8.4 Build for production: `nx build backend`
- [ ] 8.5 Verify health check returns 200 OK
