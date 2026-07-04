using OpenQA.Selenium;
using Reqnroll;
using ThyThyLuu.Pages;

namespace ThyThyLuu.StepDefinitions;

[Binding]
public class SearchProjectSteps
{
    private readonly IWebDriver driver;
    // private readonly LoginPage loginPage;
    private readonly SearchProjectPage searchProjectPage;

    private SearchProjectInformation searchData = new();

    public SearchProjectSteps()
    {
        driver = TestHook.driver;

        // loginPage = new LoginPage(driver);
        searchProjectPage = new SearchProjectPage(driver);
    }

    [Given("the user navigate the Search Project page")]
    public void GivenTheUserNavigateTheSearchProjectPage()
    {
        searchProjectPage.SelectSearchType();

        searchProjectPage.CloseCriticalSearch();
    }

    [When("the user applies some search criteria")]
    public void WhenTheUserAppliesSomeSearchCriteria(Table table)
    {
        Dictionary<string, string> data = table.Rows
            .ToDictionary(
                row => row["Field"],
                row => row["Value"]
            );

        searchData = new SearchProjectInformation
        {
            ProjectName = data["ProjectName"],
            Location = data["Location"]
        };

        searchProjectPage.EnterProjectName(
            searchData.ProjectName
        );

        searchProjectPage.SelectLocation(
            searchData.Location
        );
    }

    [When("the user clicks on Search button")]
    public void WhenTheUserClicksOnSearchButton()
    {
        searchProjectPage.ClickSearchProject();
    }

    // [Then("all projects matched with input criteria will be displayed")]
    // public void ThenAllProjectsMatchedWithInputCriteriaWillBeDisplayed()
    // {
    //     searchProjectPage.WaitSearchResultLoaded();

    //     List<string> projectNames =
    //         searchProjectPage.GetProjectNames();

    //     Assert.That(
    //         projectNames.Count,
    //         Is.GreaterThan(0),
    //         "No project returned from search result."
    //     );

    //     foreach (string projectName in projectNames)
    //     {
    //         Assert.That(
    //             projectName,
    //             Does.Contain(searchData.ProjectName)
    //                 .IgnoreCase,
    //             $"Project '{projectName}' does not match search criteria."
    //         );
    //     }
    // }

    [Then("all projects matched with input criteria will be displayed")]
    public void ThenAllProjectsMatchedWithInputCriteriaWillBeDisplayed()
    {
        searchProjectPage.WaitSearchResultLoaded();

        Assert.That(
            searchProjectPage.IsProjectFoundInAllPages(
                searchData.ProjectName),
            Is.True,
            $"Project '{searchData.ProjectName}' was not found in search result."
        );
    }
}