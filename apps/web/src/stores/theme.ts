import { writable, get } from 'svelte/store';

type Theme = 'light' | 'dark';

const STORAGE_KEY = 'theme';

const getInitialTheme = (): Theme => {
  if (typeof window === 'undefined') return 'light';
  const stored = localStorage.getItem(STORAGE_KEY);
  if (stored === 'light' || stored === 'dark') return stored;
  return window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light';
};

function createThemeStore() {
  const { subscribe, set, update } = writable<Theme>(getInitialTheme());

  return {
    subscribe,
    set: (theme: Theme) => {
      set(theme);
      if (typeof window !== 'undefined') {
        localStorage.setItem(STORAGE_KEY, theme);
        if (theme === 'dark') {
          document.documentElement.classList.add('dark');
        } else {
          document.documentElement.classList.remove('dark');
        }
      }
    },
    toggle: () => {
      const current = get({ subscribe });
      const newTheme: Theme = current === 'light' ? 'dark' : 'light';
      set(newTheme);
    },
  };
}

export const theme = createThemeStore();
export const isDark = {
  subscribe: (fn: (value: boolean) => void) => theme.subscribe((t) => fn(t === 'dark')),
};
