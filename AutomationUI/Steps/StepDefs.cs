namespace AutomationUI.Steps
{
    using System;
    using System.IO;
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using AutomationUI.Pages;
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Selenium.Axe;
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
        private AxeAccessibilityHelper axeAccessibilityHelper = new AxeAccessibilityHelper();

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
        /// The user confirms the home page has loaded successfully.
        /// </summary>
        [StepDefinition(@"the user confirms the homepage has loaded")]
        public void WhenTheUserConfirmsTheHomepageHasLoaded()
        {
            // Confirms the Home Page has loaded.
            uNiDAYHomePage.ConfirmHomePageLoaded();
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
            var dictionary = TableExtensions.ToDictionary(table);

            // To make the email unique and tests re-usable the timeStamp variable is replaced with the current time.
            if (dictionary["personalEmailAddress"].Contains("{{timeStamp}}"))
            {
                dictionary["personalEmailAddress"] = dictionary["personalEmailAddress"].Replace("{{timeStamp}}", DateTime.UtcNow.TimeOfDay.ToString().Replace(":", string.Empty).Replace(".", string.Empty));
            }

            // If the confirm personal email address is to have the same email as the personal email address then it sets confirm personal email address value to same value as personal email.
            if (dictionary["confirmPersonalEmailAddress"].Contains("{{timeStamp}}"))
            {
                dictionary["confirmPersonalEmailAddress"] = dictionary["personalEmailAddress"];
            }

            uNiDAYJoinNowPage.EnterPersonalEmailAddress(dictionary["personalEmailAddress"]);
            uNiDAYJoinNowPage.EnterConfirmPersonalEmailAddress(dictionary["confirmPersonalEmailAddress"]);
            uNiDAYJoinNowPage.EnterPassword(dictionary["password"]);
            uNiDAYJoinNowPage.EnterConfirmPassword(dictionary["confirmPassword"]);
            uNiDAYJoinNowPage.SelectGenderOption(dictionary["gender"]);
            uNiDAYJoinNowPage.AcceptTerms(dictionary["acceptTerms"]);
            uNiDAYJoinNowPage.ClickJoinNowButton(dictionary["successOrFailure"]);

            // If the join now attempt was successful, as part of the test it logs out the newly created account and redirects back to the home page, so this confirms it is back on the homepage.
            if (dictionary["successOrFailure"].Equals("success"))
            {
                uNiDAYHomePage.ConfirmHomePageLoaded(false);
            }
        }

        /// <summary>
        /// The join now's page accessibility compliance level is checked using Selenium.Axe.
        /// </summary>
        [StepDefinition(@"the join now's page accessibility compliance level is checked")]
        public void ThenTheJoinNowSPageAccessibilityComplianceLevelIsChecked()
        {
            IWebElement pageBody = driver.FindElement(By.TagName("body"));
            axeAccessibilityHelper.SetUpAxe(driver, pageBody);
            axeAccessibilityHelper.SetUpResults(driver);

            // Capture Path of AxeReport to add to ExtentTestRunReport.
            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, solutionDir, "../..", "Reports & Screenshots", "Axe Compliance Reports");
            var path2 = Directory.CreateDirectory(path + "/");
            string axeReportPath = Path.Combine(path2.ToString(), "AxeReport.html");

            // Add's a link to the Extent Report to attach the compliance report.
            ExtentReportHelper.Test.Info($"<a href='{axeReportPath}' target='_blank' rel='noopener noreferrer'>Click here to view the Axe Accessibility Compliance Report Level</a>");
        }
    }
}
