<script lang="ts">
import '../app.css';
import { onMount } from 'svelte';
import { theme } from '../stores/theme';

onMount(() => {
  const stored = localStorage.getItem('theme');
  if (stored === 'dark' || stored === 'light') {
    theme.set(stored);
  } else if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
    theme.set('dark');
  } else {
    theme.set('light');
  }
});
</script>

<slot />
