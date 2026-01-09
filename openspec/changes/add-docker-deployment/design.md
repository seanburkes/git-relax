## Context

The git-relax application currently runs with separate development servers for frontend (Vite dev server on port 5173) and backend (ASP.NET Core Kestrel on port 5000). Developers need to start both services manually and ensure proper networking between them. Docker Compose will provide a single-command startup experience with consistent environments.

**Constraints:**

- Frontend: SvelteKit with Vite dev server (needs hot module replacement)
- Backend: .NET 9 ASP.NET Core API
- Must support volume mounts for local development (~/src/...)
- Services must communicate over Docker network
- Must work cross-platform (Windows, macOS, Linux)

**Stakeholders:**

- Developers: Quick local development setup
- CI/CD: Consistent build environment
- Future: Production deployment readiness

## Goals / Non-Goals

**Goals:**

- Single command to start both services: `docker compose up`
- Hot-reload development experience for both services
- Volume mounts for local filesystem access (~/src/...)
- Consistent development environment across all platforms
- Easy teardown: `docker compose down`

**Non-Goals:**

- Production-optimized builds (multi-stage builds for dev focus)
- Kubernetes manifests (out of scope)
- Container registry publishing (local development only)
- Database containers (backend uses local Git filesystem)
- Reverse proxy configuration (Traefik, Nginx)

## Decisions

### Decision 1: Multi-stage Dockerfile for Frontend

**What:** Use multi-stage build for SvelteKit frontend - build stage for production, dev stage for development with hot-reload.

**Why:**

- Separate concerns: build artifacts vs. dev dependencies
- Smaller production image size
- Development stage keeps node_modules and dev servers

**Alternatives considered:**

- Single-stage build: Simpler but larger image, includes dev tools in prod
- No multi-stage: Harder to maintain separate dev/prod configs

### Decision 2: Volume Mount Strategy

**What:** Mount local source directories to containers:

- Frontend: `./apps/web:/app` for hot-reload
- Backend: `./apps/backend:/app` for code changes
- Extra: `/home/sean/src:/host-src` for repository access

**Why:**

- Instant feedback during development (hot-reload)
- No need to rebuild containers on code changes
- Backend can access user's ~/src/ directory for Git operations

**Alternatives considered:**

- Copy code into container (no volumes): Requires rebuilds, slower dev cycle
- Bind mount entire repository: Too noisy, includes node_modules, etc.

### Decision 3: Network Configuration

**What:** Use default Docker Compose network, expose ports:

- Frontend: 5173:5173 (dev), 3000:80 (prod)
- Backend: 5000:8080
- Services communicate via service names (web, backend)

**Why:**

- Docker Compose creates default network automatically
- Service names work as DNS entries
- Port mapping allows localhost access from host

**Alternatives considered:**

- Custom network: Unnecessary complexity for simple setup
- No port exposure: Can't access from browser/dev tools

### Decision 4: Environment Variables

**What:** Configure via docker-compose.yml:

- Backend: ASPNETCORE_ENVIRONMENT=Development
- Frontend: VITE_API_URL=http://backend:8080

**Why:**

- Standard ASP.NET Core environment variable
- Vite uses VITE\_ prefix for client-side env vars
- Service name resolves to backend container IP

**Alternatives considered:**

- .env file: More secure, adds complexity
- Hardcoded URLs: Less flexible, harder for different environments

### Decision 5: Development Focus

**What:** Prioritize development experience (hot-reload, volumes) over production optimization in this change.

**Why:**

- Primary use case: Local development
- User explicitly requested local filesystem access
- Production deployment can be separate change

**Alternatives considered:**

- Production-optimized first: Missing hot-reload, harder for dev
- Both in one change: Too complex, larger scope

## Risks / Trade-offs

### Risk 1: Hot-Reload Issues on Docker for Desktop (Mac/Windows)

**Risk:** File watching may not work properly due to volume mount performance on Docker for Desktop.

**Mitigation:**

- Document known workarounds (polling, excluded paths)
- Test on all platforms (Linux, macOS, Windows)
- Provide fallback to manual rebuild if needed

### Risk 2: Permission Issues with Volume Mounts

**Risk:** Container user may not have permissions for mounted files (Linux especially).

**Mitigation:**

- Run containers as host user (USER flag in compose)
- Document permission requirements
- Consider .env file for UID/GID configuration

### Risk 3: Network Name Resolution

**Risk:** Frontend may not resolve backend service name in all Docker contexts.

**Mitigation:**

- Use Docker Compose's default network (DNS built-in)
- Document that services must be started together
- Add fallback to localhost:5000 for local dev

### Trade-off 1: Dev vs. Prod Configuration

**Trade-off:** Prioritizing development means production builds are not fully optimized (larger images, dev tools included).

**Acceptance:**

- User requested local filesystem access = development focus
- Production deployment is separate concern
- Can add prod-specific config later

### Trade-off 2: Security of Volume Mounts

**Trade-off:** Mounting entire ~/src/ directory exposes local filesystem to container.

**Acceptance:**

- Development environment only (not production)
- Container runs locally, not remote
- Backend only reads Git files, doesn't modify system

## Migration Plan

No migration needed - this is additive functionality. Existing manual startup continues to work.

**Steps to adopt Docker:**

1. Install Docker and Docker Compose
2. Run `docker compose up` from project root
3. Access frontend at http://localhost:5173
4. Stop with `docker compose down`

**Rollback:**

- Simply stop using Docker, revert to manual startup
- No code changes required to manual workflow

## Open Questions

- Should we add a production build target in docker-compose.yml?
- Do we need to configure CORS for the backend when running in Docker?
- Should we include health check endpoints for both services?
