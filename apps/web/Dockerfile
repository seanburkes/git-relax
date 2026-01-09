FROM node:22-alpine AS base

RUN npm install -g pnpm

WORKDIR /app

FROM base AS deps
COPY package*.json pnpm-lock.yaml ./
RUN pnpm install --frozen-lockfile

FROM base AS dev
COPY --from=deps /app/node_modules ./node_modules
COPY . .
EXPOSE 5173
CMD ["pnpm", "run", "dev", "--", "--host", "0.0.0.0"]

FROM base AS build
COPY --from=deps /app/node_modules ./node_modules
COPY . .
RUN pnpm run build

FROM base AS prod
COPY --from=build /app/build ./build
COPY --from=build /app/node_modules ./node_modules
COPY package*.json pnpm-lock.yaml ./
EXPOSE 3000
CMD ["pnpm", "run", "preview", "--", "--host", "0.0.0.0"]
