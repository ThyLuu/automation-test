import { Page } from '@playwright/test';
import { BrowserManagement } from '../core/browser/browser-management';

export class BasePage {
    protected page: Page;

    constructor() {
        this.page = BrowserManagement.getCurrentPage();
    }

    async refreshPage(): Promise<void> {
        await this.page.reload();
    }

    async getCurrentUrl(): Promise<string> {
        return this.page.url();
    }

    async verifyUrlContains(text: string) {
        await this.page.waitForURL(url =>
            url.toString().includes(text),
            { timeout: 40000 }
        );
    }

    protected getRandomNumber(max: number): number {
        return Math.floor(Math.random() * max);
    }

    protected getRandomNumbers(count: number, max: number): number[] {
        const numbers = new Set<number>();

        while (numbers.size < count) {
            numbers.add(this.getRandomNumber(max));
        }

        return [...numbers];
    }

    async clickOutside() {
        await this.page.locator('body').click({
            position: { x: 10, y: 10 }
        });
    }
}