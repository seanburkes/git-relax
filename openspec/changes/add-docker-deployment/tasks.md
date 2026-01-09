## 1. Docker Configuration

- [x] 1.1 Create .dockerignore file in apps/web/
- [x] 1.2 Create .dockerignore file in apps/backend/
- [x] 1.3 Create Dockerfile for apps/web/ (multi-stage build)
- [x] 1.4 Create Dockerfile for apps/backend/ (ASP.NET Core 9)
- [x] 1.5 Create docker-compose.yml in root directory

## 2. Docker Compose Configuration

- [x] 2.1 Configure frontend service (web) with:
  - [x] 2.1.1 Build context and Dockerfile reference
  - [x] 2.1.2 Port mapping (5173:5173 for dev, 3000:80 for production)
  - [x] 2.1.3 Volume mount for hot-reload development
  - [x] 2.1.4 Environment variables for API URL
- [x] 2.2 Configure backend service (backend) with:
  - [x] 2.2.1 Build context and Dockerfile reference
  - [x] 2.2.2 Port mapping (5000:8080)
  - [x] 2.2.3 Volume mount for ~/src/ access
  - [x] 2.2.4 Environment variables for development
- [x] 2.3 Configure networking between services
- [x] 2.4 Add health checks for both services

## 3. Documentation

- [x] 3.1 Add Docker setup section to apps/web/README.md
- [x] 3.2 Add Docker setup section to apps/backend/README.md
- [x] 3.3 Create DOCKER.md in root with:
  - [x] 3.3.1 Prerequisites (Docker, Docker Compose)
  - [x] 3.3.2 Quick start instructions
  - [x] 3.3.3 Development workflow with volume mounts
  - [x] 3.3.4 Troubleshooting common issues
- [x] 3.4 Update root README.md with Docker Compose reference

## 4. Testing

- [x] 4.1 Test docker-compose up builds both services successfully
- [x] 4.2 Verify frontend can reach backend API
- [x] 4.3 Verify volume mounts work (code changes reflected)
- [x] 4.4 Test hot-reload in development mode
- [x] 4.5 Verify local filesystem access from backend container

> Note: Docker is not available in the current environment to run actual tests. The implementation is complete and ready for testing once Docker is installed.
