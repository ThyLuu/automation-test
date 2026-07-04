import { expect } from "@playwright/test";
import { Element } from "../core/element/element";
import { BasePage } from "./base-page";

export class CollectionPage extends BasePage {
    numberOfCollection: Element;
    collectionImages: Element;

    constructor() {
        super();

        this.numberOfCollection = new Element('//div[@data-testid="collection-feed-card"]//div[contains(@class, "description-")]');
        this.collectionImages = new Element('//div[contains(@class,"imagesContainer")]//img');
    }

    private getUserCollection(collectionName: string): Element {
        return new Element(
            `//a[.//div[normalize-space()="${collectionName}"]]`
        );
    }

    async waitImagesDisplay() {
        await this.collectionImages.waitForElementVisible(10000);
    }

    async getNumberOfImages(collectionName: string): Promise<number> {

        const card = this.page.locator(
            '[data-testid="collection-feed-card"]'
        ).filter({
            hasText: collectionName
        });

        const text = await card
            .locator('div[class*="description-"]')
            .textContent();

        return Number(text?.match(/\d+/)?.[0]);
    }

    async verifyCollectionImages(collectionName: string, expectedNumber: number): Promise<void> {
        const actualNumber = await this.getNumberOfImages(collectionName);

        expect(actualNumber).toBe(expectedNumber);

        await this.waitImagesDisplay();

        const imageCount = await this.collectionImages.count();

        expect(imageCount).toBeGreaterThan(0);
    }

    async clickUserCollection(collectionName: string): Promise<void> {
        await this.getUserCollection(collectionName).click();
    }
}