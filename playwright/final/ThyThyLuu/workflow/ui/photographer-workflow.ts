import { HomePage } from "../../page-object/home-page";
import { PhotographerProfilePage } from "../../page-object/photographer-profile-page";

export class PhotographerWorkflow {
    static async openPhotographerProfile(homePage: HomePage): Promise<void> {
        await homePage.clickSecondPhoto();
        await homePage.hoverUserIcon();
        await homePage.clickViewPhotographerProfile();
    }

    static async verifyPhotographerProfile(photographerProfilePage: PhotographerProfilePage): Promise<void> {
        await photographerProfilePage.verifyPhotographerProfileDisplayed();
        await photographerProfilePage.clickMoreActions();
        await photographerProfilePage.verifyShareProfileMenuDisplayed();
        await photographerProfilePage.verifyReportButtonDisplayed();
    }
}
