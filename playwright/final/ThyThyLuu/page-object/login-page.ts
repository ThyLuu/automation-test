import { AccountData } from './../data-object/ui/account-data';
import { Element } from "../core/element/element";
import { BasePage } from "./base-page";

export class LoginPage extends BasePage {
    inputEmail: Element;
    inputPassword: Element;
    buttonLogin: Element;

    constructor() {
        super();

        this.inputEmail = new Element('input[name="email"]');
        this.inputPassword = new Element('input[name="password"]');
        this.buttonLogin = new Element('button:has-text("Login")');
    }

    async waitForLoginPageToLoad(){
        await this.buttonLogin.waitForElementVisible(60000);
    }

    async fillEmail(email: string) {
        await this.inputEmail.enter(email);
    }

    async fillPassword(password: string) {
        await this.inputPassword.enter(password);
    }

    async clickLogin() {
        await this.buttonLogin.click();
        await this.buttonLogin.waitForPageStable(5000);
    }

    async login(accountData: AccountData) {
        await this.waitForLoginPageToLoad();
        await this.fillEmail(accountData.email);
        await this.fillPassword(accountData.password);
        await this.clickLogin();
    }
}