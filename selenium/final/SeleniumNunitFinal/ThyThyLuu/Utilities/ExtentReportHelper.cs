using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;

public class ExtentReportHelper
{
    static AventStack.ExtentReports.ExtentReports extentManager;

    [ThreadStatic]
    public static ExtentTest extentTest;

    // [ThreadStatic]
    // public static ExtentTest node;

    public static void InitializeReport(string reportPath, string hostName, string environment, string browser)
    {
        Console.WriteLine("Report Path: " + reportPath);

        ExtentSparkReporter htmlReporter = new ExtentSparkReporter(reportPath);

        extentManager = new AventStack.ExtentReports.ExtentReports();

        extentManager.AttachReporter(htmlReporter);

        extentManager.AddSystemInfo("Host Name", hostName);
        extentManager.AddSystemInfo("Environment", environment);
        extentManager.AddSystemInfo("Browser", browser);

        Console.WriteLine("Initialize report success");
    }

    public static void Flush()
    {
        Console.WriteLine("before flush");
        extentManager.Flush();
        Console.WriteLine("after flush");
    }

    public static void CreateTest(string name)
    {
        extentTest = extentManager.CreateTest(name);
        Console.WriteLine("Create test");
    }

    public static void CreateTestResult(TestStatus status, string stacktrace, string className, string testName)
    {
        switch (status)
        {
            case TestStatus.Failed:
                extentTest.Fail($"Test Name: {testName}<br>Status: Failed<br>{stacktrace}");
                break;

            case TestStatus.Inconclusive:
                extentTest.Warning($"Test Name: {testName}<br>Status: Inconclusive<br>{stacktrace}");
                break;

            case TestStatus.Skipped:
                extentTest.Skip($"Test Name: {testName}<br>Status: Skipped");
                break;

            default:
                extentTest.Pass($"Test Name: {testName}<br>Status: Passed");
                break;
        }
    }

    public static void LogInfo(string message)
    {
        extentTest?.Info(message);
    }

    public static void LogPass(string message)
    {
        extentTest?.Pass(message);
    }

    public static void LogFail(string message)
    {
        extentTest?.Fail(message);
    }

    public static void LogWarning(string message)
    {
        extentTest?.Warning(message);
    }
}