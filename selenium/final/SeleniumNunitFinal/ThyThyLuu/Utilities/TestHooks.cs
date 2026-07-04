

namespace FinalSelenium
{
    [SetUpFixture]
    public class TestHooks
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ConfigurationUtils.ReadConfiguration("Configuration\\appsettings.json");

            string projectPath = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\")
            );

            string reportFolder = Path.Combine(projectPath, "Reports");

            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            string reportPath = Path.Combine(
                reportFolder,
                $"index_{timestamp}.html"
            );

            ExtentReportHelper.InitializeReport(
                reportPath,
                Environment.MachineName,
                TestContext.Parameters.Get("Environment", "Local"),
                ConfigurationUtils.GetConfigurationByKey("Browser")
            );
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentReportHelper.Flush();
        }
    }
}