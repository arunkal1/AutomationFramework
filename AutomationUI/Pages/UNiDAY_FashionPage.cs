namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the FashionPage.
    /// </summary>
    public class UNiDAY_FashionPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_FashionPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_FashionPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement FashionPageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'Fashion')][@class='title ']"));

        private IWebElement FashionScrollerAds =>
            driver.FindElement(By.XPath("(//div[@class='scroller scroller-hero highlight-ads'])[4]"));

        /// <summary>
        /// Confirms the UNiDAYS Fashion's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_FashionPage ConfirmFashionPageLoaded()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(.,'Fashion')][@class='title ']")));
            return new UNiDAY_FashionPage();
        }

        /// <summary>
        /// Confirms the content on the Fashion page has loaded.
        /// </summary>
        /// <returns>Confirmation content loaded.</returns>
        public UNiDAY_FashionPage ConfirmFashionElementExists()
        {
            CustomWait.WaitForElementToExist(FashionScrollerAds);
            return new UNiDAY_FashionPage();
        }
    }
}
