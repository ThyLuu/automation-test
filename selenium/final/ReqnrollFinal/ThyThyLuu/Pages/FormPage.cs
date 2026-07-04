using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class FormsPage : BasePage
{
    private WebObject _practiceForm;

    public FormsPage(IWebDriver driver) : base(driver)
    {
        _practiceForm = new WebObject(
            driver,
            By.CssSelector("a[href='/automation-practice-form']"),
            "Practice form");
    }

    public string expectedUrl => "https://demoqa.com/automation-practice-form";

    public void ClickPracticeForm()
    {
        _practiceForm.ClickOnElement();
    }

    public void WaitForPracticeFormPage()
    {
        WaitUntilUrlContains("/automation-practice-form");
    }
}