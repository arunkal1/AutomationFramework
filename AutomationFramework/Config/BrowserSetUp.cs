namespace AutomationFramework.Config
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;

    /// <summary>
    /// Class to assertain which browser is chosen and set it up with specified settings.
    /// </summary>
    public class BrowserSetUp
    {
        /// <summary>
        /// Declare a new instance of the Driver.
        /// </summary>
        public IWebDriver Driver;

        /// <summary>
        /// Set's up the driver's value to that of the instance set up in CreateWebDriver().
        /// </summary>
        /// <returns>Instance of IWebDriver.</returns>
        public IWebDriver SetUpDriver()
        {
            this.Driver = this.CreateWebDriver();
            return this.Driver;
        }

        /// <summary>
        /// Determines which browser is chosen.
        /// Add's settings to the chosen browser.
        /// "." - The Nuget package will place the driver.exe in {buildConfiguration} - tells it to look in the root.
        /// </summary>
        /// <returns>Returns an instance of the web driver.</returns>
        public IWebDriver CreateWebDriver()
        {
            // Path to download folder for autodownloaded content.
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, solutionDir, "../..", "GeneratedFiles");
            string filePath = path.Replace("\\AutomationUI\\bin\\../..", string.Empty);

            switch (ConfigVariables.BROWSER)
            {
                case "CHROME":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("start-maximized");
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddArgument("--browser-test");

                    // Run's the test in headless mode for less GPU Usage to use on CI Pipelines.
                    if (ConfigVariables.TESTLOCATION == "PIPELINE")
                    {
                        chromeOptions.AddArguments("headless");
                        chromeOptions.AddArguments("--window-size=1920x1080");
                    }

                    chromeOptions.AddUserProfilePreference("download.default_directory", filePath);
                    chromeOptions.AddUserProfilePreference("intl.accept_languages", "en");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                    this.Driver = new ChromeDriver(".", chromeOptions, TimeSpan.FromMinutes(3));
                    break;
                case "IE":
                    this.Driver = new InternetExplorerDriver();
                    this.Driver.Manage().Window.Maximize();
                    break;
                case "EDGE":
                    // Driver MicrosoftWebDriver.exe placed in bin\Debug\netcoreapp3.1 folder.
                    this.Driver = new EdgeDriver(Directory.GetCurrentDirectory());
                    this.Driver.Manage().Window.Maximize();
                    break;
                case "FIREFOX":
                    this.Driver = new FirefoxDriver();
                    this.Driver.Manage().Window.Maximize();
                    break;
                default:
                    throw new Exception("Browser Type selected is not valid");
            }

            return this.Driver;
        }
    }
}
