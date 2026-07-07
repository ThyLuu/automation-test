using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

[Binding]
public class StudentRegistrationStep
{
    private readonly HomePage _homePage;
    private readonly FormsPage _formsPage;
    private readonly PracticeFormPage _practiceFormPage;

    private StudentModel _studentData = new();

    public StudentRegistrationStep(TestContext context)
    {
        _homePage = new HomePage(context.Driver!);
        _formsPage = new FormsPage(context.Driver!);
        _practiceFormPage = new PracticeFormPage(context.Driver!);
    }

    [Given(@"the user is on Student Registration Form page")]
    public void GivenTheUserIsOnStudentRegistrationFormPage()
    {
        _homePage.ClickForms();
        _formsPage.ClickPracticeForm();
    }

    [When(@"the user input valid data into all fields")]
    public void WhenTheUserInputValidDataIntoAllFields(Table table)
    {
        _studentData = table.CreateInstance<StudentModel>();

        _practiceFormPage.FillStudentInformation(_studentData);
    }

    [When(@"the user clicks on Submit button")]
    public void WhenTheUserClicksOnSubmitButton()
    {
        _practiceFormPage.ClickSubmitBtn();
    }

    [Then(@"a successfully message ""(.*)"" is shown")]
    public void ThenASuccessfullyMessageIsShown(string expectedMessage)
    {
        Assert.That(
            _practiceFormPage.GetSuccessMessage(),
            Is.EqualTo(expectedMessage)
        );
    }

    [Then(@"all information of student form is shown")]
    public void ThenAllInformationOfStudentFormIsShown()
    {
        var expected = new Dictionary<string, string>
        {
            ["Student Name"] = $"{_studentData.FirstName} {_studentData.LastName}",
            ["Student Email"] = _studentData.Email,
            ["Gender"] = _studentData.Gender,
            ["Mobile"] = _studentData.Mobile,
            ["Date of Birth"] = DateTime.Parse(_studentData.DateOfBirth).ToString("dd MMMM,yyyy"),
            ["Subjects"] = _studentData.Subjects,
            ["Hobbies"] = _studentData.Hobbies,
            ["Picture"] = Path.GetFileName(_studentData.Picture),
            ["Address"] = _studentData.CurrentAddress,
            ["State and City"] = $"{_studentData.State} {_studentData.City}"
        };

        var actual = _practiceFormPage.GetSubmittedInformation();

        Assert.Multiple(() =>
        {
            foreach (var item in expected)
            {
                Assert.That(
                    actual[item.Key],
                    Is.EqualTo(item.Value),
                    $"Mismatch for '{item.Key}'"
                );
            }
        });
    }

}
