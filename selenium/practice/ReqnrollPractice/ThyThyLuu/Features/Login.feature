Feature: Login

  Scenario Outline: Login with valid account successfully
    Given the user visits the TMS website
    When the user enters username "<username>" and password "<password>"
    And the user clicks on Login button
    Then the user is logged into the system successfully

    Examples:
      | username | password |
      | Admin2   | Fxu1tw^E |

  Scenario Outline: Login with invalid account
    Given the user visits the TMS website
    When the user enters username "<username>" and password "<password>"
    And the user clicks on Login button
    Then the error message will be displayed

    Examples:
      | username | password |
      | Admin2   |          |
      |          | qp$#tGu^ |
      |          |          |
      | Admin1   | qp$#tGu3 |
