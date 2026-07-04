using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class HomePage : BasePage
{

    private WebObject _formsCard;
    private WebObject _booksCard;

    public HomePage(IWebDriver driver) : base(driver)
    {
        _formsCard = new WebObject(driver, By.CssSelector("a[href='/forms']"), "Form card");
        _booksCard = new WebObject(driver, By.CssSelector("a[href='/books']"), "Book card");
    }

    public string expectedFormsUrl => "https://demoqa.com/forms";
    public string expectedBooksUrl => "https://demoqa.com/books";

    public void ClickForms()
    {
        _formsCard.ScrollToCenter();
        _formsCard.ClickOnElement();
    }

    public void ClickBooks()
    {
        _booksCard.ScrollToCenter();
        _booksCard.ClickOnElement();
    }

    public void NavigateToFormsPage()
    {
        ClickForms();
        WaitUntilUrlContains("/forms");
    }

    public void NavigateToBooksPage()
    {
        ClickBooks();

        WaitUntilUrlContains("/books");

        driver.ScrollToTop();
    }
}