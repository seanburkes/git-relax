<script lang="ts">
  import { cn } from '$lib/utils';
  import { buttonVariants } from './button';
  const { class: className, variant = 'default', size = 'default', ...restProps } = $props<{
    class?: string;
    variant?: 'default' | 'destructive' | 'outline' | 'secondary' | 'ghost' | 'link';
    size?: 'default' | 'sm' | 'lg' | 'icon';
  }>();
</script>

<button
  class={cn(buttonVariants({ variant, size, className }))}
  {...restProps}
  on:click
>
  <slot />
</button>
