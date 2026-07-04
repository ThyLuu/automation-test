import { Page } from "@playwright/test";
import { BasePage } from "./base-page";
import { WebElement } from "../core/web-element";

export class SearchPage extends BasePage {
    private btnCreateEmployee: WebElement;

    constructor(page: Page) {
        super(page);
        
        this.btnCreateEmployee = new WebElement(page, "button:has-text('Create employee')");
    }

    async verifySearchPageDisplayed() {
        await this.btnCreateEmployee.verifyVisible();
    }
}