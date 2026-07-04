using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver)
    {
    }

    private WebObject _formsCard = new WebObject(By.CssSelector("a[href='/forms']"), "Form card");
    private WebObject _booksCard = new WebObject(By.CssSelector("a[href='/books']"), "Book card");
    public string expectedFormsUrl => "https://demoqa.com/forms";
    public string expectedBooksUrl => "https://demoqa.com/books";

    public void ClickForms()
    {
        _formsCard.ClickOnElement();

        ExtentReportHelper.LogInfo("Click Forms card");
    }

    public void ClickBooks()
    {
        _booksCard.ClickOnElement();

        ExtentReportHelper.LogInfo("Click Books card");
    }

    public void NavigateToFormsPage()
    {
        ClickForms();
        WaitUntilUrlContains("/forms");

        ExtentReportHelper.LogInfo("Navigate to Forms page");
    }

    public void NavigateToBooksPage()
    {
        ClickBooks();
        WaitUntilUrlContains("/books");

        ExtentReportHelper.LogInfo("Navigate to Books page");
    }
}