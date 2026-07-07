Feature: CreateProject

  Scenario Outline: Create Project with all fields successfully
    Given the user logged into the application
    And the user navigates to Create Project page
    When the user fills in all project information
      | Field             | Value               |
      | ProjectName       | <ProjectName>       |
      | ProjectType       | <ProjectType>       |
      | ProjectStatus     | <ProjectStatus>     |
      | StartDate         | <StartDate>         |
      | EndDate           | <EndDate>           |
      | Size              | <Size>              |
      | Location          | <Location>          |
      | ProjectManager    | <ProjectManager>    |
      | DeliveryManager   | <DeliveryManager>   |
      | EngagementManager | <EngagementManager> |
      | ShortDescription  | <ShortDescription>  |
      | LongDescription   | <LongDescription>   |
      | Technologies      | <Technologies>      |
      | ClientName        | <ClientName>        |
      | ClientIndustry    | <ClientIndustry>    |
      | ClientDescription | <ClientDescription> |
    And the user clicks Create button
    Then all information of the project is shown

    Examples:
      | ProjectName    | ProjectType | ProjectStatus | StartDate   | EndDate     | Size | Location                          | ProjectManager | DeliveryManager    | EngagementManager | ShortDescription         | LongDescription         | Technologies | ClientName  | ClientIndustry | ClientDescription |
      | RK9 Reqnroll 7 | ODC         | Running       | 08-May-2026 | 08-May-2027 | 1000 | Offshore Vietnam Ho Chi Minh city | Master Yi (Yi) | Vo Dang Khoa (Car) | ngoc Ly (27)      | short description 123456 | long description 123456 | C#, Selenium | Thy Thy Luu | Technology     | this is client    |
