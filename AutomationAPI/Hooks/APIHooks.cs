namespace AutomationAPI.Hooks
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using AutomationFramework;
    using AutomationFramework.Utils;
    using AventStack.ExtentReports;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Class to set up the API hooks for before, during and after feature files.
    /// </summary>
    [Binding]
    public class APIHooks
    {
        /// <summary>
        /// Creates an instance of the current scenario context.
        /// </summary>
        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Adding a stopwatch counter for timing to the tests.
        /// </summary>
        private Stopwatch stopwatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="APIHooks"/> class.
        /// Constructor to capture the current scenario context of test running.
        /// </summary>
        /// <param name="scenarioContext">The current scenario information.</param>
        public APIHooks(ScenarioContext scenarioContext)
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
        /// Before each test it will call the configReader method to gather test variables.
        /// Initialises the test in the Extent Report.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenarioRun()
        {
            // Set's up an instance of the ConfigReader page.
            ConfigReader configReader = new ConfigReader();
            configReader.SetTestSettings();

            // Calls the method to set up the test in the Extent Report HTML report.
            ExtentReportHelper.CreateTestExtentReport(scenarioContext.ScenarioInfo.Title.ToString());
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
        /// It will also determine whether to log step passed or failed into the Extent Report.
        /// </summary>
        [AfterStep]
        public void AfterStep()
        {
            this.stopwatch.Stop();
            TestContext.WriteLine("-> done: " + this.stopwatch.Elapsed.TotalSeconds + "(S)");

            if (this.scenarioContext.TestError != null)
            {
                TestContext.WriteLine("-> done: STEP FAILED");
                ExtentReportHelper.Test.Log(Status.Info, $"[STEP FAILED] - {this.scenarioContext.StepContext.StepInfo.Text}");

                // Mark Extent Report as a failed test due to TestError not being null.
                ExtentReportHelper.Test.Log(Status.Fail, $"[TEST FAILED] - {this.scenarioContext.TestError.Message}");
            }
            else
            {
                TestContext.WriteLine("-> done: STEP PASSED");

                // If there is a Gherkin table associated with the step then it add's that Gherkin table to the test output on the Extent Report, else, it just outputs the step info text.
                if (this.scenarioContext.StepContext.StepInfo.Table != null)
                {
                    // Heading for the KEY|VALUE section of the Gherkin table.
                    string gherkinTable = "| Key | Value |" + "<br />";

                    // For each row in the Gherkin table, it will loop over the rows and assign the values to the IList<string>
                    foreach (TableRow row in this.scenarioContext.StepContext.StepInfo.Table.Rows)
                    {
                        IList<string> keyValues = (IList<string>)row.Values;

                        // These values are then added to the string with a new line break after each row.
                        gherkinTable = gherkinTable + "| " + keyValues[0] + " | " + keyValues[1] + " |" + "<br />";
                    }

                    ExtentReportHelper.Test.Log(Status.Info, $"[STEP PASSED] - {this.scenarioContext.StepContext.StepInfo.Text}" + "<br />" + "<br />" + $"[GHERKIN TABLE:]" + "<br />" + gherkinTable);
                }
                else
                {
                    ExtentReportHelper.Test.Log(Status.Info, $"[STEP PASSED] - {this.scenarioContext.StepContext.StepInfo.Text}");
                }
            }

            this.stopwatch.Reset();
        }

        /// <summary>
        /// Marks the test as passed in Extent Report if there are no failures.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            // Mark Extent Report Test as Pass if there are no test errors.
            if (scenarioContext.TestError == null)
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
