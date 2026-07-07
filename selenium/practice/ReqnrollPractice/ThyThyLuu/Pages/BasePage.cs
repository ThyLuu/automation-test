using OpenQA.Selenium;

namespace ThyThyLuu.Pages;
public class BasePage
{
    protected IWebDriver driver;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
    }

}