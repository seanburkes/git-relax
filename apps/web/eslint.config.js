import typescript from '@typescript-eslint/eslint-plugin';
import svelte from 'eslint-plugin-svelte';
import prettier from 'eslint-plugin-prettier';
import globals from 'globals';
import tsParser from '@typescript-eslint/parser';

export default [
  {
    ignores: ['.svelte-kit/', 'build/', 'dist/', 'node_modules/'],
  },
  {
    files: ['**/*.{js,mjs,cjs,ts,svelte}'],
    languageOptions: {
      ecmaVersion: 2022,
      sourceType: 'module',
      globals: {
        ...globals.browser,
        ...globals.node,
        ...globals.es2021,
      },
      parserOptions: {
        extraFileExtensions: ['.svelte'],
      },
    },
    plugins: {
      '@typescript-eslint': typescript,
      svelte,
      prettier,
    },
    rules: {
      ...typescript.configs.recommended.rules,
      ...svelte.configs['flat/recommended'].rules,
      ...prettier.configs.recommended.rules,
      '@typescript-eslint/no-explicit-any': 'error',
      '@typescript-eslint/explicit-function-return-type': 'warn',
      '@typescript-eslint/no-unused-vars': ['error', { argsIgnorePattern: '^_' }],
      'svelte/no-at-html-tags': 'error',
    },
  },
  {
    files: ['**/*.svelte'],
    languageOptions: {
      parserOptions: {
        parser: tsParser,
      },
    },
  },
];
