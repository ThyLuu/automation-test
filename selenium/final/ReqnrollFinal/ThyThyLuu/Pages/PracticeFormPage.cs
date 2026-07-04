using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

public class PracticeFormPage : BasePage
{
    private readonly WebObject _firstNameInput;
    private readonly WebObject _lastNameInput;
    private readonly WebObject _emailInput;
    private readonly WebObject _mobileInput;
    private readonly WebObject _dateOfBirthInput;
    private readonly WebObject _subjectsInput;
    private readonly WebObject _pictureInput;
    private readonly WebObject _currentAddressInput;
    private readonly WebObject _stateDropdown;
    private readonly WebObject _cityDropdown;
    private readonly WebObject _submitBtn;

    public PracticeFormPage(IWebDriver driver) : base(driver)
    {
        _firstNameInput = new WebObject(driver, By.Id("firstName"), "First name input");
        _lastNameInput = new WebObject(driver, By.Id("lastName"), "Last name input");
        _emailInput = new WebObject(driver, By.Id("userEmail"), "Email input");
        _mobileInput = new WebObject(driver, By.Id("userNumber"), "Mobile phone input");
        _dateOfBirthInput = new WebObject(driver, By.Id("dateOfBirthInput"), "Date of birth input");
        _subjectsInput = new WebObject(driver, By.Id("subjectsInput"), "Subjects input");
        _pictureInput = new WebObject(driver, By.Id("uploadPicture"), "Picture input");
        _currentAddressInput = new WebObject(driver, By.Id("currentAddress"), "Current address input");
        _stateDropdown = new WebObject(driver, By.Id("react-select-3-input"), "State dropdown");
        _cityDropdown = new WebObject(driver, By.Id("react-select-4-input"), "City dropdown");
        _submitBtn = new WebObject(driver, By.Id("submit"), "Submit button");
    }

    private WebObject _genderRadio(string value)
    {
        return new WebObject(
            driver,
            By.XPath($"//label[text()='{value}']"),
            $"{value} gender radio"
        );
    }

    private WebObject _hobbyCheckbox(string value)
    {
        return new WebObject(
            driver,
            By.XPath($"//label[text()='{value}']"),
            $"{value} hobby checkbox"
        );
    }

    public void EnterFirstName(string firstName)
    {
        _firstNameInput.EnterText(firstName);
    }

    public void EnterLastName(string lastName)
    {
        _lastNameInput.EnterText(lastName);
    }

    public void EnterEmail(string email)
    {
        _emailInput.EnterText(email);
    }

    public void SelectGender(string gender)
    {
        _genderRadio(gender).ClickOnElement();
    }

    public void EnterMobile(string mobile)
    {
        _mobileInput.EnterText(mobile);
    }

    public void EnterDateOfBirth(string dateOfBirth)
    {
        _dateOfBirthInput.SelectDate(dateOfBirth);
        _dateOfBirthInput.ScrollToCenter();
    }

    public void EnterSubjects(string subject)
    {
        _subjectsInput.EnterText(subject);
        _subjectsInput.EnterText(Keys.Enter);
    }

    public void SelectHobbies(string hobby)
    {
        _hobbyCheckbox(hobby).ClickOnElement();
    }

    public void UploadPicture(string picture)
    {
        _pictureInput.EnterText(picture);
        _pictureInput.ScrollToCenter();
    }

    public void EnterCurrentAddress(string currentAddress)
    {
        _currentAddressInput.EnterText(currentAddress);
    }

    public void SelectState(string state)
    {
        _stateDropdown.EnterText(state + Keys.Enter);
    }

    public void SelectCity(string city)
    {
        _cityDropdown.EnterText(city + Keys.Enter);
    }

    public void FillStudentInformation(StudentModel student)
    {
        EnterFirstName(student.FirstName);
        EnterLastName(student.LastName);
        EnterEmail(student.Email);
        SelectGender(student.Gender);
        EnterMobile(student.Mobile);
        EnterDateOfBirth(student.DateOfBirth);
        EnterSubjects(student.Subjects);
        SelectHobbies(student.Hobbies);
        UploadPicture(student.Picture);
        EnterCurrentAddress(student.CurrentAddress);
        SelectState(student.State);
        SelectCity(student.City);
    }

    public void ClickSubmitBtn()
    {
        _submitBtn.ScrollToCenter();
        _submitBtn.ClickOnElement();
    }

    // Verify
    public string GetSubmittedValue(string label)
    {
        return WaitUntilVisible(
            By.XPath($"//td[contains(text(),'{label}')]/following-sibling::td")
        ).Text;
    }

    public string GetSuccessMessage()
    {
        return WaitUntilVisible(
            By.XPath(
                "//div[text()='Thanks for submitting the form']")
        ).Text;
    }

    public Dictionary<string, string> GetSubmittedInformation()
    {
        return new()
        {
            ["Student Name"] = GetSubmittedValue("Student Name"),
            ["Student Email"] = GetSubmittedValue("Student Email"),
            ["Gender"] = GetSubmittedValue("Gender"),
            ["Mobile"] = GetSubmittedValue("Mobile"),
            ["Date of Birth"] = GetSubmittedValue("Date of Birth"),
            ["Subjects"] = GetSubmittedValue("Subjects"),
            ["Hobbies"] = GetSubmittedValue("Hobbies"),
            ["Picture"] = GetSubmittedValue("Picture"),
            ["Address"] = GetSubmittedValue("Address"),
            ["State and City"] = GetSubmittedValue("State and City")
        };
    }
}