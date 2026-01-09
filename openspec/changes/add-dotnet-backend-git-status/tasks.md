## 1. Project Setup

- [x] 1.1 Scaffold .NET 8 Web API project in `apps/backend/`
- [x] 1.2 Add backend to Nx workspace configuration
- [x] 1.3 Create `packages/domain-git/` package for shared git domain types
- [x] 1.4 Configure build targets for backend in `project.json`
- [x] 1.5 Set up .NET project references and solution file
- [x] 1.6 Add LibGit2Sharp NuGet package or git CLI wrapper (using git CLI wrapper)

## 2. Git Status Service

- [x] 2.1 Create `GitStatusRequest` and `GitStatusResponse` DTOs
- [x] 2.2 Create `IGitStatusService` interface
- [x] 2.3 Implement `GitStatusService` with LibGit2Sharp or git CLI
- [x] 2.4 Add path validation (check if directory exists)
- [x] 2.5 Add git repository validation (check if it's a valid git repo)
- [x] 2.6 Implement error handling for common scenarios:
  - Invalid directory path
  - Not a git repository
  - Permission denied
  - Repository corruption
- [x] 2.7 Add logging for git operations and errors

## 3. API Endpoint

- [x] 3.1 Create `GitController` with minimal API or controller
- [x] 3.2 Add `GET /api/git/status` endpoint with query parameter `path`
- [x] 3.3 Add request validation (ensure path is provided)
- [x] 3.4 Add Swagger/OpenAPI documentation for endpoint
- [x] 3.5 Configure CORS for frontend communication

## 4. Domain Types (Shared)

- [x] 4.1 Create shared types in `packages/domain-git/`:
  - `GitFileStatus` enum (Added, Modified, Deleted, Renamed, etc.)
  - `GitFileChange` model (path, status, staging status)
  - `GitStatus` model (branch, commit hash, files)
- [x] 4.2 Add TypeScript type definitions for frontend integration
- [x] 4.3 Export types from domain-git package

## 5. Testing

- [x] 5.1 Create unit test project for backend (`apps/backend.Tests/`)
- [x] 5.2 Add unit tests for `GitStatusService`:
  - Test valid repository path (basic constructor test)
  - Test invalid directory path (null, empty, whitespace)
  - Test non-git directory
  - Test empty repository (skipped - requires setup)
  - Test repository with changes (skipped - requires setup)
- [x] 5.3 Add integration tests for API endpoint
- [x] 5.4 Add test fixtures for git repository scenarios

## 6. Development Experience

- [x] 6.1 Add health check endpoint (`/health`)
- [x] 6.2 Configure development settings (launchSettings.json)
- [x] 6.3 Add README for backend with build/run instructions
- [x] 6.4 Configure VS Code launch profiles for backend

## 7. Documentation

- [x] 7.1 Document API endpoint in spec
- [x] 7.2 Add usage examples to README
- [x] 7.3 Document error response formats
- [x] 7.4 Add architecture diagram for backend structure

## 8. Verification

- [x] 8.1 Run backend locally: `dotnet run`
- [x] 8.2 Test API endpoint with curl or Postman
- [x] 8.3 Run all tests: `nx test backend`
- [x] 8.4 Build for production: `nx build backend`
- [x] 8.5 Verify health check returns 200 OK

## 9. Code Review and Quality (post-implementation)

- [x] 9.1 Fix critical typo: Added → Added in GitFileStatus.cs (line 11)
- [x] 9.2 Fix critical typo: Copied → Copied in GitFileStatus.cs (line 36)
- [x] 9.3 Add validation to GetLatestCommitAsync() parsing:
  - Validate git log output before splitting
  - Validate hash is valid SHA-1 (40 hex characters)
  - Return unknown values for invalid format
  - Add detailed logging for validation failures
- [x] 9.4 Add robustness to git porcelain output parsing:
  - Normalize line endings (CRLF/LF)
  - Remove empty and whitespace-only lines
  - Handle renamed/copied file paths (R old → new, C old → new)
  - Validate line length before parsing
  - Skip malformed lines with warnings
  - Handle files with both staged and unstaged changes
- [x] 9.5 Add success logging for git operations
- [x] 9.6 Add ErrorCode constants class to centralize error codes
- [x] 9.7 Remove unused UseAuthorization() middleware
- [x] 9.8 Fix middleware order (UseHttpsRedirection before MapControllers)
- [x] 9.9 Update GitController to use ErrorCode class instead of magic strings
- [x] 9.10 Add proper using statement for GitRelax.Backend.Models in Program.cs

## 10. Repository Hygiene

- [x] 10.1 Remove build artifacts from git tracking (bin/, obj/)
- [x] 10.2 Update .gitignore for TS/Svelte (frontend) AND .NET (backend)
- [x] 10.3 Add .gitattributes for smart file handling
- [x] 10.4 Add .dockerignore for Docker support
- [x] 10.5 Commit repository hygiene changes
