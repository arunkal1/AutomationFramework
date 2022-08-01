namespace AutomationUI.Steps
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Step Definition file for all the UI Steps.
    /// </summary>
    [Binding]
    public class StepDefs
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="StepDefs"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public StepDefs()
        {
            this.driver = UIHooks.Driver;
            this.wait = CustomWait.Wait(this.driver);
        }

        /// <summary>
        /// The user navigates to the desired URL.
        /// </summary>
        /// <param name="url">Hyperlink URL of the webpage to navigate to.</param>
        [StepDefinition(@"the user navigates to the following URL '(.*)'")]
        public void GivenTheUserNavigatesToTheFollowingURL(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }
    }
}
