Feature: Student Registration

  Scenario Outline: Register a student information successfully
    Given the user is on Student Registration Form page
    When the user input valid data into all fields
      | Field           | Value            |
      | First Name      | <FirstName>      |
      | Last Name       | <LastName>       |
      | Email           | <Email>          |
      | Gender          | <Gender>         |
      | Mobile          | <Mobile>         |
      | Date of Birth   | <DateOfBirth>    |
      | Subjects        | <Subjects>       |
      | Hobbies         | <Hobbies>        |
      | Picture         | <Picture>        |
      | Current Address | <CurrentAddress> |
      | State           | <State>          |
      | City            | <City>           |
    And the user clicks on Submit button
    Then a successfully message "Thanks for submitting the form" is shown
    And all information of student form is shown

    Examples:
      | FirstName | LastName | Email         | Gender | Mobile     | DateOfBirth | Subjects | Hobbies | Picture               | CurrentAddress | State | City  |
      | Thy       | Luu      | thy@gmail.com | Female | 0987654321 | 12 Aug 2000 | Arts     | Sports  | D:\\Backgr\\image.jpg | HCM City       | NCR   | Delhi |
