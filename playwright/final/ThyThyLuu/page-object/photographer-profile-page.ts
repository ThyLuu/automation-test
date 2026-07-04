import { Element } from "../core/element/element";
import { BasePage } from "./base-page";

export class PhotographerProfilePage extends BasePage {
    photographerAvatar: Element;
    photographerName: Element;
    buttonEmail: Element;
    buttonMoreActions: Element;
    introduce: Element;
    interests: Element;
    photosList: Element;
    collectionsList: Element;

    menuShareProfile: Element;
    buttonReport: Element;

    constructor() {
        super();

        this.photographerAvatar = new Element('//img[contains(@alt,"Avatar of user")]');
        this.photographerName = new Element('//div[contains(@class,"name-")]');
        this.buttonEmail = new Element('//button[contains(@title,"Message")]');
        this.buttonMoreActions = new Element('//button[@aria-label="More Actions"]');
        this.introduce = new Element('//div[contains(@class,"bio-")]');
        this.interests = new Element('//div[text()="Interests"]');
        this.photosList = new Element('//a[@data-testid="user-nav-link-photos"]');
        this.collectionsList = new Element('//a[@data-testid="user-nav-link-collections"]');

        this.menuShareProfile = new Element('//div[@role="menuitem" and contains(.,"Share profile")]');
        this.buttonReport = new Element('//button[@role="menuitem" and text()="Report"]');
    }

    async clickMoreActions() {
        await this.buttonMoreActions.click();
    }

    async verifyShareProfileMenuDisplayed() {
        await this.menuShareProfile.waitForElementVisible();
    }

    async verifyReportButtonDisplayed() {
        await this.buttonReport.waitForElementVisible();
    }

    private async verifyOptionalElement(element: Element) {
        if (await element.isElementVisible()) {
            await element.waitForElementVisible();
        }
    }

    async verifyPhotographerProfileDisplayed() {
        await this.photographerAvatar.waitForElementVisible();
        await this.photographerName.waitForElementVisible();
        await this.buttonEmail.waitForElementVisible();
        await this.buttonMoreActions.waitForElementVisible();
        await this.introduce.waitForElementVisible();
        await this.photosList.waitForElementVisible();
        await this.collectionsList.waitForElementVisible();

        await this.verifyOptionalElement(this.interests);
    }
}