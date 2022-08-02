namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the TechnologyPage.
    /// </summary>
    public class UNiDAY_TechnologyPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_TechnologyPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_TechnologyPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement TechnologyPageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'Technology')][@class='title ']"));

        private IWebElement TechnologyScrollerAds =>
            driver.FindElement(By.XPath("(//div[@class='scroller scroller-hero highlight-ads'])[5]"));

        /// <summary>
        /// Confirms the UNiDAYS Technology's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_TechnologyPage ConfirmTechnologyPageLoaded()
        {
            wait.Until((d) => TechnologyPageHeader.Displayed);
            return new UNiDAY_TechnologyPage();
        }

        /// <summary>
        /// Confirms the content on the Technology page has loaded.
        /// </summary>
        /// <returns>Confirmation content loaded.</returns>
        public UNiDAY_TechnologyPage ConfirmTechnologyElementExists()
        {
            CustomWait.WaitForElementToExist(TechnologyScrollerAds);
            return new UNiDAY_TechnologyPage();
        }
    }
}
