## ADDED Requirements

### Requirement: Get Git Status
The backend service SHALL provide the ability to retrieve git status for a specified local repository directory.

#### Scenario: Successful git status retrieval
- **WHEN** a valid git repository directory is provided
- **THEN** the system returns the current git status including:
  - Current branch name
  - Latest commit hash and message
  - List of staged files with their status
  - List of unstaged files with their status
  - List of untracked files
- **AND** HTTP status code 200 is returned
- **AND** response includes all file change details

#### Scenario: Invalid directory path
- **WHEN** a non-existent directory path is provided
- **THEN** the system returns HTTP status code 400 (Bad Request)
- **AND** error message indicates "Directory not found: {path}"

#### Scenario: Not a git repository
- **WHEN** a valid directory is provided but it is not a git repository
- **THEN** the system returns HTTP status code 400 (Bad Request)
- **AND** error message indicates "Not a git repository: {path}"

#### Scenario: Permission denied
- **WHEN** the system lacks permissions to access the specified directory
- **THEN** the system returns HTTP status code 403 (Forbidden)
- **AND** error message indicates "Permission denied: {path}"

#### Scenario: Repository with no changes
- **WHEN** a valid git repository is queried and there are no changes
- **THEN** the system returns empty lists for staged, unstaged, and untracked files
- **AND** still returns current branch and latest commit information

### Requirement: Path Validation
The backend service SHALL validate all directory path inputs before attempting git operations.

#### Scenario: Null or empty path
- **WHEN** a null or empty path parameter is provided
- **THEN** the system returns HTTP status code 400 (Bad Request)
- **AND** error message indicates "Path parameter is required"

#### Scenario: Path traversal attempt
- **WHEN** a path with directory traversal characters (e.g., "../") is provided
- **THEN** the system normalizes the path
- **AND** prevents access to directories outside allowed scope

### Requirement: Error Response Format
All error responses from the git status endpoint SHALL follow a consistent format.

#### Scenario: Error response structure
- **WHEN** any error occurs during git status retrieval
- **THEN** the system returns a JSON response with:
  - `error`: Human-readable error message
  - `code`: Machine-readable error code
  - `path`: The directory path that caused the error (if applicable)
- **AND** appropriate HTTP status code is returned

### Requirement: API Endpoint Documentation
The git status API endpoint SHALL be documented with OpenAPI/Swagger specification.

#### Scenario: View API documentation
- **WHEN** a developer accesses the Swagger UI at `/swagger`
- **THEN** the git status endpoint is listed with:
  - HTTP method and path
  - Request parameters (path)
  - Response format (success and error)
  - Example requests and responses
- **AND** documentation includes description of git status fields
