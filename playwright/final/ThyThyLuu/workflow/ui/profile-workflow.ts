import { HomePage } from "../../page-object/home-page";
import { UserProfilePage } from "../../page-object/user-profile-page";

export class ProfileWorkflow {
    static async navigateToMyProfile(homePage: HomePage, userProfilePage?: UserProfilePage): Promise<void> {
        await homePage.clickUserProfileIcon();
        await homePage.clickViewUserProfile();
    }
}
