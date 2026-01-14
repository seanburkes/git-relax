# Change: Add Docker Compose Deployment

## Why

Enable developers to quickly spin up the entire git-relax stack (frontend + backend) with a single command, using Docker Compose for containerized development. This provides a consistent development environment and simplifies local testing.

## What Changes

- Create Dockerfile for the SvelteKit frontend (web app)
- Create Dockerfile for the .NET backend API
- Create docker-compose.yml to orchestrate both services
- Configure volume mounts for local filesystem access (~/src/...)
- Configure environment variables and networking
- Add .dockerignore files for both services
- Update project documentation with Docker setup instructions

## Impact

- Affected specs: deployment (new capability)
- Affected code: apps/web/, apps/backend/, root directory
- Breaking: None (additive change)
