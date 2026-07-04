import { APIRequestContext, Browser, BrowserContext, Page } from '@playwright/test'

export class BrowserManagement {
    static browser: Browser;
    static browserContext: BrowserContext;
    static page: Page;
    static request: APIRequestContext;

    static initializeBrowser(browser: Browser, browserContext: BrowserContext, page: Page, request: APIRequestContext) {
        BrowserManagement.browser = browser;
        BrowserManagement.browserContext = browserContext;
        BrowserManagement.page = page;
        BrowserManagement.request = request
    }

    static setCurrentContext(browserContext: BrowserContext): void {
        BrowserManagement.browserContext = browserContext;
    }

    static setCurrentPage(page: Page): void {
        BrowserManagement.page = page;
    }

    static getCurrentPage(): Page {
        return BrowserManagement.page;
    }

    static async resetContextAndOpenNewPage(): Promise<void> {
        await this.browserContext.close();

        const newContext = await this.browser.newContext();
        this.setCurrentContext(newContext);
        
        const newPage = await newContext.newPage();
        this.setCurrentPage(newPage);
    }

    static getCurrentRequest(): APIRequestContext{
        return this.request;
    }
}