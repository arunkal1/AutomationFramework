namespace AutomationFramework.Utils
{
    using System;
    using System.IO;
    using System.Reflection;
    using AutomationFramework.Config;
    using AventStack.ExtentReports;
    using AventStack.ExtentReports.Reporter;
    using NUnit.Framework;

    /// <summary>
    /// Custom helper class to set up the Extent Report.
    /// </summary>
    public class ExtentReportHelper
    {
        /// <summary>
        /// Create instance of Extent Report.
        /// </summary>
        public static ExtentReports Extent = null;

        /// <summary>
        /// Create instance of Test in Extent Report.
        /// </summary>
        public static ExtentTest Test = null;

        /// <summary>
        /// Name of the Extent Report.
        /// </summary>
        private static string fileName;

        /// <summary>
        /// Method to set up the report.
        /// </summary>
        public static void SetUpExtentReport()
        {
            // Creates the object for the report
            Extent = new ExtentReports();

            // Location for the Report Folder.
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, solutionDir, "../..", "Reports & Screenshots", "Extent Reports");
            var path2 = Directory.CreateDirectory(path + "/");
            fileName = path2.ToString();

            // Folder path where the HTML Report is to be saved.
            var htmlReporter = new ExtentHtmlReporter(path2.ToString());
            Extent.AttachReporter(htmlReporter); // Attaches the report.
        }

        /// <summary>
        /// Method to create the test within the HTML file.
        /// </summary>
        /// <param name="testName">Name of the test which is running.</param>
        public static void CreateTestExtentReport(string testName)
        {
            // Create the test in the report.
            Test = Extent.CreateTest(testName).Info("[TEST STARTED]");
        }

        /// <summary>
        /// Ends the extent report.
        /// </summary>
        public static void TearDownExtentReport()
        {
            // Adds some custom system information to the report.
            Extent.AddSystemInfo("Reporter: ", Environment.UserName);
            switch (Assembly.GetCallingAssembly().GetName().Name.ToString())
            {
                case "AKalwanAutomationAPI":
                    Extent.AddSystemInfo("Project:", "Automation.API");
                    break;
                case "AKalwanAutomationUI":
                    Extent.AddSystemInfo("Project:", "Automation.UI");
                    Extent.AddSystemInfo("Browser:", ConfigVariables.BROWSER);
                    break;
            }

            Extent.Flush();

            // If Report already exists then delete the older version and Rename ExtentReport from index.html to project path name.
            if (File.Exists(fileName + $"{Assembly.GetCallingAssembly().GetName().Name}-TestRunReport.html"))
            {
                File.Delete(fileName + $"{Assembly.GetCallingAssembly().GetName().Name}-TestRunReport.html");
            }

            File.Move(fileName + "index.html", fileName + $"{Assembly.GetCallingAssembly().GetName().Name}-TestRunReport.html");
        }
    }
}
