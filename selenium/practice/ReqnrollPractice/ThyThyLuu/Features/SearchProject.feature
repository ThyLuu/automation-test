Feature: SearchProject

  Scenario Outline: Search project with any criteria successfully
    Given the user logged into the application
    And the user navigate the Search Project page
    When the user applies some search criteria
      | Field       | Value         |
      | ProjectName | <ProjectName> |
      | Location    | <Location>    |
    And the user clicks on Search button
    Then all projects matched with input criteria will be displayed

    Examples:
      | ProjectName                  | Location          |
      | Project Training RK9 Auto24 | Nuernberg Germany |
