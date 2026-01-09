# Docker Setup for Git-Relax

This guide explains how to use Docker Compose to run the git-relax development environment with a single command.

## Prerequisites

- Docker Engine 20.10+
- Docker Compose 2.0+

### Installation

**Linux:**
```bash
# Ubuntu/Debian
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh get-docker.sh

# Verify installation
docker --version
docker compose version
```

**macOS:**
- Install Docker Desktop from [docker.com](https://www.docker.com/products/docker-desktop)
- Launch Docker Desktop and start the Docker daemon

**Windows:**
- Install Docker Desktop from [docker.com](https://www.docker.com/products/docker-desktop)
- Launch Docker Desktop (requires WSL2 backend)

## Quick Start

```bash
# Navigate to project root
cd /home/sean/src/git-relax

# Start both services
docker compose up

# In another terminal, view logs
docker compose logs -f

# Stop services
docker compose down
```

Access the services:
- Frontend: http://localhost:5173
- Backend API: http://localhost:5000
- Swagger UI: http://localhost:5000/swagger

## Development Workflow

### Hot-Reload Development

The Docker Compose setup includes volume mounts for hot-reload development:

**Frontend (SvelteKit):**
```bash
# Changes in apps/web/ are reflected immediately
# Vite HMR updates the browser automatically
```

**Backend (.NET):**
```bash
# Changes in apps/backend/ trigger automatic restart
# .NET watches for file changes and rebuilds
```

### Volume Mounts

```
apps/web/         → /app (frontend container)
apps/backend/     → /app (backend container)
~/src/            → /host-src (backend container, read-only)
```

The `~/src/` mount allows the backend to access your local repositories for Git operations.

### Environment Variables

**Frontend:**
- `VITE_API_URL=http://backend:8080` - Backend API endpoint

**Backend:**
- `ASPNETCORE_ENVIRONMENT=Development` - Enables detailed errors, Swagger UI
- `ASPNETCORE_URLS=http://+:8080` - Bind address

## Services

### Frontend Service (web)

```yaml
Image: Built from apps/web/Dockerfile (dev target)
Port: 5173:5173
Health Check: http://localhost:5173
```

### Backend Service (backend)

```yaml
Image: Built from apps/backend/Dockerfile
Port: 5000:8080
Health Check: http://localhost:5000/health
```

## Common Commands

```bash
# Start services in background (detached)
docker compose up -d

# View logs
docker compose logs -f

# View logs for specific service
docker compose logs -f web
docker compose logs -f backend

# Rebuild and restart
docker compose up --build

# Stop services
docker compose down

# Stop and remove volumes
docker compose down -v

# Execute command in container
docker compose exec web sh
docker compose exec backend bash

# Build images without running
docker compose build
```

## Troubleshooting

### Port Already in Use

If you get "port is already allocated" errors:

```bash
# Check what's using the ports
lsof -i :5173
lsof -i :5000

# Stop the conflicting service or change ports in docker-compose.yml
```

### Hot-Reload Not Working on Docker Desktop (Mac/Windows)

File watching may not work properly due to volume mount performance:

**Solution 1: Increase Docker resources**
- Open Docker Desktop → Settings → Resources
- Increase file sharing limit and CPU/memory

**Solution 2: Use polling (Linux only)**
Add to apps/web/vite.config.ts:
```typescript
server: {
  watch: {
    usePolling: true,
    interval: 100
  }
}
```

**Solution 3: Rebuild containers**
```bash
docker compose down
docker compose up --build
```

### Permission Issues (Linux)

Container user may not have permissions for mounted files:

```bash
# Check user ID
id -u

# Add to docker-compose.yml (optional)
# services:
#   backend:
#     user: "${UID:-1000}:${GID:-1000}"

# Run with user mapping
UID=$(id -u) GID=$(id -g) docker compose up
```

### Network Name Resolution

Frontend can't reach backend:

```bash
# Ensure both services are running
docker compose ps

# Check service name resolution
docker compose exec web wget -O- http://backend:8080/health

# If DNS issues, use container IP
docker inspect git-relax-backend-1 | grep IPAddress
```

### Backend Can't Access ~/src/

Verify the volume mount:

```bash
# Check mount inside container
docker compose exec backend ls -la /host-src

# If empty, verify host path exists
ls -la ~/src

# Adjust path in docker-compose.yml if needed
volumes:
  - /path/to/your/src:/host-src:ro
```

### Container Won't Start

```bash
# Check logs for errors
docker compose logs backend

# Common issues:
# - Missing dependencies in Dockerfile
# - Port conflicts
# - Build failures

# Rebuild with debug output
docker compose build --progress=plain
```

### Health Checks Failing

```bash
# Manually check endpoints
curl http://localhost:5173
curl http://localhost:5000/health

# Check health check configuration
docker compose ps

# Temporarily disable health checks (docker-compose.yml):
# healthcheck:
#   disable: true
```

## Platform-Specific Notes

### Windows (Docker Desktop)

- Ensure WSL2 backend is enabled
- File paths are case-insensitive
- Performance may be slower than Linux
- Use `\\wsl$` paths if needed

### macOS (Docker Desktop)

- File watching may be slower
- Use "cached" or "delegated" mount options for performance
- Increase Docker memory to 4GB+ for better performance

### Linux (Native)

- Best performance for volume mounts
- May need sudo access for Docker
- User must be in `docker` group:
  ```bash
  sudo usermod -aG docker $USER
  newgrp docker
  ```

## Production Considerations

This setup is optimized for development. For production:

- Use production Docker targets (not `dev`)
- Remove volume mounts
- Add reverse proxy (nginx, traefik)
- Configure proper environment variables
- Use container registry for images
- Implement secrets management

## Getting Help

If you encounter issues not covered here:

1. Check Docker Compose logs: `docker compose logs -f`
2. Inspect container status: `docker compose ps`
3. Verify Docker is running: `docker info`
4. Check file permissions and paths
5. Review [Project README](README.md) and individual service documentation

## Additional Resources

- [Docker Documentation](https://docs.docker.com/)
- [Docker Compose Documentation](https://docs.docker.com/compose/)
- [Dockerfile Best Practices](https://docs.docker.com/develop/develop-images/dockerfile_best-practices/)
