namespace AutomationFramework.Utils
{
    using System;
    using System.IO;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using Selenium.Axe;

    /// <summary>
    /// Custom helper class to analyse web pages/elements and report results.
    /// </summary>
    public class AxeAccessibilityHelper
    {
        /// <summary>
        /// AxeResult variable to store analysed element.
        /// </summary>
        private AxeResult axeResult;

        /// <summary>
        /// Set's up the AxeResult using the specified IWebDriver and IWebElement.
        /// </summary>
        /// <param name="driver">Current context of IWebDriver.</param>
        /// <param name="element">IWebElement to analyse.</param>
        public void SetUpAxe(IWebDriver driver, IWebElement element)
        {
            axeResult = new AxeBuilder(driver)
                .Analyze(element);
        }

        /// <summary>
        /// The analysed results are outputted to a HTML Report.
        /// </summary>
        /// <param name="driver">Current context of IWebDriver.</param>
        public void SetUpResults(IWebDriver driver)
        {
            // Location for the Report Folder.
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, solutionDir, "../..", "Reports & Screenshots", "Axe Compliance Reports");
            var path2 = Directory.CreateDirectory(path + "/");
            string axeReportPath = Path.Combine(path2.ToString(), "AxeReport.html");
            driver.CreateAxeHtmlReport(axeResult, axeReportPath);
        }
    }
}
