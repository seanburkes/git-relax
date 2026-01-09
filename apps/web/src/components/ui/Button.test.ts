import { render } from '@testing-library/svelte';
import { expect, test, afterEach } from 'vitest';
import Button from '$components/ui/Button.svelte';

afterEach(() => {
  render(null);
});

test('renders button with default variant', () => {
  render(Button);
  const button = document.querySelector('button');
  expect(button).toBeInTheDocument();
});
