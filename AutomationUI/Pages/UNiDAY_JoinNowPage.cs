namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the Join Now Page.
    /// </summary>
    public class UNiDAY_JoinNowPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_JoinNowPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_JoinNowPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement JoinNowPageHeader =>
            driver.FindElement(By.XPath("//div[@id='register_main']//h1[contains(.,'Join UNiDAYS now')][@class='title ']"));

        /// <summary>
        /// Confirms the UNiDAY's Join Now page has loaded.
        /// </summary>
        /// <returns>Confirmation of header load.</returns>
        public UNiDAY_JoinNowPage ConfirmJoinNowPageLoaded()
        {
            wait.Until((d) => JoinNowPageHeader.Displayed);

            // Sometimes if the mouse is hovering over the 'Learning & Wellbeing' tab then the popover exists over the screen, this moves the focus away from that.
            Actions action = new Actions(driver);
            action.MoveByOffset(10, 20).Perform();

            return new UNiDAY_JoinNowPage();
        }
    }
}
