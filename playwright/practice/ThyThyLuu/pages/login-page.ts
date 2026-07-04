import { expect, Page } from "@playwright/test";
import { BasePage } from "./base-page";
import { WebElement } from "../core/web-element";
import { LoginData } from "../data-object/login-data";
import { MESSAGES } from "../constant/message";

export class LoginPage extends BasePage {
    private txtUsername: WebElement;
    private txtPassword: WebElement;
    private btnLogin: WebElement;

    constructor(page: Page) {
        super(page);

        this.txtUsername = new WebElement(page, '#username');
        this.txtPassword = new WebElement(page, '#password');
        this.btnLogin = new WebElement(page, "input[value='Login']");
    }

    async login(loginData: LoginData) {
        await this.txtUsername.fill(loginData.username);
        await this.txtPassword.fill(loginData.password);
        await this.btnLogin.click();
    }

    // verify
    async verifyLoginSuccess() {
        await expect(this.page).toHaveURL(/#\!\/search$/);
    }

    async verifyIncorrectErrorMessageDisplayed() {
        const incorrectAlert = new WebElement(
            this.page,
            `//div[@role='alert' and contains(text(), '${MESSAGES.ERROR_INCORRECT}')]`
        );
        await incorrectAlert.verifyVisible();
    }

    async verifyRequiredMessageCountDisplayed(expectedCount: number) {
        const requiredAlert = new WebElement(
            this.page,
            `//p[contains(normalize-space(), '${MESSAGES.FIELD_REQUIRED}')]`
        );
        await requiredAlert.verifyCount(expectedCount);
    }
}