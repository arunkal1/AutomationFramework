namespace AutomationUI.Hooks
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using AutomationFramework;
    using AutomationFramework.Config;
    using AutomationFramework.Utils;
    using AventStack.ExtentReports;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class to set up the browser hooks for before, during and after feature files.
    /// </summary>
    [Binding]
    public class UIHooks
    {
        /// <summary>
        /// Creates an instance of the Driver.
        /// </summary>
        public static IWebDriver Driver;

        /// <summary>
        /// Creates an instance of the current scenario context.
        /// </summary>
        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Adding a stopwatch counter for timing to the tests.
        /// </summary>
        private Stopwatch stopwatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIHooks"/> class.
        /// Constructor to capture scenario context of test running.
        /// </summary>
        /// <param name="scenarioContext">The current scenario information.</param>
        public UIHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Hook created to Initialise the Extent Report before each test run.
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Calls the method to set up the Extent Report from the helper class.
            ExtentReportHelper.SetUpExtentReport();
        }

        /// <summary>
        /// Before each scenario it will create a new instance of the Driver
        /// And return the value to this instance of the Driver.
        /// Initialises the test in the Extent Report.
        /// </summary>
        [BeforeScenario(Order = 0)]
        public void BeforeScenarioRun()
        {
            // Set's up an instance of the ConfigReader and BrowserSetUp page.
            ConfigReader configReader = new ConfigReader();
            BrowserSetUp browserSetUp = new BrowserSetUp();
            configReader.SetTestSettings();
            Driver = browserSetUp.SetUpDriver();

            // Calls the method to set up the test in the Extent Report HTML report.
            ExtentReportHelper.CreateTestExtentReport(this.scenarioContext.ScenarioInfo.Title.ToString());
        }

        /// <summary>
        /// Starts the timer to see how long each step takes.
        /// </summary>
        [BeforeStep]
        public void BeforeStep()
        {
            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
        }

        /// <summary>
        /// Stops and resets the step timer after each step.
        /// This after step will check to see if there are any failures before ending the driver session.
        /// If an error occurs the method will take a screenshot at the current step of the test.
        /// It will also determine whether to log step passed or failed into the Extent Report.
        /// </summary>
        [AfterStep]
        public void AfterStep()
        {
            this.stopwatch.Stop();
            TestContext.WriteLine("-> done: " + this.stopwatch.Elapsed.TotalSeconds + "(S)");

            if (this.scenarioContext.TestError != null)
            {
                // Folder location where to store screenshots.
                var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, solutionDir, "../..", "Reports & Screenshots", "Failures");
                var path2 = Directory.CreateDirectory(path + "/");
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                string fileName = $"{path2.ToString()}{this.scenarioContext.ScenarioInfo.Title.ToString()}.Png";

                screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(fileName);
                TestContext.WriteLine("-> done: STEP FAILED");
                ExtentReportHelper.Test.Log(Status.Info, $"[STEP FAILED] - {this.scenarioContext.StepContext.StepInfo.Text}");

                // Add Screenshot to failed test
                ExtentReportHelper.Test.Info("[SCREENSHOT] - ", MediaEntityBuilder.CreateScreenCaptureFromPath(fileName).Build());

                // Mark Extent Report as a failed test due to TestError not being null.
                ExtentReportHelper.Test.Log(Status.Fail, $"[TEST FAILED] - {this.scenarioContext.TestError.Message}");
            }
            else
            {
                TestContext.WriteLine("-> done: STEP PASSED");
                ExtentReportHelper.Test.Log(Status.Info, $"[STEP PASSED] - {this.scenarioContext.StepContext.StepInfo.Text}");
            }

            this.stopwatch.Reset();
        }

        /// <summary>
        /// Clears down any instances of the driver after each test completion.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();

            // Mark Extent Report Test as Pass if there are no test errors.
            if (this.scenarioContext.TestError == null)
            {
                ExtentReportHelper.Test.Log(Status.Pass, "[TEST PASSED]");
            }
        }

        /// <summary>
        /// Close the Extent Report after completing all tests in the current test run.
        /// </summary>
        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportHelper.TearDownExtentReport();
        }
    }
}
