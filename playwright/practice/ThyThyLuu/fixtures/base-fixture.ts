import { test as base } from "@playwright/test";
import { LoginPage } from "../pages/login-page";
import { SearchPage } from "../pages/search-page";
import { BrowserManagement } from "../core/browser-management";

type PageFixtures = {
    loginPage: LoginPage;
    searchPage: SearchPage;
    browserManagement: BrowserManagement;
};

export const test = base.extend<PageFixtures>({
    browserManagement: async ({ page }, use) => {
        await use(new BrowserManagement(page));
    },

    loginPage: async ({ page }, use) => {
        await use(new LoginPage(page));
    },

    searchPage: async ({ page }, use) => {
        await use(new SearchPage(page));
    },
});

export { expect } from "@playwright/test";