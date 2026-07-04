
namespace FinalSelenium
{
    public class FormsTest : BaseTest
    {
        private FormsPage formsPage;
        private HomePage homePage;

        [SetUp]
        public void Init()
        {
            homePage = new HomePage(driver);
            formsPage = new FormsPage(driver);

            homePage.ClickForms();
        }

        [Test]
        public void NavigateToPracticeFormPage()
        {
            formsPage.ClickPracticeForm();

            formsPage.WaitForPracticeFormPage();

            Assert.That(driver.Url, Is.EqualTo(formsPage.expectedUrl));
        }
    }
}
