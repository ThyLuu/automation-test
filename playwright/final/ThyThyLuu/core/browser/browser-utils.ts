import { BrowserManagement } from './browser-management';

export class BrowserUtils {
    static async navigateTo(url: string): Promise<void> {
        await BrowserManagement.page.goto(url);
    }
}