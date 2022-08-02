namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the LearningAndWellBeingPage.
    /// </summary>
    public class UNiDAY_LearningAndWellBeingPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_LearningAndWellBeingPage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_LearningAndWellBeingPage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement LearningAndWellbeingPageHeader =>
            driver.FindElement(By.XPath("//span[contains(.,'Learning and career-building tools')]"));

        private IWebElement AllButton =>
            driver.FindElement(By.Id("all"));

        private IWebElement StudyButton =>
            driver.FindElement(By.Id("study"));

        private IWebElement WellbeingButton =>
            driver.FindElement(By.Id("wellbeing"));

        private IWebElement PersonalDevelopmentButton =>
            driver.FindElement(By.Id("personal-development"));

        /// <summary>
        /// Confirms the UNiDAYS Learning And Wellbeing Page's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_LearningAndWellBeingPage ConfirmLearningAndWellbeingPageLoaded()
        {
            // Sometimes if the mouse is hovering over the 'Learning & Wellbeing' tab then the popover exists over the screen, this moves the focus away from that.
            Actions action = new Actions(driver);
            action.MoveByOffset(10, 20).Perform();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(.,'Learning and career-building tools')]")));
            return new UNiDAY_LearningAndWellBeingPage();
        }

        /// <summary>
        /// Waits for the elements on the UNiDAYS Learning And Wellbeing Page to exists.
        /// </summary>
        /// <returns>An exception if elements are not found.</returns>
        public UNiDAY_LearningAndWellBeingPage ConfirmLearningAndWellbeingPageElementsLoaded()
        {
            CustomWait.WaitForElementToExist(AllButton);
            CustomWait.WaitForElementToExist(StudyButton);
            CustomWait.WaitForElementToExist(WellbeingButton);
            CustomWait.WaitForElementToExist(PersonalDevelopmentButton);
            return new UNiDAY_LearningAndWellBeingPage();
        }
    }
}
