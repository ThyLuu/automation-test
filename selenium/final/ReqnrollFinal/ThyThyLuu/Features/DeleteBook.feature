Feature: Delete Book

  Scenario Outline: Delete book successfully
    Given there is a book named "<BookName>" with isbn "<Isbn>" for user "<UserId>" using "<Username>" and "<Password>"
    And the user logs into the application with "<Username>" and "<Password>"
    And the user is on the Profile page
    When the user search book "<BookName>"
    And the user clicks on Delete icon
    And the user clicks on OK button
    And the user clicks on OK button of alert "Book deleted."
    Then the book is not shown

    Examples:
      | BookName         | Isbn          | UserId                               | Username  | Password    |
      | Git Pocket Guide | 9781449325862 | d83c51c8-3196-4e8b-a300-c85d3ba1ecec | thyluu623 | @Thyluu623! |
