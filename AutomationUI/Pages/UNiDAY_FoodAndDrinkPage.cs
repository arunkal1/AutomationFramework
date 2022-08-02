namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the FoodAndDrinkPage.
    /// </summary>
    public class UNiDAY_FoodAndDrinkPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_FoodAndDrinkPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_FoodAndDrinkPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement FoodAndDrinkPageHeader =>
            driver.FindElement(By.XPath("//h1[contains(.,'Food & Drink')][@class='title ']"));

        private IWebElement FirstFoodAndDrinkItemButton =>
            driver.FindElement(By.XPath("(//div[@class='highlight-scroll heroSlides'])[3]"));

        /// <summary>
        /// Confirms the UNiDAYS Food & Drink Page's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_FoodAndDrinkPage ConfirmFoodAndDrinkPageLoaded()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[contains(.,'Food & Drink')][@class='title ']")));
            return new UNiDAY_FoodAndDrinkPage();
        }

        /// <summary>
        /// Confirms the content on the food and drink page has loaded.
        /// </summary>
        /// <returns>Confirmation content loaded.</returns>
        public UNiDAY_FoodAndDrinkPage ConfirmFoodAndDrinkElementExists()
        {
            CustomWait.WaitForElementToExist(FirstFoodAndDrinkItemButton);
            return new UNiDAY_FoodAndDrinkPage();
        }
    }
}
