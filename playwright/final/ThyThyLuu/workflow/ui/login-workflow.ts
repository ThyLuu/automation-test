import { LoginPage } from "../../page-object/login-page";
import { HomePage } from "../../page-object/home-page";
import { BrowserUtils } from "../../core/browser/browser-utils";
import { BASE_URL } from "../../constant/url";
import { AccountData } from "../../data-object/ui/account-data";

export class LoginWorkflow {
    static async login(homePage: HomePage,loginPage: LoginPage,account: AccountData): Promise<void> {
        await BrowserUtils.navigateTo(BASE_URL);
        await homePage.clickLinkLogin();
        await loginPage.login(account);
    }
}