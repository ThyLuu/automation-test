Feature: Book Search

  Scenario Outline: Search book with multiple results
    Given there are books available in the system
    And the user is on the Book Store page
    When the user searches for book "<Keyword>"
    Then all books returned should match the keyword "<Keyword>"

    Examples:
      | Keyword |
      | Design  |
      | design  |