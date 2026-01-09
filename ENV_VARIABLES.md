# Environment Variables

This document describes the environment variables used in the git-relax project.

## Web Application (SvelteKit)

### Development

Create a `.env` file in `apps/web/` for local development:

```bash
# API Configuration
VITE_API_BASE_URL=http://localhost:5000/api

# Feature Flags
VITE_ENABLE_DEBUG_MODE=true
VITE_ENABLE_MOCK_API=false
```

### Production

Production environment variables should be set in your hosting platform (Vercel, Netlify, etc.) or deployment pipeline:

```bash
VITE_API_BASE_URL=https://api.git-relax.com
VITE_ENABLE_DEBUG_MODE=false
```

### Available Variables

| Variable | Description | Default | Required |
|----------|-------------|----------|----------|
| `VITE_API_BASE_URL` | Base URL for backend API | `http://localhost:5000/api` | No |
| `VITE_ENABLE_DEBUG_MODE` | Enable debug logging and features | `false` | No |
| `VITE_ENABLE_MOCK_API` | Use MSW to mock API responses | `false` | No |

## Backend (.NET)

### Development

Create `appsettings.Development.json` in `apps/backend/`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "GitSettings": {
    "DefaultRepositoryPath": "/home/user/repos"
  },
  "Cors": {
    "AllowedOrigins": [
      "http://localhost:5173",
      "http://localhost:4173"
    ]
  }
}
```

### Production

Create `appsettings.Production.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Error"
    }
  },
  "GitSettings": {
    "DefaultRepositoryPath": "/var/repos"
  }
}
```

### Available Settings

| Setting | Description | Required |
|----------|-------------|----------|
| `Logging:LogLevel` | Log verbosity by namespace | No |
| `AllowedHosts` | Allowed hostnames for requests | Yes |
| `GitSettings:DefaultRepositoryPath` | Default path for git repositories | No |
| `Cors:AllowedOrigins` | CORS allowed origins | Yes |

## Nx Workspace

### CI/CD

Set these variables in your CI/CD environment:

```bash
# Playwright
PLAYWRIGHT_BROWSERS_PATH=/path/to/browsers

# Nx
NX_REMOTE_CACHE_ENABLED=true
NX_REMOTE_CACHE_URL=https://your-cache.com
```

## Secrets Management

### Development

- Use `.env` files locally (not committed)
- Use environment-specific `.env.*` files
- Add `.env` and `appsettings.*.json` to `.gitignore`

### Production

- Use secrets management provided by your hosting platform:
  - Vercel: Environment Variables
  - Netlify: Environment Variables
  - AWS: Secrets Manager
  - Azure: Key Vault

## Examples

### Local Development Setup

```bash
# Web App (apps/web/.env)
VITE_API_BASE_URL=http://localhost:5000/api
VITE_ENABLE_DEBUG_MODE=true

# Backend (apps/backend/appsettings.Development.json)
{
  "Logging": { "LogLevel": { "Default": "Information" } },
  "AllowedHosts": "*",
  "Cors": { "AllowedOrigins": ["http://localhost:5173"] }
}
```

### Production Deployment

```bash
# Set via hosting platform
VITE_API_BASE_URL=https://api.git-relax.com
VITE_ENABLE_DEBUG_MODE=false
```

## Security Notes

1. **Never commit `.env` files** to version control
2. **Rotate secrets** regularly
3. **Use different environments** for dev, staging, and production
4. **Limit permissions** of secrets to minimum required
5. **Audit access** to secrets regularly

## See Also

- [SvelteKit Environment Variables](https://kit.svelte.dev/docs/environment-variables)
- [.NET Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Nx Environment Variables](https://nx.dev/reference/cli-variables)
