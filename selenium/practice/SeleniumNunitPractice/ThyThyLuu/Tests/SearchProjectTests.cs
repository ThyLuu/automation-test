using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticeSelenium
{
    public class SearchProjectTests : BaseTest
    {
        private LoginInformation loginInformation = JsonHelper.ReadJson<LoginInformation>("UserData.json");
        private SearchProjectInformation searchProjectInfomation = JsonHelper.ReadJson<SearchProjectInformation>("SearchProjectData.json");
        private SearchProjectPage searchProjectPage;
        private LoginPage loginPage;

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage(driver);
            searchProjectPage = new SearchProjectPage(driver);

            string username = loginInformation.Username;
            string password = loginInformation.Password;
            loginPage.Login(username, password);
        }

        // Scenario 1: Search project with any criteria successfully
        [Test]
        public void SearchProjectWithAnyCriteriaSuccessfully()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            searchProjectPage.SelectSearchType();

            searchProjectPage.EnterProjectName(searchProjectInfomation.ProjectName);
            searchProjectPage.SelectLocation(searchProjectInfomation.Location);
            searchProjectPage.ClickSearchProject();

            searchProjectPage.WaitSearchResultLoaded();

            List<string> projectNames =
                searchProjectPage.GetProjectNames();

            Assert.That(projectNames.Count,
                Is.GreaterThan(0));

            foreach (string projectName in projectNames)
            {
                Assert.That(
                    projectName,
                    Does.Contain(searchProjectInfomation.ProjectName),
                    $"Project name mismatch: {projectName}"
                );
            }
        }
    }
}
