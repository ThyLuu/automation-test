using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V145.IndexedDB;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

public class PracticeFormPage : BasePage
{
    public PracticeFormPage(IWebDriver driver) : base(driver)
    {
    }

    private WebObject _firstNameInput = new WebObject(By.Id("firstName"), "First name input");
    private WebObject _lastNameInput = new WebObject(By.Id("lastName"), "Last name input");
    private WebObject _emailInput = new WebObject(By.Id("userEmail"), "Email input");
    private WebObject _mobileInput = new WebObject(By.Id("userNumber"), "Mobile phone input");
    private WebObject _genderRadio(string value)
    {
        return new WebObject(
            By.XPath($"//label[text()='{value}']"),
            $"{value} gender radio"
        );
    }
    private WebObject _dateOfBirthInput = new WebObject(By.Id("dateOfBirthInput"), "Date of birth input");
    private WebObject _subjectsInput = new WebObject(By.Id("subjectsInput"), "Subjects input");
    public WebObject _hobbyCheckbox(string value)
    {
        return new WebObject(
            By.XPath($"//label[text()='{value}']"),
            $"{value} hobby checkbox"
        );
    }
    private WebObject _pictureInput = new WebObject(By.Id("uploadPicture"), "Picture input");
    private WebObject _currentAddressInput = new WebObject(By.Id("currentAddress"), "Current address input");
    private WebObject _stateDropdown = new(By.Id("react-select-3-input"), "State dropdown");
    private WebObject _cityDropdown = new(By.Id("react-select-4-input"), "City dropdown");
    private WebObject _submitBtn = new WebObject(By.Id("submit"), "Submit button");

    public void EnterFirstName(string firstName)
    {
        _firstNameInput.EnterText(firstName);

        ExtentReportHelper.LogInfo($"Enter first name: {firstName}");
    }
    public void EnterLastName(string lastName)
    {
        _lastNameInput.EnterText(lastName);

        ExtentReportHelper.LogInfo($"Enter last name: {lastName}");
    }
    public void EnterEmail(string email)
    {
        _emailInput.EnterText(email);

        ExtentReportHelper.LogInfo($"Enter email: {email}");
    }
    public void SelectGender(string gender)
    {
        _genderRadio(gender).ClickOnElement();

        ExtentReportHelper.LogInfo($"Enter gender: {gender}");
    }
    public void EnterMobile(string mobile)
    {
        _mobileInput.EnterText(mobile);

        ExtentReportHelper.LogInfo($"Enter mobile: {mobile}");
    }
    public void EnterDateOfBirth(string dateOfBirth)
    {
        _dateOfBirthInput.SelectDate(dateOfBirth);
        _dateOfBirthInput.ScrollToCenter();

        ExtentReportHelper.LogInfo($"Enter date of birth: {dateOfBirth}");
    }
    public void EnterSubjects(string subject)
    {
        _subjectsInput.EnterText(subject);
        _subjectsInput.EnterText(Keys.Enter);

        ExtentReportHelper.LogInfo($"Select subject: {subject}");
    }
    public void SelectHobbies(string hobby)
    {
        _hobbyCheckbox(hobby).ClickOnElement();

        ExtentReportHelper.LogInfo($"Select hobby: {hobby}");
    }
    public void UploadPicture(string picture)
    {
        var fullPath = FileResolver.Resolve(picture);

        _pictureInput.EnterText(fullPath);

        _pictureInput.ScrollToCenter();

        ExtentReportHelper.LogInfo($"Upload picture: {picture}");
    }
    public void EnterCurrentAddress(string currentAddress)
    {
        _currentAddressInput.EnterText(currentAddress);

        ExtentReportHelper.LogInfo($"Enter current address: {currentAddress}");
    }
    public void SelectState(string state)
    {
        _stateDropdown.EnterText(state + Keys.Enter);

        ExtentReportHelper.LogInfo($"Select state: {state}");
    }
    public void SelectCity(string city)
    {
        _cityDropdown.EnterText(city + Keys.Enter);

        ExtentReportHelper.LogInfo($"Select city: {city}");
    }
    public void ClickSubmitBtn()
    {
        _submitBtn.ScrollToCenter();
        _submitBtn.ClickOnElement();

        ExtentReportHelper.LogInfo("Click submit button");
    }

    // Verify
    public string GetSubmittedValue(string label)
    {

        return WaitUntilVisible(
            By.XPath($"//td[text()='{label}']/following-sibling::td")
        ).Text;
    }

    public string GetSuccessMessage()
    {
        return WaitUntilVisible(
            By.XPath(
                "//div[text()='Thanks for submitting the form']")
        ).Text;
    }
}