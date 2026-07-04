import { CollectionPage } from './../page-object/collections-page';
import { UserProfilePage } from './../page-object/user-profile-page';
import { UserEditProfilePage } from './../page-object/user-edit-profile-page';
import { PhotographerProfilePage } from './../page-object/photographer-profile-page';
import { test as baseTest, expect as baseExpect } from '../core/fixture/base-fixture';
import { HomePage } from '../page-object/home-page';
import { LoginPage } from '../page-object/login-page'
import { CollectionDetailsPage } from '../page-object/collection-details-page';

export const test = baseTest.extend<{
    homePage: HomePage
    loginPage: LoginPage;
    photographerProfilePage: PhotographerProfilePage;
    userProfilePage: UserProfilePage;
    userEditProfilePage: UserEditProfilePage;
    collectionPage: CollectionPage;
    collectionDetailsPage: CollectionDetailsPage;
}>({
    homePage: async ({ }, use) => {
        await use(new HomePage());
    },
    loginPage: async ({ }, use) => {
        await use(new LoginPage());
    },
    photographerProfilePage: async ({ }, use) => {
        await use(new PhotographerProfilePage());
    },
    userProfilePage: async ({ }, use) => {
        await use(new UserProfilePage());
    },
    userEditProfilePage: async ({ }, use) => {
        await use(new UserEditProfilePage());
    },
    collectionPage: async ({ }, use) => {
        await use(new CollectionPage());
    },
    collectionDetailsPage: async ({ }, use) => {
        await use(new CollectionDetailsPage());
    },
})

export const expect = baseExpect;