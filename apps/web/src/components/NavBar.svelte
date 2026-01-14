<script lang="ts">
import { theme, isDark } from '../stores/theme';
</script>

<nav
  class="border-b border-border bg-background/95 backdrop-blur supports-[backdrop-filter]:bg-background/60"
>
  <div class="container mx-auto px-4 h-16 flex items-center justify-between">
    <div class="flex items-center space-x-2">
      <span class="text-2xl font-bold text-primary">git-relax</span>
    </div>
    <div class="flex items-center space-x-4">
      <span class="text-sm text-foreground cursor-default hover:text-primary transition-colors"
        >Features</span
      >
      <span class="text-sm text-foreground cursor-default hover:text-primary transition-colors"
        >Documentation</span
      >
      <button
        on:click={() => theme.toggle()}
        class="px-3 py-1 text-sm bg-secondary hover:bg-secondary/80 rounded-md transition-colors"
      >
        {$isDark ? '☀️' : '🌙'}
      </button>
    </div>
  </div>
</nav>
