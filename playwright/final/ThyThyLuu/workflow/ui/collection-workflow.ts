export class CollectionWorkflow {
    static async navigateToCollectionTab(homePage: any, userProfilePage: any): Promise<void> {
        await homePage.clickUserProfileIcon();
        await homePage.clickViewUserProfile();
        await userProfilePage.clickCollectionTab();
    }
}