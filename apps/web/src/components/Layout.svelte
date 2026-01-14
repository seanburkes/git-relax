<script lang="ts">
let { title = 'Status', children, detailsPanel, bottomPanel } = $props();

const navItems = [
  { id: 'status', label: 'Status', active: true },
  { id: 'files', label: 'Files', active: false },
  { id: 'branches', label: 'Branches', active: false },
  { id: 'worktrees', label: 'Worktrees', active: false },
  { id: 'commits', label: 'Commits', active: false },
  { id: 'stash', label: 'Stash', active: false },
];
</script>

<div class="flex h-screen overflow-hidden bg-background text-foreground">
  <aside class="w-48 flex-shrink-0 border-r border-border bg-muted/30 flex flex-col">
    <div class="p-4 border-b border-border">
      <h1 class="text-lg font-bold text-primary">git-relax</h1>
    </div>
    <nav class="flex-1 overflow-y-auto p-2">
      <ul class="space-y-1">
        {#each navItems as item}
          <li>
            <button
              class="w-full text-left px-3 py-2 rounded-md text-sm transition-colors {item.active
                ? 'bg-primary text-primary-foreground font-medium'
                : 'text-muted-foreground hover:bg-secondary hover:text-foreground'}"
            >
              {item.label}
            </button>
          </li>
        {/each}
      </ul>
    </nav>
    <div class="p-4 border-t border-border">
      <div class="text-xs text-muted-foreground">
        <div>branch: <span class="text-foreground font-medium">main</span></div>
        <div>repo: <span class="text-foreground font-medium">git-relax</span></div>
      </div>
    </div>
  </aside>

  <main class="flex-1 flex flex-col min-w-0">
    <header class="h-12 border-b border-border bg-background flex items-center px-4">
      <h2 class="text-sm font-semibold text-foreground">{title}</h2>
    </header>

    <div class="flex-1 flex min-h-0">
      <div class="flex-1 overflow-y-auto p-4">
        {@render children()}
      </div>

      {#if detailsPanel}
        <aside class="w-80 flex-shrink-0 border-l border-border bg-muted/20 overflow-y-auto">
          {@render detailsPanel()}
        </aside>
      {/if}
    </div>

    {#if bottomPanel}
      <footer class="h-48 border-t border-border bg-muted/10 overflow-y-auto">
        {@render bottomPanel()}
      </footer>
    {/if}
  </main>
</div>
