namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the AllPage.
    /// </summary>
    public class UNiDAY_AllPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_AllPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_AllPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement AllPageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'All')][@class='title ']"));

        private IWebElement AllScrollerAds =>
            driver.FindElement(By.XPath("(//div[@class='scroller scroller-hero highlight-ads'])[9]"));

        /// <summary>
        /// Confirms the UNiDAYS All's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_AllPage ConfirmAllPageLoaded()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(.,'All')][@class='title ']")));
            return new UNiDAY_AllPage();
        }

        /// <summary>
        /// Confirms the content on the All page has loaded.
        /// </summary>
        /// <returns>Confirmation content loaded.</returns>
        public UNiDAY_AllPage ConfirmAllElementExists()
        {
            CustomWait.WaitForElementToExist(AllScrollerAds);
            return new UNiDAY_AllPage();
        }
    }
}
