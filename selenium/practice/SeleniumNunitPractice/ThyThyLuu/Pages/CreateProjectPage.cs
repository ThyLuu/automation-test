using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class CreateProjectPage : BasePage
{
    public CreateProjectPage(IWebDriver driver) : base(driver)
    {
    }

    private By projectBtn = By.XPath("//a[contains(normalize-space(), 'Projects')]");
    private By createProjectBtn = By.XPath("//a[@data-target='#modalCreateProject']");

    // Fill value into all fields
    private By projectNameInput = By.Id("name");
    private By projectTypeDropdown = By.Id("projecttype");
    private By projectStatusDropdown = By.Id("status");
    private By dateTitle = By.CssSelector("button.uib-title");
    private By nextBtn = By.CssSelector("button.uib-right");
    private By prevBtn = By.CssSelector("button.uib-left");
    private By startDatePick = By.XPath("//input[@ng-model='pcC.project.startDate']");
    private By endDatePick = By.XPath("//input[@ng-model='pcC.project.endDate']");
    private By sizeInput = By.Id("sizeday");
    private By locationDropdown = By.Id("location");
    private By projectManagerDropdown = By.Id("projectManager");
    private By deliveryDropdown = By.Id("deliveryManager");
    private By engagementDropdown = By.Id("engagementManager");
    private By shortDescriptionInput = By.Id("shortDescription");
    private By longDescriptionInput = By.Id("longDescription");
    private By technologiesInput = By.Id("technologies");
    private By clientNameInput = By.Id("clientName");
    private By clientIndustryDropdown = By.Id("clientindustry");
    private By clientDescriptionInput = By.Id("clientdescription");
    private By createBtn = By.CssSelector("form#newProject button#btnConfirm");


    private string projectDetailUrl = "/#!/project/";
    private By projectTitle = By.XPath("//h4[contains(.,'View project')]");

    // Implement function

    public void ClickProject()
    {
        driver.FindElement(projectBtn).Click();
    }

    public void ClickCreateProject()
    {
        driver.FindElement(createProjectBtn).Click();
    }

    public void EnterProjectName(string projectNameValue)
    {
        driver.FindElement(projectNameInput).SendKeys(projectNameValue);
    }

    public void SelectProjectType(string projectTypeValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(projectTypeDropdown));

        select.SelectByText(projectTypeValue);
    }

    public void SelectProjectStatus(string projectStatusValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(projectStatusDropdown));

        select.SelectByText(projectStatusValue);
    }

    public void SelectStartDate(string date)
    {
        SelectDate(startDatePick, date);
    }

    public void SelectEndDate(string date)
    {
        SelectDate(endDatePick, date);
    }

    private void SelectDate(By dateInput, string dateValue)
    {
        DateTime targetDate = DateTime.ParseExact(
            dateValue,
            "dd-MMM-yyyy",
            System.Globalization.CultureInfo.InvariantCulture
        );

        WebDriverWait wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(5)
        );

        // Open date picker
        wait.Until(
            d => d.FindElement(dateInput)
        ).Click();

        // click title 1: Day -> Month
        wait.Until(
            d => d.FindElement(dateTitle)
        ).Click();

        // click title 2: Month -> Year
        wait.Until(
            d => d.FindElement(dateTitle)
        ).Click();

        SelectYear(targetDate.Year);

        SelectMonth(targetDate.ToString("MMM"));

        SelectDay(targetDate.Day.ToString("00"));
    }

    private void SelectYear(int targetYear)
    {
        WebDriverWait wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(5)
        );

        while (true)
        {
            string yearRange =
                wait.Until(
                    d => d.FindElement(dateTitle)
                ).Text;

            string[] years = yearRange.Split('-');

            int startYear = int.Parse(years[0].Trim());
            int endYear = int.Parse(years[1].Trim());

            if (targetYear < startYear)
            {
                driver.FindElement(prevBtn).Click();
            }
            else if (targetYear > endYear)
            {
                driver.FindElement(nextBtn).Click();
            }
            else
            {
                driver.FindElement(
                    By.XPath(
                        $"//span[text()='{targetYear}']"
                    )
                ).Click();

                break;
            }
        }
    }

    private void SelectMonth(string month)
    {
        driver.FindElement(
            By.XPath(
                $"//span[text()='{month}']"
            )
        ).Click();
    }

    private void SelectDay(string day)
    {
        driver.FindElement(
            By.XPath($"//table[@class='uib-daypicker']//button/span[text()='{day}' and not(contains(@class, 'text-muted'))]")
        ).Click();
    }

    public void EnterSize(string sizeValue)
    {
        driver.FindElement(sizeInput).SendKeys(sizeValue);
    }

    public void SelectLocation(string locationValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(locationDropdown));

        select.SelectByText(locationValue);
    }

    public void SelectProjectManager(string projectManagerValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(projectManagerDropdown));

        select.SelectByText(projectManagerValue);
    }

    public void SelectDelivery(string deliveryValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(deliveryDropdown));

        select.SelectByText(deliveryValue);
    }

    public void SelectEngagementManager(string engagementValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(engagementDropdown));

        select.SelectByText(engagementValue);
    }

    public void EnterShortDescription(string shortDescriptionValue)
    {
        driver.FindElement(shortDescriptionInput).SendKeys(shortDescriptionValue);
    }

    public void EnterLongDescription(string longDescriptionValue)
    {
        driver.FindElement(longDescriptionInput).SendKeys(longDescriptionValue);
    }

    public void EnterTechnologies(string technologyValue)
    {
        driver.FindElement(technologiesInput).SendKeys(technologyValue);
    }

    public void EnterClientName(string clientNameValue)
    {
        driver.FindElement(clientNameInput).SendKeys(clientNameValue);
    }

    public void SelectClientIndustry(string clientIndustryValue)
    {
        SelectElement select = new SelectElement(driver.FindElement(clientIndustryDropdown));

        select.SelectByText(clientIndustryValue);
    }

    public void EnterClientDescription(string clientDescriptionValue)
    {
        driver.FindElement(clientDescriptionInput).SendKeys(clientDescriptionValue);
    }

    public void CreateNewProject()
    {
        driver.FindElement(createBtn).Click();
    }


    // verify
    public bool IsCreateProjectSuccess()
    {
        WebDriverWait wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(15)
        );

        return wait.Until(
            d => d.Url.Contains(projectDetailUrl)
        );
    }

    public string GetProjectTitle()
    {
        WebDriverWait wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(15)
        );

        IWebElement titleElement = wait.Until(
            d => d.FindElement(projectTitle)
        );

        return titleElement.Text.Trim();
    }
}