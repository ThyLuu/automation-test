
namespace FinalSelenium
{
    public class HomeTest : BaseTest
    {
        private HomePage homePage;

        [SetUp]
        public void Init()
        {
            homePage = new HomePage(driver);
        }

        [Test]
        public void NavigateToFormsPage()
        {
            homePage.NavigateToFormsPage();

            Assert.That(driver.Url, Is.EqualTo(homePage.expectedFormsUrl));
        }

        [Test]
        public void NavigateToBooksPage()
        {
            homePage.NavigateToBooksPage();

            Assert.That(driver.Url, Is.EqualTo(homePage.expectedBooksUrl));
        }
    }
}
