using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class ProfilePage : BasePage
{
    public ProfilePage(IWebDriver driver) : base(driver)
    {
    }

    private WebObject _goToBookStoreBtn = new WebObject(By.Id("gotoStore"), "Go to book store button");
    private WebObject _deleteBtn = new WebObject(By.XPath("//span[contains(@id, 'delete-record')]"), "Delete button");
    private WebObject _okBtn = new WebObject(By.Id("closeSmallModal-ok"), "OK button on delete book pop-up");

    public void ClickGoToBookStore()
    {
        _goToBookStoreBtn.ClickOnElement();

        ExtentReportHelper.LogInfo("Click Go To Book Store button");
    }

    public void ClickDeleteBtn()
    {
        _deleteBtn.ClickOnElement();

        ExtentReportHelper.LogInfo("Click Delete button");
    }

    public void ClickOkBtn()
    {
        _okBtn.ClickOnElement();

        ExtentReportHelper.LogInfo("Click Ok button on alert pop-up");
    }

    public void AcceptAlert()
    {
        WaitForAlert().Accept();
    }

    // Verify
    public List<String> GetBookTitle()
    {
        // return driver.FindElements(By.XPath("//tbody/tr/td[2]//a"))
        //     .Select(e => e.Text.Trim())
        //     .ToList();

        return GetBookTitles();
    }
}