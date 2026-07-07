using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
}