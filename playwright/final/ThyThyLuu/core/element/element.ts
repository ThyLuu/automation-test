import { expect, Locator } from "@playwright/test";
import { BrowserManagement } from "../browser/browser-management";

export class Element {
    locator: string;

    constructor(locator: string) {
        this.locator = locator;
    }

    async doesElementHaveText(expectedText: string): Promise<void> {
        await expect(BrowserManagement.page.locator(this.locator))
            .toHaveText(expectedText);
    }

    async doesElementContainText(expectedText: string): Promise<void> {
        await expect(BrowserManagement.page.locator(this.locator))
            .toContainText(expectedText);
    }

    async click(timeout = 10000): Promise<void> {
        await BrowserManagement.page.locator(this.locator)
            .click({ timeout: timeout, force: true });
    }

    async enter(text: string, timeout = 10000): Promise<void> {
        await BrowserManagement.page.locator(this.locator)
            .fill(text, { timeout: timeout });
    }

    async selectOption(option: string, timeout = 10000): Promise<void> {
        await BrowserManagement.page.locator(this.locator)
            .selectOption(option, { timeout: timeout });
    }

    async waitForElement(option?: Parameters<Locator['waitFor']>[0]): Promise<void> {
        await BrowserManagement.page.locator(this.locator)
            .waitFor(option);
    }

    async verifyAttribute(attribute: string, value: string): Promise<void> {
        await expect(
            BrowserManagement.page.locator(this.locator)
        ).toHaveAttribute(attribute, value);
    }

    async getText(): Promise<string | null> {
        let text = await BrowserManagement.page.locator(this.locator).textContent();
        return text ? text.trim() : null;
    }

    async waitForElementVisible(timeout?: number): Promise<void> {
        await BrowserManagement.page.waitForSelector(this.locator, { state: 'visible', timeout })
    }

    async waitForElementHidden(timeout?: number): Promise<void> {
        await BrowserManagement.page.waitForSelector(this.locator, { state: 'hidden', timeout }
        );
    }

    async verifyElementIsEnabled() {
        await expect(BrowserManagement.page.locator(this.locator)).toBeEnabled();
    }

    async isElementVisible(): Promise<boolean> {
        try {
            return await BrowserManagement.page.locator(this.locator).isVisible();
        } catch {
            return false;
        }
    }

    async hoverToElement(timeout = 10000): Promise<void> {
        const element = BrowserManagement.page.locator(this.locator);

        await element.waitFor({
            state: 'visible',
            timeout
        });

        await element.hover({
            timeout,
            force: true
        });
    }

    async scrollIntoView(): Promise<void> {
        await BrowserManagement.page.locator(this.locator).scrollIntoViewIfNeeded();
    }

    async waitForPageStable(timeout: number) {
        await BrowserManagement.page.waitForLoadState('networkidle', { timeout });
    }

    getLocator(): Locator {
        return BrowserManagement.page.locator(this.locator);
    }

    async count(): Promise<number> {
        return await this.getLocator().count();
    }

    async getNth(index: number): Promise<Locator> {
        return this.getLocator().nth(index);
    }
}