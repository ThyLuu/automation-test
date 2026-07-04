import { test } from '../fixture/page-fixture';
import accountData from '../test-data/ui/account-login-data.json';
import editUserData from '../test-data/ui/account-edit-data.json';
import restoreProfileData from '../test-data/api/account-profile-data.json';
import { BrowserUtils } from '../core/browser/browser-utils';
import { BASE_URL } from '../constant/url';
import { LoginWorkflow } from '../workflow/ui/login-workflow';
import { ProfileWorkflow } from '../workflow/ui/profile-workflow';
import { UserApiWorkflow } from '../workflow/api/user-api-workflow';

test.describe("Update User Profile", () => {
    test("Update the user in the Profile page successfully", async ({ loginPage, homePage, userProfilePage, userEditProfilePage }) => {
        await LoginWorkflow.login(homePage, loginPage, accountData);
        await ProfileWorkflow.navigateToMyProfile(homePage);

        await userProfilePage.clickEditProfileButton();
        await userEditProfilePage.editUserProfile(editUserData);
        await userEditProfilePage.refreshPage();

        await BrowserUtils.navigateTo( `${BASE_URL}/@${editUserData.username}`);

        await userProfilePage.verifyUserProfile(
            editUserData.username,
            editUserData.fullName
        );

        await UserApiWorkflow.restoreProfile(restoreProfileData);
    }
    );
});