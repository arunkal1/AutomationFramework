namespace AutomationUI.Pages
{
    using System.Collections.Generic;
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the LimitedTimeOnlyPage.
    /// </summary>
    public class UNiDAY_LimitedTimeOnlyPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_LimitedTimeOnlyPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_LimitedTimeOnlyPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement LimitedTimeOnlyPageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'Limited time only!')][@class='title ']"));

        /// <summary>
        /// Confirms the UNiDAYS Limited Time Only Page's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_LimitedTimeOnlyPage ConfirmLimitedTimeOnlyPageLoaded()
        {
            wait.Until((d) => LimitedTimeOnlyPageHeader.Displayed);
            return new UNiDAY_LimitedTimeOnlyPage();
        }

        /// <summary>
        /// Confirms that there are limited time only article tiles shown.
        /// </summary>
        /// <returns>Confirmation page has loaded content.</returns>
        public UNiDAY_LimitedTimeOnlyPage ConfirmLimitedTimeOnlyArticlesExist()
        {
            wait.Until((d) => d.FindElements(By.XPath("//div[@class='tile__group']//article[@class='tile tile-onebytwo'][contains(.,'Limited time only!')]")));
            IList<IWebElement> articleTiles = driver.FindElements(By.XPath("//div[@class='tile__group']//article[@class='tile tile-onebytwo'][contains(.,'Limited time only!')]"));
            Assert.IsTrue(articleTiles.Count != 0, $"It was expected for there to be shown limited time only articles but none were shown.");
            return new UNiDAY_LimitedTimeOnlyPage();
        }
    }
}
