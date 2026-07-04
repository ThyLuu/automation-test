import { Locator, Page, expect } from "@playwright/test";

export class WebElement {
    protected page: Page;
    protected selector: string;

    constructor(page: Page, selector: string) {
        this.page = page;
        this.selector = selector;
    }

    get locator(): Locator {
        return this.page.locator(this.selector);
    }

    async fill(value: string): Promise<void> {
        await this.locator.fill(value);
    }

    async click(): Promise<void> {
        await this.locator.click();
    }

    async verifyVisible(): Promise<void> {
        await expect(this.locator).toBeVisible();
    }

    async verifyCount(count: number): Promise<void> {
        await expect(this.locator).toHaveCount(count);
    }
}