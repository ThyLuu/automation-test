import { test } from "../fixtures/base-fixture";
import { LoginData } from "../data-object/login-data";
import validData from "../data/valid-login-data.json" with { type: "json" };
import invalidData from "../data/invalid-login-data.json" with { type: "json" };

const validLoginDataObject = new LoginData(validData);
const invalidLoginDataObjects: LoginData[] = invalidData.map(data => new LoginData(data));

test.describe("Login Feature", () => {

  test("Login with valid account successfully", async ({ loginPage, searchPage, browserManagement }) => {
    
    await loginPage.navigate();
    await loginPage.login(validLoginDataObject);
    await loginPage.verifyLoginSuccess();
    await searchPage.verifySearchPageDisplayed();
  });

  for (const [index, data] of invalidLoginDataObjects.entries()) {
    test(`Login with invalid account case #${index + 1}: 
        username='${data.username}', 
        password='${data.password}'`,
      async ({ loginPage, browserManagement }) => {

        await loginPage.navigate();
        await loginPage.login(data);

        if (data.username === "" && data.password === "") {
          await loginPage.verifyRequiredMessageCountDisplayed(2);
        } else if (data.username === "" || data.password === "") {
          await loginPage.verifyRequiredMessageCountDisplayed(1);
        } else {
          await loginPage.verifyIncorrectErrorMessageDisplayed();
        }
      });
  }
});