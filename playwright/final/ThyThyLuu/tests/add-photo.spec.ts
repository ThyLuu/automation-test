import { test } from '../fixture/page-fixture';
import accountData from '../test-data/ui/account-login-data.json';
import { LoginWorkflow } from '../workflow/ui/login-workflow';
import { CollectionWorkflow } from '../workflow/ui/collection-workflow';
import { CollectionApiWorkflow } from '../workflow/api/collection-api-workflow';

test.describe("Add photos into a collection", () => {
    test("Add 3 random photos into a collection successfully", async ({ loginPage, homePage, userProfilePage, collectionPage, collectionDetailsPage }) => {
        const numberOfPhotos = 3;
        const collectionName = `ThyCollection-${Date.now()}`;

        await LoginWorkflow.login(homePage, loginPage, accountData);

        const collection = await CollectionApiWorkflow.createCollection(collectionName);

        await homePage.addPhotosIntoCollection(collectionName, numberOfPhotos);

        await CollectionWorkflow.navigateToCollectionTab(
            homePage,
            userProfilePage
        );

        await collectionPage.verifyCollectionImages(collectionName, numberOfPhotos);
        await collectionPage.clickUserCollection(collectionName);
        await collectionDetailsPage.verifyCollectionDetails(
            collectionName,
            numberOfPhotos
        );
        await CollectionApiWorkflow.deleteCollection(collection.id);
    }
    );
});