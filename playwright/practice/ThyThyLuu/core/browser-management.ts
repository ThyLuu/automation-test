import { BrowserContext, Page } from "@playwright/test";

export class BrowserManagement {

    constructor(
        private page: Page,
        private context: BrowserContext = page.context()
    ) { }

    async openNewTab(url: string): Promise<Page> {
        const newPage = await this.context.newPage();
        await newPage.goto(url);
        return newPage;
    }

    async switchToTab(index: number): Promise<Page> {
        return this.context.pages()[index];
    }

    async refresh(): Promise<void> {
        await this.page.reload();
    }

    async goBack(): Promise<void> {
        await this.page.goBack();
    }

    async goForward(): Promise<void> {
        await this.page.goForward();
    }

    async takeScreenshot(fileName: string): Promise<void> {
        const timestamp = new Date()
            .toISOString()
            .replace(/[:.]/g, "-");

        await this.page.screenshot({
            path: `screenshots/${fileName}-${timestamp}.png`,
            fullPage: true
        });
    }

    getCurrentUrl(): string {
        return this.page.url();
    }

    getTabCount(): number {
        return this.context.pages().length;
    }
}