﻿namespace AutomationUI.Pages
{
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Map elements from the Home Page.
    /// </summary>
    public class UNiDAY_HomePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        /// <summary>
        /// Initializes a new instance of the <see cref="UNiDAY_HomePage"/> class.
        /// Constructor initialises the driver for the page.
        /// </summary>
        public UNiDAY_HomePage()
        {
            driver = UIHooks.Driver;
            wait = CustomWait.Wait(driver);
        }

        /// <summary>
        /// Gets Elements on the page.
        /// </summary>
        private IWebElement HomePageHeader =>
            driver.FindElement(By.XPath("//a[contains(.,'Home')][@class='title logo']"));

        private IWebElement LearningAndWellbeingTab =>
            driver.FindElement(By.XPath("//a[contains(.,'Learning & Wellbeing')]"));

        private IWebElement LimtedTimeOnlyTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'Limited time only!')])[2]"));

        private IWebElement FoodAndDrinkTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'Food & Drink')])[3]"));

        private IWebElement FashionTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'Fashion')])[3]"));

        private IWebElement TechnologyTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'Technology')])[3]"));

        private IWebElement BeautyTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'Beauty')])[3]"));

        private IWebElement LifestyleTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'Lifestyle')])[3]"));

        private IWebElement HealthAndFitnessTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'Health & Fitness')])[3]"));

        private IWebElement AllTab =>
            driver.FindElement(By.XPath("(//a[contains(.,'All')])[3]"));

        /// <summary>
        /// Confirms the UNiDAYS Home Page's header has loaded.
        /// </summary>
        /// <returns>Confirmation is on the page.</returns>
        public UNiDAY_HomePage ConfirmHomePageLoaded()
        {
            CustomWait.WaitForElementToExist(HomePageHeader);
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Learning and Wellbeing' tab.
        /// </summary>
        /// <returns>'Learning and Wellbeing' tab clicked.</returns>
        public UNiDAY_HomePage ClickLearningAndWellbeingTab()
        {
            CustomWait.WaitForElementToExist(LearningAndWellbeingTab);
            LearningAndWellbeingTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Limited Time Only' tab.
        /// </summary>
        /// <returns>'Limited Time Only' tab clicked.</returns>
        public UNiDAY_HomePage ClickLimitedTimeOnlyTab()
        {
            CustomWait.WaitForElementToExist(LimtedTimeOnlyTab);
            LimtedTimeOnlyTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Food and Drink' tab.
        /// </summary>
        /// <returns>'Food and Drink' tab clicked.</returns>
        public UNiDAY_HomePage ClickFoodAndDrinkTab()
        {
            CustomWait.WaitForElementToExist(FoodAndDrinkTab);
            FoodAndDrinkTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Fashion' tab.
        /// </summary>
        /// <returns>'Fashion' tab clicked.</returns>
        public UNiDAY_HomePage ClickFashionTab()
        {
            CustomWait.WaitForElementToExist(FashionTab);
            FashionTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Technology' tab.
        /// </summary>
        /// <returns>'Technology' tab clicked.</returns>
        public UNiDAY_HomePage ClickTechnologyTab()
        {
            CustomWait.WaitForElementToExist(TechnologyTab);
            TechnologyTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Beauty' tab.
        /// </summary>
        /// <returns>'Beauty' tab clicked.</returns>
        public UNiDAY_HomePage ClickBeautyTab()
        {
            CustomWait.WaitForElementToExist(BeautyTab);
            BeautyTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Lifestyle' tab.
        /// </summary>
        /// <returns>'Lifestyle' tab clicked.</returns>
        public UNiDAY_HomePage ClickLifestyleTab()
        {
            CustomWait.WaitForElementToExist(LifestyleTab);
            LifestyleTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'Health and Fitness' tab.
        /// </summary>
        /// <returns>'Health and Fitness' tab clicked.</returns>
        public UNiDAY_HomePage ClickHealthAndFitnessTab()
        {
            CustomWait.WaitForElementToExist(HealthAndFitnessTab);
            HealthAndFitnessTab.Click();
            return new UNiDAY_HomePage();
        }

        /// <summary>
        /// Clicks on the 'All' tab.
        /// </summary>
        /// <returns>'All' tab clicked.</returns>
        public UNiDAY_HomePage ClickAllTab()
        {
            CustomWait.WaitForElementToExist(AllTab);
            AllTab.Click();
            return new UNiDAY_HomePage();
        }
    }
}
