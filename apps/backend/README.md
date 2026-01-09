# GitRelax Backend

.NET 9 Web API service for git operations in git-relax.

## Getting Started

### Prerequisites

- .NET 9 SDK
- Git CLI installed and accessible via PATH

### Development

```bash
# Build the backend
nx run backend:build
# or
dotnet build GitRelax.sln

# Run the backend
nx run backend:serve
# or
dotnet run --project apps/backend/GitRelax.Backend.csproj

# Run tests
nx run backend:test
# or
dotnet test GitRelax.sln

# Format code
dotnet format --verify-no-changes --include *.cs
```

### Endpoints

#### Git Status

Get git status for a local repository.

```bash
GET /api/git/status?path={repository-path}
```

**Query Parameters:**
- `path` (required): File system path to git repository

**Response (200 OK):**
```json
{
  "branch": "main",
  "commitHash": "abc123",
  "commitMessage": "Initial commit",
  "stagedFiles": [],
  "unstagedFiles": [
    {
      "path": "README.md",
      "status": "Modified",
      "isStaged": false
    }
  ],
  "untrackedFiles": [
    {
      "path": "new-file.txt",
      "status": "Untracked",
      "isStaged": false
    }
  ]
}
```

**Error Responses:**
- `400 Bad Request`: Invalid path, directory not found, not a git repository
- `403 Forbidden`: Permission denied
- `500 Internal Server Error`: Unexpected errors

#### Health Check

Check API health status.

```bash
GET /health
```

**Response (200 OK):**
```json
{
  "status": "healthy",
  "timestamp": "2026-01-09T07:54:00Z"
}
```

### API Documentation

Swagger UI is available in development mode:

```bash
# Start the backend
nx run backend:serve

# Open Swagger UI in browser
http://localhost:5000/swagger
```

## Error Response Format

All errors follow a consistent format:

```json
{
  "error": "Human-readable error message",
  "code": "ERROR_CODE",
  "path": "/path/to/repo"  // optional
}
```

### Error Codes

| Code | Description |
|------|-------------|
| `PATH_REQUIRED` | Path parameter is missing |
| `INVALID_PATH` | Invalid path provided |
| `DIRECTORY_NOT_FOUND` | Directory does not exist |
| `NOT_GIT_REPOSITORY` | Directory is not a git repository |
| `PERMISSION_DENIED` | Permission denied accessing directory |
| `INTERNAL_ERROR` | Unexpected internal error |

## Project Structure

```
apps/backend/
├── Controllers/        # API controllers
├── Services/           # Business logic services
├── Models/             # DTOs and models
├── Tests/              # Unit and integration tests
└── Program.cs          # Application entry point
```

## Development Notes

- Uses git CLI for git operations (portable, no native dependencies)
- Implements proper path validation and error handling
- Supports CORS for frontend communication
- Includes comprehensive logging for debugging
- Uses xUnit for testing

## Future Enhancements

- Support for more git operations (commit, push, pull, etc.)
- Real-time updates via WebSockets or SignalR
- Support for git worktrees
- Integration tests with actual git repositories
- Performance optimization for large repositories
