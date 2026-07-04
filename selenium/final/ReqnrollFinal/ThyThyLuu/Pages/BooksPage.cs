using OpenQA.Selenium;

public class BooksPage : BasePage
{
    private readonly WebObject _searchInput;
    private readonly WebObject _loginBtn;
    private readonly WebObject _profileBtn;

    private readonly By _bookTitle = By.XPath("//span[contains(@id,'see-book')]/a");


    public BooksPage(IWebDriver driver) : base(driver)
    {
        _searchInput = new WebObject(driver, By.Id("searchBox"), "Search input");
        _loginBtn = new WebObject(driver, By.Id("login"), "Login button");
        _profileBtn = new WebObject(driver, By.Id("a[href='/profile']"), "Profile button");
    }

    public void SearchBook(string keyword)
    {
        var input = _searchInput.GetElement();

        input.Clear();
        input.SendKeys(keyword);
    }

    public void ClickLoginBtn()
    {
        _loginBtn.ClickOnElement();
    }

    public List<string> GetAllBookTitles()
    {
        wait.Until(d =>
            d.FindElements(_bookTitle).Count > 0
        );

        return driver.FindElements(_bookTitle)
            .Select(e => e.Text.Trim())
            .ToList();
    }

    public bool IsAnyBookContains(string keyword)
    {
        var titles = GetAllBookTitles();

        return titles.Any(t =>
            !string.IsNullOrEmpty(t) &&
            t.Contains(keyword, StringComparison.OrdinalIgnoreCase)
        );
    }

    public bool AreAllBooksMatchKeyword(string keyword)
    {
        var titles = GetAllBookTitles();

        return titles.Count > 0 && titles.All(t =>
            t.Contains(keyword, StringComparison.OrdinalIgnoreCase)
        );
    }
}