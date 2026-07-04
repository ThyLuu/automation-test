import { Element } from "../core/element/element";
import { BasePage } from "./base-page";

export class UserProfilePage extends BasePage {
    userFullname: Element;
    buttonEditProfile: Element;
    tabCollection: Element;

    collectionFeedCard: Element;

    constructor() {
        super();

        this.userFullname = new Element('//div[contains(@class,"name-")]');
        this.buttonEditProfile = new Element('//a[contains(.,"Edit profile")]');
        this.tabCollection = new Element('//a[@data-testid="user-nav-link-collections"]');
        
        this.collectionFeedCard = new Element('//div[@data-testid="collection-feed-card"]');
    }

    async clickEditProfileButton() {
        await this.buttonEditProfile.click();
    }

    async clickCollectionTab(){
        this.tabCollection.click();
        this.collectionFeedCard.waitForElementVisible();
    }

    // verify
    async verifyProfileUrl(username: string) {
        await this.verifyUrlContains(`@${username}`);
    }

    async verifyFullName(fullName: string) {
        await this.userFullname.doesElementContainText(fullName);
    }

    async verifyUserProfile(username: string, fullName: string) {
        await this.verifyProfileUrl(username);
        await this.verifyFullName(fullName);
    }
}