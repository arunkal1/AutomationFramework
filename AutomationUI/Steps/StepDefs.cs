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
        private UNiDAY_LimitedTimeOnlyPage uNiDAYLimitedTimeOnlyPage = new UNiDAY_LimitedTimeOnlyPage();
        private UNiDAY_FoodAndDrinkPage uNiDAYFoodAndDrinkPage = new UNiDAY_FoodAndDrinkPage();
        private UNiDAY_FashionPage uNiDAYFashionPage = new UNiDAY_FashionPage();
        private UNiDAY_TechnologyPage uNiDAYTechnologyPage = new UNiDAY_TechnologyPage();
        private UNiDAY_BeautyPage uNiDAYBeautyPage = new UNiDAY_BeautyPage();
        private UNiDAY_LifestylePage uNiDAYLifestylePage = new UNiDAY_LifestylePage();
        private UNiDAY_HealthAndFitnessPage uNiDAYHealthAndFitnessPage = new UNiDAY_HealthAndFitnessPage();
        private UNiDAY_AllPage uNiDAYAllPage = new UNiDAY_AllPage();
        private UNiDAY_JoinNowPage uNiDAYJoinNowPage = new UNiDAY_JoinNowPage();

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
            // Confirms the Home Page has loaded.
            uNiDAYHomePage.ConfirmHomePageLoaded();

            // Clicks on the first navigation menu item 'Learning And Wellbeing' and confirms it's elements exist.
            uNiDAYHomePage.ClickLearningAndWellbeingTab();
            uNiDAYLearningAndWellBeingPage.ConfirmLearningAndWellbeingPageLoaded();
            uNiDAYLearningAndWellBeingPage.ConfirmLearningAndWellbeingPageElementsLoaded();

            // Clicks on the second navigation menu item 'Limited Time Only' and confirms it's elements exist.
            uNiDAYHomePage.ClickLimitedTimeOnlyTab();
            uNiDAYLimitedTimeOnlyPage.ConfirmLimitedTimeOnlyPageLoaded();
            uNiDAYLimitedTimeOnlyPage.ConfirmLimitedTimeOnlyArticlesExist();

            // Clicks on the third navigation menu item 'Food & Drink' and confirms it's elements exist.
            uNiDAYHomePage.ClickFoodAndDrinkTab();
            uNiDAYFoodAndDrinkPage.ConfirmFoodAndDrinkPageLoaded();
            uNiDAYFoodAndDrinkPage.ConfirmFoodAndDrinkElementExists();

            // Clicks on the fourth navigation menu item 'Fashion' and confirms it's elements exist.
            uNiDAYHomePage.ClickFashionTab();
            uNiDAYFashionPage.ConfirmFashionPageLoaded();
            uNiDAYFashionPage.ConfirmFashionElementExists();

            // Clicks on the fifth navigation menu item 'Technology' and confirms it's elements exist.
            uNiDAYHomePage.ClickTechnologyTab();
            uNiDAYTechnologyPage.ConfirmTechnologyPageLoaded();
            uNiDAYTechnologyPage.ConfirmTechnologyElementExists();

            // Clicks on the sixth navigation menu item 'Beauty' and confirms it's elements exist.
            uNiDAYHomePage.ClickBeautyTab();
            uNiDAYBeautyPage.ConfirmBeautyPageLoaded();
            uNiDAYBeautyPage.ConfirmBeautyElementExists();

            // Clicks on the seventh navigation menu item 'Lifestyle' and confirms it's elements exist.
            uNiDAYHomePage.ClickLifestyleTab();
            uNiDAYLifestylePage.ConfirmLifestylePageLoaded();
            uNiDAYLifestylePage.ConfirmLifestyleElementExists();

            // Clicks on the eigth navigation menu item 'Health & Fitness' and confirms it's elements exist.
            uNiDAYHomePage.ClickHealthAndFitnessTab();
            uNiDAYHealthAndFitnessPage.ConfirmHealthAndFitnessPageLoaded();
            uNiDAYHealthAndFitnessPage.ConfirmHealthAndFitnessArticlesExist();

            // Clicks on the ninth navigation menu item 'All' and confirms it's elements exist.
            uNiDAYHomePage.ClickAllTab();
            uNiDAYAllPage.ConfirmAllPageLoaded();
            uNiDAYAllPage.ConfirmAllElementExists();
        }

        /// <summary>
        /// The user clicks on the join now tab.
        /// </summary>
        [StepDefinition(@"the user clicks on the join now tab")]
        public void WhenTheUserClicksOnTheJoinNowTab()
        {
            uNiDAYHomePage.ClickDropdownMenuButton();
            uNiDAYHomePage.ClickJoinNowButton();
            uNiDAYJoinNowPage.ConfirmJoinNowPageLoaded();
        }

        /// <summary>
        /// Enters the registration information into the Join Now form, testing different validation input fields.
        /// </summary>
        /// <param name="table">Gherkin feature file table.</param>
        [StepDefinition(@"the user enters the registration information into the join now form")]
        public void ThenTheUserEntersTheRegistrationInformationIntoTheJoinNowForm(Table table)
        {
            
        }
    }
}
