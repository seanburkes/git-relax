import { expect, test } from '@playwright/test';

test.describe('Home Page', () => {
  test('has correct title', async ({ page }) => {
    await page.goto('/');
    await expect(page).toHaveTitle(/git-relax/i);
  });

  test('displays hero section', async ({ page }) => {
    await page.goto('/');
    const heroText = page.locator('h1');
    await expect(heroText).toBeVisible();
  });

  test('has responsive design on mobile', async ({ page }) => {
    // Test with mobile viewport (iPhone 12)
    await page.setViewportSize({ width: 390, height: 844 });
    await page.goto('/');
    const heroText = page.locator('h1');
    await expect(heroText).toBeVisible();
  });
});
