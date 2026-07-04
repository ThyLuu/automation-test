import { CollectionData } from '../data-object/ui/collection-data';
import { Element } from "../core/element/element";
import { BasePage } from "./base-page";

export class HomePage extends BasePage {
    linkLogin: Element;
    secondPhoto: Element;
    photographerAvatar: Element;
    buttonViewPhotographerProfile: Element;

    userProfileIcon: Element;
    viewUserProfile: Element;

    buttonAddCollection: Element;
    // photoExceptUnplash: Element;
    photos: Element;
    addCollectionPopup: Element;
    collectionItem: Element;

    constructor() {
        super();

        this.secondPhoto = new Element('(//img[@data-testid="asset-grid-masonry-img"])[2]');
        this.photographerAvatar = new Element('//div[contains(@class,"photographer")]');
        this.buttonViewPhotographerProfile = new Element('//div[@role="presentation"]//a[text()="View profile"]');
        this.linkLogin = new Element('//a[text()="Log in"]');

        this.userProfileIcon = new Element('button[aria-label="Profile"]');
        this.viewUserProfile = new Element('//a[@role="menuitem" and contains(.,"View profile")]');

        // this.buttonAddCollection = new Element('//div[contains(@class,"popup-") and text()="Add to Collection"]');
        this.buttonAddCollection = new Element('button[aria-label="Add to Collection"]');

        // this.photoExceptUnplash = new Element('//figure[@data-testid="asset-grid-masonry-figure"][not(.//a[contains(@class,"unsplashPlusLink")])]');
        this.photos = new Element('//figure[@data-testid="asset-grid-masonry-figure"]');
        this.addCollectionPopup = new Element('//div[contains(@class,"root-") and .//input[@placeholder="Find a collection"]]');
        this.collectionItem = new Element('//div[@role="option"]');
    }

    async clickLinkLogin() {
        await this.linkLogin.click()
    }

    async clickSecondPhoto() {
        await this.secondPhoto.click();
    }

    async hoverUserIcon() {
        await this.photographerAvatar.hoverToElement();
    }

    async clickViewPhotographerProfile() {
        await this.buttonViewPhotographerProfile.waitForElementVisible();
        await this.buttonViewPhotographerProfile.click();
    }

    async clickUserProfileIcon() {
        await this.userProfileIcon.click();
    }

    async clickViewUserProfile() {
        await this.viewUserProfile.waitForElementVisible(10000);
        await this.viewUserProfile.click();
    }

    async getRandomPhotos(numberOfPhotos: number) {
        const photos = this.photos.getLocator();

        const totalPhotos = await photos.count();

        const randomIndexes = this.getRandomNumbers(
            Math.min(numberOfPhotos, totalPhotos),
            totalPhotos
        );

        return randomIndexes.map(index => photos.nth(index));
    }

    async hoverPhoto(index: number) {
        const photo = await this.photos.getNth(index);

        await photo.scrollIntoViewIfNeeded();
        await photo.hover({ timeout: 10000 });
    }

    async clickAddCollectionButton(index: number) {
        const photo = await this.photos.getNth(index);

        const button = photo
            .locator(this.buttonAddCollection.locator)
            .first();

        await button.click({ timeout: 10000 });
    }

    async selectCollection(collectionName: string): Promise<void> {
        await this.addCollectionPopup.waitForElementVisible(10000);

        const collection = this.page.locator(
            `//div[@role="option"][.//h4[text()="${collectionName}"]]`
        );

        await collection.click({ timeout: 10000 });
    }

    async closeCollectionPopup(): Promise<void> {
        await this.clickOutside();

        await this.addCollectionPopup.waitForElementHidden(10000);
    }

    async addPhotosIntoCollection(collectionName: string, numberOfPhotos: number) {
        const totalPhotos = await this.photos.count();

        const randomIndexes = this.getRandomNumbers(
            Math.min(numberOfPhotos, totalPhotos),
            totalPhotos
        );

        for (const index of randomIndexes) {

            await this.hoverPhoto(index);
            await this.clickAddCollectionButton(index);
            await this.selectCollection(collectionName);
            await this.closeCollectionPopup();
        }
    }
}