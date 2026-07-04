using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class FormsPage : BasePage
{
    public FormsPage(IWebDriver driver) : base(driver)
    {
    }

    private WebObject _practiceForm = new WebObject(By.CssSelector("a[href='/automation-practice-form']"), "Practice form");
    public string expectedUrl => "https://demoqa.com/automation-practice-form";

    public void ClickPracticeForm()
    {
        _practiceForm.ClickOnElement();

        ExtentReportHelper.LogInfo("Click Practice Form");
        ExtentReportHelper.LogPass("Practice Form clicked successfully");
    }

    public void WaitForPracticeFormPage()
    {
        WaitUntilUrlContains("/automation-practice-form");
    }
}