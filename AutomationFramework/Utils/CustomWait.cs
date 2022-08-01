namespace AutomationFramework.Utils
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Custom Wait class that can be called.
    /// </summary>
    public class CustomWait
    {
        /// <summary>
        /// Global Driver updated when Wait() is called.
        /// </summary>
        private static IWebDriver waitDriver;

        /// <summary>
        /// Time to wait depending on location of test run.
        /// </summary>
        private static int timeWaitTill;

        /// <summary>
        /// Set's a wait period and time out.
        /// </summary>
        /// <param name="driver">IWebDriver.</param>
        /// <returns>Wait.</returns>
        public static WebDriverWait Wait(IWebDriver driver)
        {
            timeWaitTill = 60;

            waitDriver = driver;
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeWaitTill));
        }

        /// <summary>
        /// Wait's a period of time for an element to be displayed.
        /// </summary>
        /// <param name="element">IWebElement.</param>
        public static void WaitForElementToExist(IWebElement element)
        {
            Wait(waitDriver).Until((d) => element.Displayed);
            Wait(waitDriver).Until((d) => element.Enabled);
        }
    }
}
