import { test } from '../fixture/page-fixture';
import accountData from '../test-data/ui/account-login-data.json';
import { LoginWorkflow } from '../workflow/ui/login-workflow';
import { PhotographerWorkflow } from '../workflow/ui/photographer-workflow';

test.describe("View Photographer Profile", () => {
    test("View photographer profile successfully", async ({ loginPage, homePage, photographerProfilePage }) => {
        await LoginWorkflow.login(homePage, loginPage, accountData);
        await PhotographerWorkflow.openPhotographerProfile(homePage);
        await PhotographerWorkflow.verifyPhotographerProfile(photographerProfilePage);
    }
    );
});