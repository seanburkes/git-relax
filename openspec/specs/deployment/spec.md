# deployment Specification

## Purpose
TBD - created by archiving change add-docker-deployment. Update Purpose after archive.
## Requirements
### Requirement: Docker Compose Startup

The system SHALL provide a Docker Compose configuration that allows starting both frontend and backend services with a single command `docker compose up`.

#### Scenario: Successful startup of both services

- **GIVEN** Docker and Docker Compose are installed
- **WHEN** developer runs `docker compose up` from the project root
- **THEN** both frontend (SvelteKit) and backend (ASP.NET Core) services start successfully
- **AND** frontend is accessible at http://localhost:5173
- **AND** backend API is accessible at http://localhost:5000

### Requirement: Frontend Docker Configuration

The system SHALL provide a Dockerfile for the SvelteKit frontend application that supports both development and production builds.

#### Scenario: Frontend builds and starts in container

- **GIVEN** Dockerfile exists in apps/web/
- **WHEN** Docker builds the frontend image
- **THEN** the image contains all dependencies and application code
- **AND** the Vite dev server starts on port 5173 in development mode
- **AND** hot module replacement works when code changes

#### Scenario: Frontend production build

- **GIVEN** Dockerfile uses multi-stage build
- **WHEN** building the production target
- **THEN** only runtime dependencies are included in final image
- **AND** SvelteKit static files are served via adapter

### Requirement: Backend Docker Configuration

The system SHALL provide a Dockerfile for the ASP.NET Core backend application that runs the API server.

#### Scenario: Backend starts in container

- **GIVEN** Dockerfile exists in apps/backend/
- **WHEN** Docker builds and runs the backend image
- **THEN** ASP.NET Core Kestrel server starts on port 8080
- **AND** the application runs in Development environment
- **AND** Swagger UI is available at /swagger

### Requirement: Volume Mount for Development

The system SHALL configure volume mounts for both services to enable hot-reload and local filesystem access.

#### Scenario: Frontend hot-reload with volume mount

- **GIVEN** docker-compose.yml mounts apps/web/ to container
- **WHEN** developer edits a Svelte component file locally
- **THEN** changes are reflected immediately in the running container
- **AND** the browser updates via Vite HMR

#### Scenario: Backend code changes with volume mount

- **GIVEN** docker-compose.yml mounts apps/backend/ to container
- **WHEN** developer edits a C# controller file locally
- **THEN** the application restarts automatically
- **AND** the new code is available immediately

### Requirement: Local Filesystem Access

The system SHALL allow the backend container to access the user's local source code directory (~/src/...) for Git operations.

#### Scenario: Backend accesses local repositories

- **GIVEN** docker-compose.yml mounts ~/src/ to /host-src in backend container
- **WHEN** backend performs Git operations
- **THEN** the container can read/write files in ~/src/
- **AND** repositories are accessible at /host-src/...

### Requirement: Service Networking

The system SHALL configure Docker Compose networking so the frontend can communicate with the backend API.

#### Scenario: Frontend calls backend API

- **GIVEN** both services are running in Docker Compose network
- **WHEN** frontend makes API calls to backend
- **THEN** requests resolve to backend service name (http://backend:8080)
- **AND** CORS allows cross-origin requests from frontend

### Requirement: Development Environment Variables

The system SHALL configure environment variables for both services to support proper development mode behavior.

#### Scenario: Backend runs in development mode

- **GIVEN** docker-compose.yml sets ASPNETCORE_ENVIRONMENT=Development
- **WHEN** backend container starts
- **THEN** detailed error messages are shown
- **AND** Swagger UI is enabled
- **AND** hot-reload is enabled

#### Scenario: Frontend knows backend API URL

- **GIVEN** docker-compose.yml sets VITE_API_URL=http://backend:8080
- **WHEN** frontend container starts
- **THEN** Vite makes VITE_API_URL available to client code
- **AND** API calls route to backend container correctly

### Requirement: Docker Ignore Files

The system SHALL provide .dockerignore files for both services to exclude unnecessary files from Docker build context.

#### Scenario: Build context optimization

- **GIVEN** .dockerignore files exist for both apps
- **WHEN** Docker builds images
- **THEN** node_modules/ is excluded from build context
- **AND** .git/ directory is excluded
- **AND** build artifacts (.nx/, dist/, .svelte-kit/) are excluded
- **AND** build time is faster due to smaller context

### Requirement: Docker Documentation

The system SHALL provide comprehensive documentation for using Docker Compose for local development.

#### Scenario: Developer starts application with Docker

- **GIVEN** developer has installed Docker and Docker Compose
- **WHEN** they read the DOCKER.md file
- **THEN** they understand prerequisites and installation steps
- **AND** they can run `docker compose up` successfully
- **AND** they know how to access both services

#### Scenario: Troubleshooting Docker issues

- **GIVEN** developer encounters a Docker-related problem
- **WHEN** they reference DOCKER.md
- **THEN** common issues are documented with solutions
- **AND** platform-specific workarounds are provided

