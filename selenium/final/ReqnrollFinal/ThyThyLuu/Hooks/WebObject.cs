using OpenQA.Selenium;

// public class WebObject
// {
//     public By By {get; set;}
//     public string Name {get; set;}

//     public WebObject(By by, string name = "")
//     {
//         By = by;
//         Name = name;
//     }
// }

public class WebObject
{
    public IWebDriver Driver { get; }
    public By By { get; }
    public string Name { get; }

    public WebObject(IWebDriver driver, By by, string name)
    {
        Driver = driver;
        By = by;
        Name = name;
    }
}