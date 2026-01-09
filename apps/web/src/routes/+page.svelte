<script lang="ts">
  import NavBar from '$components/NavBar.svelte';
  import Footer from '$components/Footer.svelte';
</script>

<NavBar />

<main class="min-h-screen bg-background">
  <section class="container mx-auto px-4 py-16 md:py-24">
    <div class="max-w-3xl mx-auto text-center">
      <h1 class="text-5xl md:text-7xl font-bold text-foreground mb-6">
        Modern Git<br />
        <span class="text-primary">Made Simple</span>
      </h1>
      <p class="text-xl md:text-2xl text-muted-foreground mb-8">
        A beautiful, intuitive web interface for Git operations with a primary focus on
        worktree management for AI-assisted development workflows.
      </p>
      <div class="flex justify-center gap-4 mb-16">
        <button
          class="px-6 py-3 bg-primary text-primary-foreground rounded-lg hover:bg-primary/90 transition-colors font-medium"
        >
          Get Started
        </button>
        <button
          class="px-6 py-3 bg-secondary text-secondary-foreground rounded-lg hover:bg-secondary/80 transition-colors font-medium"
        >
          Learn More
        </button>
      </div>
    </div>

    <div class="grid md:grid-cols-3 gap-8 max-w-5xl mx-auto">
      <div class="bg-card border border-border rounded-lg p-6 hover:border-primary/50 transition-colors">
        <div class="w-12 h-12 bg-primary/10 rounded-lg flex items-center justify-center mb-4">
          <svg class="w-6 h-6 text-primary" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M19 11H5m14 0a2 2 0 012 2v6a2 2 0 01-2 2H5a2 2 0 01-2-2v-6a2 2 0 012-2m14 0V9a2 2 0 00-2-2M5 11V9a2 2 0 012-2m0 0V5a2 2 0 012-2h6a2 2 0 012 2v2M7 7h10"
            />
          </svg>
        </div>
        <h2 class="text-xl font-semibold text-foreground mb-2">Worktree Management</h2>
        <p class="text-muted-foreground">
          Create and manage multiple independent worktrees for concurrent development without
          context switching.
        </p>
      </div>

      <div class="bg-card border border-border rounded-lg p-6 hover:border-primary/50 transition-colors">
        <div class="w-12 h-12 bg-primary/10 rounded-lg flex items-center justify-center mb-4">
          <svg class="w-6 h-6 text-primary" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M13 10V3L4 14h7v7l9-11h-7z"
            />
          </svg>
        </div>
        <h2 class="text-xl font-semibold text-foreground mb-2">Git Operations</h2>
        <p class="text-muted-foreground">
          Complete Git operations from commit, push, pull to advanced features like
          interactive rebase and cherry-pick.
        </p>
      </div>

      <div class="bg-card border border-border rounded-lg p-6 hover:border-primary/50 transition-colors">
        <div class="w-12 h-12 bg-primary/10 rounded-lg flex items-center justify-center mb-4">
          <svg class="w-6 h-6 text-primary" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z"
            />
          </svg>
        </div>
        <h2 class="text-xl font-semibold text-foreground mb-2">Visual Diff</h2>
        <p class="text-muted-foreground">
          Beautiful diff visualization with inline, side-by-side, and unified views for
          easy code review.
        </p>
      </div>
    </div>
  </section>

  <section class="container mx-auto px-4 py-16 bg-muted/30">
    <div class="max-w-3xl mx-auto text-center">
      <h2 class="text-3xl font-bold text-foreground mb-4">AI-Ready Workflow</h2>
      <p class="text-lg text-muted-foreground mb-8">
        Designed for AI-assisted development. Each AI agent works in its own worktree,
        enabling parallel development and rapid code review.
      </p>
      <div class="grid md:grid-cols-2 gap-6 text-left">
        <div class="bg-card border border-border rounded-lg p-6">
          <h3 class="text-lg font-semibold text-foreground mb-3">
            Agent Isolation
          </h3>
          <p class="text-muted-foreground text-sm">
            Each AI agent operates in its own isolated worktree, preventing conflicts
            and enabling concurrent work.
          </p>
        </div>
        <div class="bg-card border border-border rounded-lg p-6">
          <h3 class="text-lg font-semibold text-foreground mb-3">
            Quick Review
          </h3>
          <p class="text-muted-foreground text-sm">
            Streamlined code review workflow for AI-generated code with one-click merge
            and synchronization.
          </p>
        </div>
      </div>
    </div>
  </section>
</main>

<Footer />
