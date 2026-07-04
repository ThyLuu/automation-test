import { Element } from "../core/element/element";
import { EditUserData } from "../data-object/ui/edit-user-data";
import { BasePage } from "./base-page";

export class UserEditProfilePage extends BasePage {
    inputUsername: Element;
    buttonUpdateAccount: Element;

    constructor() {
        super();

        this.inputUsername = new Element('#user_username');
        this.buttonUpdateAccount = new Element('//input[@value="Update account"]');
    }

    async enterUsername(username: string){
        await this.inputUsername.enter(username);
    }

    async clickUpdateAccountButton(){
        await this.buttonUpdateAccount.scrollIntoView();
        await this.buttonUpdateAccount.click();
    }

    async editUserProfile(editUserData: EditUserData){
        await this.enterUsername(editUserData.username);
        await this.clickUpdateAccountButton();
    }
}