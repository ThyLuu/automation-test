using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticeSelenium
{
    public class CreateProjectTests : BaseTest
    {
        private ProjectInformation projectInformation = JsonHelper.ReadJson<ProjectInformation>("CreateProjectData.json");
        private LoginInformation loginInfomation = JsonHelper.ReadJson<LoginInformation>("UserData.json");
        private CreateProjectPage createProjectPage;
        private LoginPage loginPage;

        [SetUp]
        public void Init()
        {
            loginPage = new LoginPage(driver);
            createProjectPage = new CreateProjectPage(driver);

            string username = loginInfomation.Username;
            string password = loginInfomation.Password;
            loginPage.Login(username, password);
        }

        // Scenario 1: Create Project with all fields successfully
        [Test]
        public void CreateProjectWithAllFieldsSuccessfully()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            createProjectPage.ClickProject();
            createProjectPage.ClickCreateProject();

            createProjectPage.EnterProjectName(projectInformation.ProjectName);
            createProjectPage.SelectProjectType(projectInformation.ProjectType);
            createProjectPage.SelectProjectStatus(projectInformation.ProjectStatus);
            createProjectPage.SelectStartDate(projectInformation.StartDate);
            createProjectPage.SelectEndDate(projectInformation.EndDate);
            createProjectPage.EnterSize(projectInformation.Size);
            createProjectPage.SelectLocation(projectInformation.Location);
            createProjectPage.SelectProjectManager(projectInformation.ProjectManager);
            createProjectPage.SelectDelivery(projectInformation.DeliveryManager);
            createProjectPage.SelectEngagementManager(projectInformation.EngagementManager);
            createProjectPage.EnterShortDescription(projectInformation.ShortDescription);
            createProjectPage.EnterLongDescription(projectInformation.LongDescription);
            createProjectPage.EnterTechnologies(projectInformation.Technologies);
            createProjectPage.EnterClientName(projectInformation.ClientName);
            createProjectPage.SelectClientIndustry(projectInformation.ClientIndustry);
            createProjectPage.EnterClientDescription(projectInformation.ClientDescription);
            createProjectPage.CreateNewProject();

            // verify create new project success
        
            Assert.That(
                createProjectPage.IsCreateProjectSuccess(),
                Is.True
            );

            Assert.That(
                createProjectPage.GetProjectTitle(),
                Does.Contain(projectInformation.ProjectName)
            );
        }
    }
}
