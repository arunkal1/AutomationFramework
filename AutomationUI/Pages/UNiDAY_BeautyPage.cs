namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the BeautyPage.
    /// </summary>
    public class UNiDAY_BeautyPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_BeautyPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_BeautyPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement BeautyPageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'Beauty')][@class='title ']"));

        private IWebElement BeautyScrollerAds =>
            driver.FindElement(By.XPath("(//div[@class='scroller scroller-hero highlight-ads'])[6]"));

        /// <summary>
        /// Confirms the UNiDAYS Beauty's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_BeautyPage ConfirmBeautyPageLoaded()
        {
            wait.Until((d) => BeautyPageHeader.Displayed);
            return new UNiDAY_BeautyPage();
        }

        /// <summary>
        /// Confirms the content on the Beauty page has loaded.
        /// </summary>
        /// <returns>Confirmation content loaded.</returns>
        public UNiDAY_BeautyPage ConfirmBeautyElementExists()
        {
            CustomWait.WaitForElementToExist(BeautyScrollerAds);
            return new UNiDAY_BeautyPage();
        }
    }
}
