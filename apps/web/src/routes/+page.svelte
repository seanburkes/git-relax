<script lang="ts">
import Layout from '$components/Layout.svelte';
import NavBar from '$components/NavBar.svelte';
import Footer from '$components/Footer.svelte';
</script>

<NavBar />

<Layout title="Status">
  {#snippet children()}
    <div class="space-y-4">
      <div class="bg-card border border-border rounded-lg p-4">
        <h3 class="text-sm font-semibold text-foreground mb-3">Changes</h3>
        <div class="space-y-2">
          <div class="flex items-center justify-between p-2 bg-muted/30 rounded">
            <div class="flex items-center space-x-2">
              <span class="text-green-500 font-medium">M</span>
              <span class="text-sm text-foreground">apps/web/src/routes/+page.svelte</span>
            </div>
            <span class="text-xs text-muted-foreground">modified</span>
          </div>
          <div class="flex items-center justify-between p-2 bg-muted/30 rounded">
            <div class="flex items-center space-x-2">
              <span class="text-green-500 font-medium">A</span>
              <span class="text-sm text-foreground">apps/web/src/components/Layout.svelte</span>
            </div>
            <span class="text-xs text-muted-foreground">added</span>
          </div>
          <div class="flex items-center justify-between p-2 bg-muted/30 rounded">
            <div class="flex items-center space-x-2">
              <span class="text-red-500 font-medium">D</span>
              <span class="text-sm text-foreground line-through">old-file.txt</span>
            </div>
            <span class="text-xs text-muted-foreground">deleted</span>
          </div>
        </div>
      </div>

      <div class="bg-card border border-border rounded-lg p-4">
        <h3 class="text-sm font-semibold text-foreground mb-3">Unstaged Changes</h3>
        <div class="text-sm text-muted-foreground italic">No unstaged changes</div>
      </div>
    </div>
  {/snippet}

  {#snippet detailsPanel()}
    <div class="space-y-4">
      <div class="bg-card border border-border rounded-lg p-4">
        <h3 class="text-sm font-semibold text-foreground mb-3">File Details</h3>
        <div class="text-sm text-muted-foreground">
          <div class="mb-2">
            <strong class="text-foreground">File:</strong> apps/web/src/routes/+page.svelte
          </div>
          <div class="mb-2"><strong class="text-foreground">Status:</strong> Modified</div>
          <div><strong class="text-foreground">Changes:</strong> +15, -8</div>
        </div>
      </div>

      <div class="bg-card border border-border rounded-lg p-4">
        <h3 class="text-sm font-semibold text-foreground mb-3">Branch Information</h3>
        <div class="text-sm text-muted-foreground">
          <div class="mb-2"><strong class="text-foreground">Current:</strong> main</div>
          <div class="mb-2"><strong class="text-foreground">Ahead:</strong> 0 commits</div>
          <div class="mb-2"><strong class="text-foreground">Behind:</strong> 1 commit</div>
          <div><strong class="text-foreground">Remote:</strong> origin/main</div>
        </div>
      </div>
    </div>
  {/snippet}

  {#snippet bottomPanel()}
    <div class="p-4">
      <h3 class="text-sm font-semibold text-foreground mb-2">Command Output</h3>
      <div class="text-xs text-muted-foreground font-mono space-y-1">
        <div>$ git status</div>
        <div>On branch main</div>
        <div>Changes not staged for commit:</div>
        <div>modified: apps/web/src/routes/+page.svelte</div>
        <div>new file: apps/web/src/components/Layout.svelte</div>
        <div>deleted: old-file.txt</div>
      </div>
    </div>
  {/snippet}
</Layout>

<Footer />
