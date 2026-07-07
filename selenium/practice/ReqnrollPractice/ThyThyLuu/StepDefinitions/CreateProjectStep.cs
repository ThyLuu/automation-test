using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.Assist;
using ThyThyLuu.Pages;

namespace ThyThyLuu.StepDefinitions;

[Binding]
public class CreateProjectSteps
{
    private readonly IWebDriver driver;
    private readonly CreateProjectPage createProjectPage;

    private ProjectInformation project = new();

    public CreateProjectSteps()
    {
        driver = TestHook.driver;
        createProjectPage = new CreateProjectPage(driver);
    }

    private string NormalizeUser(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return string.Empty;
        }

        return value.Contains('(')
            ? value.Split('(')[0].Trim()
            : value.Trim();
    }

    [Given("the user navigates to Create Project page")]
    public void GivenTheUserNavigatesToCreateProjectPage()
    {
        createProjectPage.ClickProject();
        createProjectPage.ClickCreateProject();
    }

    [When("the user fills in all project information")]
    public void WhenTheUserFillsInAllProjectInformation(Table table)
    {
        project = table.CreateInstance<ProjectInformation>();

        createProjectPage.FillProjectInformation(project);
    }

    [When("the user clicks Create button")]
    public void WhenTheUserClicksCreateButton()
    {
        createProjectPage.CreateNewProject();
    }

    [Then("all information of the project is shown")]
    public void ThenAllInformationOfTheProjectIsShown()
    {
        Assert.That(
            createProjectPage.IsCreateProjectSuccess(),
            Is.True
        );

        Assert.That(
            createProjectPage.GetProjectTitle(),
            Does.Contain("View project")
        );

        var expectedValues = new Dictionary<string, string>
    {
        { "Project Name", project.ProjectName },
        { "Project Type", project.ProjectType },
        { "Project Status", project.ProjectStatus },
        { "Start Date", project.StartDate },
        { "End Date", project.EndDate },
        { "Size (days)", project.Size },
        { "Location", project.Location },

        // User fields
        { "Project Manager", NormalizeUser(project.ProjectManager) },
        { "Delivery / Program Manager", NormalizeUser(project.DeliveryManager) },
        { "Engagement Manager", NormalizeUser(project.EngagementManager) },

        { "Short Description", project.ShortDescription },
        { "Long Description", project.LongDescription },
        { "Technologies", project.Technologies },
        { "Client Name", project.ClientName },
        { "Client Industry / Sector", project.ClientIndustry },
        { "Client Description", project.ClientDescription }
    };

        Assert.Multiple(() =>
        {
            foreach (var item in expectedValues)
            {
                Assert.That(
                    createProjectPage.GetFieldValue(item.Key),
                    Is.EqualTo(item.Value),
                    $"Incorrect value for {item.Key}"
                );
            }
        });
    }
}