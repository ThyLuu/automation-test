using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalSelenium
{
    public class PracticeFormTest : BaseTest
    {
        private StudentModel student;
        private HomePage homePage;
        private FormsPage formsPage;
        private PracticeFormPage practiceFormPage;

        [SetUp]
        public void Init()
        {
            student = JsonUtils.ReadJson<StudentModel>("StudentData.json");

            homePage = new HomePage(driver);
            formsPage = new FormsPage(driver);
            practiceFormPage = new PracticeFormPage(driver);

            homePage.ClickForms();
            formsPage.ClickPracticeForm();
        }

        private void VerifyField(string label, string expected)
        {
            Assert.That(
                practiceFormPage.GetSubmittedValue(label),
                Is.EqualTo(expected)
            );
        }

        // Scenario 1.1: Register student with all fields successfully
        [Test]
        public void RegisterStudentWithAllFieldsSuccessfully()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            practiceFormPage.EnterFirstName(student.FirstName);
            practiceFormPage.EnterLastName(student.LastName);
            practiceFormPage.EnterEmail(student.Email);
            practiceFormPage.SelectGender(student.Gender);
            practiceFormPage.EnterMobile(student.Mobile);
            practiceFormPage.EnterDateOfBirth(student.DateOfBirth);
            practiceFormPage.EnterSubjects(student.Subjects);
            practiceFormPage.SelectHobbies(student.Hobbies);
            practiceFormPage.UploadPicture(student.Picture);
            practiceFormPage.EnterCurrentAddress(student.CurrentAddress);
            practiceFormPage.SelectState(student.State);
            practiceFormPage.SelectCity(student.City);
            practiceFormPage.ClickSubmitBtn();

            Assert.Multiple(() =>
            {
                Assert.That(practiceFormPage.GetSuccessMessage(), Is.EqualTo("Thanks for submitting the form"));

                VerifyField("Student Name", $"{student.FirstName} {student.LastName}");
                VerifyField("Student Email", student.Email);
                VerifyField("Gender", student.Gender);
                VerifyField("Mobile", student.Mobile);
                VerifyField("Date of Birth",
                    DateTime.Parse(student.DateOfBirth)
                        .ToString("dd MMMM,yyyy")
                );
                VerifyField("Subjects", student.Subjects);
                VerifyField("Hobbies", student.Hobbies);
                VerifyField("Picture", Path.GetFileName(student.Picture));
                VerifyField("Address", student.CurrentAddress);
                VerifyField("State and City", $"{student.State} {student.City}");
            });
        }

        // Scenario 1.1: Register student with all fields successfully
        [Test]
        public void RegisterStudentWithMandatoryFieldsSuccessfully()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            practiceFormPage.EnterFirstName(student.FirstName);
            practiceFormPage.EnterLastName(student.LastName);
            practiceFormPage.EnterEmail(student.Email);
            practiceFormPage.SelectGender(student.Gender);
            practiceFormPage.EnterMobile(student.Mobile);
            practiceFormPage.EnterDateOfBirth(student.DateOfBirth);
            practiceFormPage.ClickSubmitBtn();

            Assert.Multiple(() =>
            {
                Assert.That(practiceFormPage.GetSuccessMessage(), Is.EqualTo("Thanks for submitting the form"));
                
                VerifyField("Student Name", $"{student.FirstName} {student.LastName}");
                VerifyField("Student Email", student.Email);
                VerifyField("Gender", student.Gender);
                VerifyField("Mobile", student.Mobile);
                VerifyField("Date of Birth",
                    DateTime.Parse(student.DateOfBirth)
                        .ToString("dd MMMM,yyyy")
                );
            });
        }
    }
}