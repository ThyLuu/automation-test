using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ThyThyLuu.Pages;

public class SearchProjectPage : BasePage
{
    public SearchProjectPage(IWebDriver driver) : base(driver)
    {
    }

    private By typeSearch_dropdowm = By.Id("type");
    private By projectName_txt = By.XPath("//input[@ng-model='input.projectname']");
    private By location_dropdown = By.Id("ddl-location");
    private By search_btn = By.XPath("//span[@id='searchProject']//button[@ng-click='search(input)']");
    private string searchUrl = "http://192.168.237.15:3000/#!/search";
    private By totalResult_lbl = By.XPath("//label[contains(.,'Total Results')]");
    private By resultRows = By.XPath("//tbody/tr");
    private By projectNameColumn = By.XPath("./td[1]");

    private By next_btn = By.XPath("//ul[contains(@class,'pagination')]//a[contains(text(),'›')]");
    private By next_btn_enable = By.XPath("//li[a[contains(text(),'›')]]");

    public void SelectSearchType()
    {
        SelectElement select = new SelectElement(driver.FindElement(typeSearch_dropdowm));

        select.SelectByText("Project");
    }

    public void CloseCriticalSearch()
    {
        driver.FindElement(By.TagName("body")).Click();
    }

    public void EnterProjectName(string projectNameValue)
    {
        driver.FindElement(projectName_txt).SendKeys(projectNameValue);
    }

    public void SelectLocation(string locationValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(location_dropdown));

        select.SelectByText(locationValue);
    }

    public void ClickSearchProject()
    {
        driver.FindElement(search_btn).Click();
    }

    public void WaitSearchResultLoaded()
    {
        WebDriverWait wait = new WebDriverWait(driver,
            TimeSpan.FromSeconds(15));

        wait.Until(d => d.Url.Contains("/#!/search?"));

        wait.Until(d =>
            d.FindElement(totalResult_lbl).Displayed);
    }


    // verify
    public List<string> GetProjectNames()
    {
        IList<IWebElement> rows =
            driver.FindElements(resultRows);

        List<string> projectNames = new List<string>();

        foreach (IWebElement row in rows)
        {
            string projectName = row
                .FindElement(projectNameColumn)
                .Text
                .Trim();

            if (!string.IsNullOrEmpty(projectName))
            {
                projectNames.Add(projectName);
            }
        }

        return projectNames;
    }

    private bool IsProjectDisplayedOnCurrentPage(
        string projectName)
    {
        IList<IWebElement> rows =
            driver.FindElements(resultRows);

        return rows.Any(row =>
            row.FindElement(projectNameColumn)
                .Text
                .Trim()
                .Contains(
                    projectName,
                    StringComparison.OrdinalIgnoreCase));
    }

    private bool HasNextPage()
    {
        IWebElement nextLi =
            driver.FindElement(next_btn_enable);

        string classValue =
            nextLi.GetAttribute("class") ?? "";

        return !classValue.Contains("disabled");
    }

    private void GoToNextPage()
    {
        string currentPage =
            driver.FindElement(
                By.XPath("//li[contains(@class,'active')]/a"))
            .Text;

        driver.FindElement(next_btn).Click();

        WebDriverWait wait = new(
            driver,
            TimeSpan.FromSeconds(10));

        wait.Until(d =>
            d.FindElement(
                By.XPath("//li[contains(@class,'active')]/a"))
            .Text != currentPage);

        wait.Until(d =>
            d.FindElements(resultRows).Count > 0);
    }

    public bool IsProjectFoundInAllPages(
        string projectName)
    {
        do
        {
            if (IsProjectDisplayedOnCurrentPage(projectName))
            {
                return true;
            }

            if (!HasNextPage())
            {
                break;
            }

            GoToNextPage();
        }
        while (true);

        return false;
    }
}