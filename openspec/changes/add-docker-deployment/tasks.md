## 1. Docker Configuration

- [ ] 1.1 Create .dockerignore file in apps/web/
- [ ] 1.2 Create .dockerignore file in apps/backend/
- [ ] 1.3 Create Dockerfile for apps/web/ (multi-stage build)
- [ ] 1.4 Create Dockerfile for apps/backend/ (ASP.NET Core 9)
- [ ] 1.5 Create docker-compose.yml in root directory

## 2. Docker Compose Configuration

- [ ] 2.1 Configure frontend service (web) with:
  - [ ] 2.1.1 Build context and Dockerfile reference
  - [ ] 2.1.2 Port mapping (5173:5173 for dev, 3000:80 for production)
  - [ ] 2.1.3 Volume mount for hot-reload development
  - [ ] 2.1.4 Environment variables for API URL
- [ ] 2.2 Configure backend service (backend) with:
  - [ ] 2.2.1 Build context and Dockerfile reference
  - [ ] 2.2.2 Port mapping (5000:8080)
  - [ ] 2.2.3 Volume mount for ~/src/ access
  - [ ] 2.2.4 Environment variables for development
- [ ] 2.3 Configure networking between services
- [ ] 2.4 Add health checks for both services

## 3. Documentation

- [ ] 3.1 Add Docker setup section to apps/web/README.md
- [ ] 3.2 Add Docker setup section to apps/backend/README.md
- [ ] 3.3 Create DOCKER.md in root with:
  - [ ] 3.3.1 Prerequisites (Docker, Docker Compose)
  - [ ] 3.3.2 Quick start instructions
  - [ ] 3.3.3 Development workflow with volume mounts
  - [ ] 3.3.4 Troubleshooting common issues
- [ ] 3.4 Update root README.md with Docker Compose reference

## 4. Testing

- [ ] 4.1 Test docker-compose up builds both services successfully
- [ ] 4.2 Verify frontend can reach backend API
- [ ] 4.3 Verify volume mounts work (code changes reflected)
- [ ] 4.4 Test hot-reload in development mode
- [ ] 4.5 Verify local filesystem access from backend container
