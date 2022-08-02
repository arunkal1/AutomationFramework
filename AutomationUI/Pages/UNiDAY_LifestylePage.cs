namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the LifestylePage.
    /// </summary>
    public class UNiDAY_LifestylePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_LifestylePage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_LifestylePage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement LifestylePageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'Lifestyle')][@class='title ']"));

        private IWebElement LifestyleScrollerAds =>
            driver.FindElement(By.XPath("(//div[@class='scroller scroller-hero highlight-ads'])[7]"));

        /// <summary>
        /// Confirms the UNiDAYS Lifestyle's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_LifestylePage ConfirmLifestylePageLoaded()
        {
            wait.Until((d) => LifestylePageHeader.Displayed);
            return new UNiDAY_LifestylePage();
        }

        /// <summary>
        /// Confirms the content on the Lifestyle page has loaded.
        /// </summary>
        /// <returns>Confirmation content loaded.</returns>
        public UNiDAY_LifestylePage ConfirmLifestyleElementExists()
        {
            CustomWait.WaitForElementToExist(LifestyleScrollerAds);
            return new UNiDAY_LifestylePage();
        }
    }
}
