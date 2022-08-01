namespace AutomationUI.Steps
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using AutomationUI.Pages;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Step Definition file for all the UI Steps.
    /// </summary>
    [Binding]
    public class StepDefs
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private UNiDAY_HomePage uNiDAYHomePage = new UNiDAY_HomePage();
        private UNiDAY_LearningAndWellBeingPage uNiDAYLearningAndWellBeingPage = new UNiDAY_LearningAndWellBeingPage();

        /// <summary>
        /// Initializes a new instance of the <see cref="StepDefs"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public StepDefs()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// The user navigates to the desired URL.
        /// </summary>
        /// <param name="url">Hyperlink URL of the webpage to navigate to.</param>
        [StepDefinition(@"the user navigates to the following URL '(.*)'")]
        public void GivenTheUserNavigatesToTheFollowingURL(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Confirms the UNiDays Homepage has loaded and all the navigation links are clickable and display content.
        /// </summary>
        [StepDefinition(@"confirms the homepage has loaded and all navigation tabs are clickable and display content")]
        public void GivenConfirmsTheHomepageHasLoadedAndAllNavigationTabsAreClickableAndDisplayContent()
        {
            uNiDAYHomePage.ConfirmHomePageLoaded();

            uNiDAYHomePage.ClickLearningAndWellbeingTab();
            uNiDAYLearningAndWellBeingPage.ConfirmLearningAndWellbeingPageLoaded();
            uNiDAYLearningAndWellBeingPage.ConfirmLearningAndWellbeingPageElementsLoaded();

            uNiDAYHomePage.ClickLimitedTimeOnlyTab();
            // MAP LIMITED TIME PAGE CHECK LOADED
            uNiDAYHomePage.ClickFoodAndDrinkTab();
            // MAP FOOD/DRINK PAGE CHECK LOADED
            uNiDAYHomePage.ClickFashionTab();
            // MAP FASHION PAGE CHECK LOADED
            uNiDAYHomePage.ClickTechnologyTab();
            // MAP TEHCNOLOGY PAGE CHECK LOADED
            uNiDAYHomePage.ClickBeautyTab();
            // MAP BEAUTY PAGE CHECK LOADED
            uNiDAYHomePage.ClickLifestyleTab();
            // MAP LIFESTYLE PAGE CHECK LOADED
            uNiDAYHomePage.ClickHealthAndFitnessTab();
            // MAP HEALTH/FITNESS PAGE CHECK LOADED
            uNiDAYHomePage.ClickAllTab();
            // MAP ALL PAGE CHECK LOADED

        }
    }
}
