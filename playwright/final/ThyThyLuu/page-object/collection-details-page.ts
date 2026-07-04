import { expect } from "@playwright/test";
import { Element } from "../core/element/element";
import { BasePage } from "./base-page";

export class CollectionDetailsPage extends BasePage {
    collectionTitle: Element;
    imageCountLabel: Element;
    figures: Element;

    constructor() {
        super();

        this.collectionTitle = new Element('//div[contains(@class,"titleContainer")]');
        this.imageCountLabel = new Element('//span[contains(text(),"images")]');
        this.figures = new Element('//figure[@data-testid="asset-grid-masonry-figure"]');
    }

    async getImageCount(): Promise<number> {
        const text = await this.imageCountLabel.getText();

        expect(text).not.toBeNull();

        return Number(text!.match(/\d+/)?.[0]);
    }

    async verifyCollectionDetails(collectionName: string, expectedImageCount: number): Promise<void> {
        await expect(
            this.page.getByText(collectionName, { exact: true })
        ).toBeVisible();

        const imageCount = await this.getImageCount();

        await this.figures.waitForElementVisible(10000);

        const figureCount = await this.figures.count();

        expect(imageCount).toBe(expectedImageCount);
        expect(figureCount).toBe(imageCount);
    }
}