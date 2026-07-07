using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ProfilePage : BasePage
{
    private readonly WebObject _deleteBtn;
    private WebObject _okBtn;
    private WebObject _searchInput;

    public ProfilePage(IWebDriver driver) : base(driver)
    {
        _deleteBtn = new WebObject(driver, By.XPath("//span[contains(@id, 'delete-record')]"), "Delete button");
        _okBtn = new WebObject(driver, By.Id("closeSmallModal-ok"), "OK button on delete book pop-up");
        _searchInput = new WebObject(driver, By.Id("searchBox"), "Search bar");
    }

    public void SearchBook(string book)
    {
        _searchInput.EnterText(book + Keys.Enter);
    }

    public void ClickDeleteBtn()
    {
        _deleteBtn.ClickOnElement();
    }

    public void ClickOkBtn()
    {
        _okBtn.ClickOnElement();
    }

    public void AcceptAlert()
    {
        WaitForAlert().Accept();
    }

    // Verify
    public string GetLoggedInUsername()
    {
        return WaitUntilVisible(
            By.Id("userName-value")
        ).Text;
    }

    public List<String> GetBookTitle()
    {
        return driver.FindElements(By.XPath("//tbody/tr/td[2]//a"))
            .Select(e => e.Text.Trim())
            .ToList();
    }
}