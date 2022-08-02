namespace AutomationUI.Pages
{
    using System.Collections.Generic;
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the HealthAndFitnessPage.
    /// </summary>
    public class UNiDAY_HealthAndFitnessPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_HealthAndFitnessPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_HealthAndFitnessPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement HealthAndFitnessPageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'Health & Fitness')][@class='title ']"));

        /// <summary>
        /// Confirms the UNiDAYS Health And Fitness Page's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_HealthAndFitnessPage ConfirmHealthAndFitnessPageLoaded()
        {
            wait.Until((d) => HealthAndFitnessPageHeader.Displayed);
            return new UNiDAY_HealthAndFitnessPage();
        }

        /// <summary>
        /// Confirms that there are Health And Fitness article tiles shown.
        /// </summary>
        /// <returns>Confirmation page has loaded content.</returns>
        public UNiDAY_HealthAndFitnessPage ConfirmHealthAndFitnessArticlesExist()
        {
            wait.Until((d) => d.FindElements(By.XPath("//div[@class='tile__scroll']//article[@class='tile tile-onebytwo'][contains(.,'% Off')]")));
            IList<IWebElement> articleTiles = driver.FindElements(By.XPath("//div[@class='tile__scroll']//article[@class='tile tile-onebytwo'][contains(.,'% Off')]"));
            Assert.IsTrue(articleTiles.Count != 0, $"It was expected for there to be shown health and fitness articles but none were shown.");
            return new UNiDAY_HealthAndFitnessPage();
        }
    }
}
