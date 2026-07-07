using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class BooksPage : BasePage
{
    public BooksPage(IWebDriver driver) : base(driver)
    {
    }

    private WebObject _searchInput = new WebObject(By.Id("searchBox"), "Search input");
    private WebObject _loginBtn = new WebObject(By.Id("login"), "Login button");
    private WebObject _bookTitle = new WebObject(By.XPath("//span[contains(@id, 'see-book')]/a"), "Book title");
    private WebObject _addToYourCollectionBtn = new WebObject(By.XPath("//button[contains(normalize-space(), 'Add To Your Collection')]"), "Add to your collection button");
    private WebObject _profileBtn = new WebObject(By.CssSelector("a[href='/profile']"), "Profile button");

    public void SearchBook(string book)
    {
        _searchInput.EnterText(book);

        ExtentReportHelper.LogInfo($"Searching book: {book}");
        ExtentReportHelper.LogPass($"Entered '{book}' into search input");
    }

    public void ClickLoginBtn()
    {
        _loginBtn.ClickOnElement();

        ExtentReportHelper.LogInfo("Click Login button");
    }

    public void ClickBookTitle()
    {
        _bookTitle.ClickOnElement();

        ExtentReportHelper.LogInfo("Click book title");
    }

    public void ClickAddToYourCollection()
    {
        _addToYourCollectionBtn.ScrollToCenter();
        _addToYourCollectionBtn.ClickOnElement();

        ExtentReportHelper.LogInfo("Add book to collection");
        ExtentReportHelper.LogPass("Book added to collection");
    }

    public void NavigateToProfilePage()
    {
        _profileBtn.ScrollToCenter();
        _profileBtn.ClickOnElement();

        ExtentReportHelper.LogInfo("Navigate to Profile page");
    }

    public void AcceptAlert()
    {
        WaitForAlert().Accept();

        ExtentReportHelper.LogInfo("Accept alert popup");
    }

    // Verify
    public List<string> GetAllBookTitles()
    {
        // var elements = driver.FindElements(By.XPath("//tbody/tr/td[2]//a"));

        // return elements
        //     .Select(e => e.Text.Trim())
        //     .ToList();

        return GetBookTitles();
    }
}