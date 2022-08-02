namespace AutomationUI.Pages
{
    using System;
    using AutomationFramework.Utils;
    using AutomationUI.Hooks;
    using NUnit.Framework;
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

        private IWebElement PersonalEmailInput =>
            driver.FindElement(By.Id("AP_Register_txtEmailAddress"));

        private IWebElement ConfirmPersonalEmailInput =>
            driver.FindElement(By.Id("AP_Register_txtConfirmEmailAddress"));

        private IWebElement PasswordInput =>
            driver.FindElement(By.Id("AP_Register_txtPassword"));

        private IWebElement ConfirmPasswordInput =>
            driver.FindElement(By.Id("AP_Register_txtConfirmPassword"));

        private IWebElement MaleRadioButton =>
            driver.FindElement(By.Id("rbMale"));

        private IWebElement FemaleRadioButton =>
            driver.FindElement(By.Id("rbFemale"));

        private IWebElement PreferNotToSayRadioButton =>
            driver.FindElement(By.Id("rbUnisex"));

        private IWebElement AgreeToTermsTickBox =>
            driver.FindElement(By.Id("AP_Register_chkAgreeToTerms"));

        private IWebElement JoinNowButton =>
            driver.FindElement(By.XPath("//form//button[contains(.,'Join now')]"));

        private IWebElement TopLeftMenuButton =>
            driver.FindElement(By.XPath("//div[@class='menu-btn-icon']"));

        private IWebElement LogOutButton =>
            driver.FindElement(By.XPath("//ul[@class='secondary']//a[contains(.,'Log out')]"));

        /// <summary>
        /// Confirms the UNiDAY's Join Now page has loaded.
        /// </summary>
        /// <returns>Confirmation of header load.</returns>
        public UNiDAY_JoinNowPage ConfirmJoinNowPageLoaded()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='register_main']//h1[contains(.,'Join UNiDAYS now')][@class='title ']")));

            // Sometimes if the mouse is hovering over the 'Learning & Wellbeing' tab then the popover exists over the screen, this moves the focus away from that.
            Actions action = new Actions(driver);
            action.MoveByOffset(10, 20).Perform();

            return new UNiDAY_JoinNowPage();
        }

        /// <summary>
        /// Enters the personal email address value into the input.
        /// </summary>
        /// <param name="personalEmailAddressValue">Value to enter into input, default is empty.</param>
        /// <returns>If value is not empty, value is entered into input.</returns>
        public UNiDAY_JoinNowPage EnterPersonalEmailAddress(string personalEmailAddressValue = "")
        {
            if (personalEmailAddressValue != string.Empty)
            {
                PersonalEmailInput.SendKeys(personalEmailAddressValue);
            }

            return new UNiDAY_JoinNowPage();
        }

        /// <summary>
        /// Enters the confirm personal email address value into the input.
        /// </summary>
        /// <param name="confirmPersonalEmailAddressValue">Value to enter into input, default is empty.</param>
        /// <returns>If value is not empty, value is entered into input.</returns>
        public UNiDAY_JoinNowPage EnterConfirmPersonalEmailAddress(string confirmPersonalEmailAddressValue = "")
        {
            if (confirmPersonalEmailAddressValue != string.Empty)
            {
                ConfirmPersonalEmailInput.SendKeys(confirmPersonalEmailAddressValue);
            }

            return new UNiDAY_JoinNowPage();
        }

        /// <summary>
        /// Enters the password value into the input.
        /// </summary>
        /// <param name="passwordValue">Value to enter into input, default is empty.</param>
        /// <returns>If value is not empty, value is entered into input.</returns>
        public UNiDAY_JoinNowPage EnterPassword(string passwordValue = "")
        {
            if (passwordValue != string.Empty)
            {
                PasswordInput.SendKeys(passwordValue);
            }

            return new UNiDAY_JoinNowPage();
        }

        /// <summary>
        /// Enters the confirm password value into the input.
        /// </summary>
        /// <param name="confirmPasswordValue">Value to enter into input, default is empty.</param>
        /// <returns>If value is not empty, value is entered into input.</returns>
        public UNiDAY_JoinNowPage EnterConfirmPassword(string confirmPasswordValue = "")
        {
            if (confirmPasswordValue != string.Empty)
            {
                ConfirmPasswordInput.SendKeys(confirmPasswordValue);
            }

            return new UNiDAY_JoinNowPage();
        }

        /// <summary>
        /// Enters the gender value into the input.
        /// </summary>
        /// <param name="genderValue">Value to enter into input, default is empty.</param>
        /// <returns>If value is not empty, value is selected from radio button options.</returns>
        public UNiDAY_JoinNowPage SelectGenderOption(string genderValue = "")
        {
            // Define JavaScript due to some cases where other elements would receieve the click so click them with JS instead.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (genderValue != string.Empty)
            {
                if (genderValue.Equals("Male"))
                {
                    js.ExecuteScript("arguments[0].click();", MaleRadioButton);
                }
                else if (genderValue.Equals("Female"))
                {
                    js.ExecuteScript("arguments[0].click();", FemaleRadioButton);
                }
                else if (genderValue.Equals("Prefer not to say"))
                {
                    js.ExecuteScript("arguments[0].click();", PreferNotToSayRadioButton);
                }
                else
                {
                    throw new Exception($"The value selected '{genderValue}', is not a selected option from the choice of radio buttons; Male, Female or Prefer not to say");
                }
            }

            return new UNiDAY_JoinNowPage();
        }

        /// <summary>
        /// Selects if the accept the terms on the Join Now form..
        /// </summary>
        /// <param name="acceptTerms">Value to accept terms and tick checkbox, default is empty.</param>
        /// <returns>If value is not empty, checkboc is ticked..</returns>
        public UNiDAY_JoinNowPage AcceptTerms(string acceptTerms = "")
        {
            // Define JavaScript due to some cases where other elements would receieve the click so click them with JS instead.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            if (acceptTerms != string.Empty)
            {
                js.ExecuteScript("arguments[0].click();", AgreeToTermsTickBox);
            }

            return new UNiDAY_JoinNowPage();
        }

        /// <summary>
        /// Clicks the join now button after entering values into form.
        /// </summary>
        /// <param name="successOrFailure">Determines if the form submission is a success or failure.</param>
        /// <returns>Confirmation if form submitted sucessfully or failed.</returns>
        public UNiDAY_JoinNowPage ClickJoinNowButton(string successOrFailure = "")
        {
            // Move page down to agree terms check box location if required.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AgreeToTermsTickBox);

            CustomWait.WaitForElementToExist(JoinNowButton);
            js.ExecuteScript("arguments[0].click();", JoinNowButton);

            // If the Join Now form submission was a success it verifies it has logged in and logs out of the account.
            if (successOrFailure.Equals("success"))
            {
                // Wait's for the Count me in button to show. And the heading for verifying your account.
                wait.Until((d) => d.FindElement(By.XPath("//button[contains(.,'Yes! Count me in')]")));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Yes! Count me in')]")));

                // Clicks the top left menu button and logs out of the account.
                CustomWait.WaitForElementToExist(TopLeftMenuButton);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='menu-btn-icon']")));
                TopLeftMenuButton.Click();
                CustomWait.WaitForElementToExist(LogOutButton);
                LogOutButton.Click();

                // Accepts the log out alert.
                IAlert logOutAlert = driver.SwitchTo().Alert();
                logOutAlert.Accept();
            }
            else if (successOrFailure.Equals("allFieldsNotEntered"))
            {
                wait.Until((d) => d.FindElements(By.XPath("//span[contains(.,'Required')]")).Count != 0);
            }
            else if (successOrFailure.Equals("personalEmailFormatInvalid"))
            {
                wait.Until((d) => d.FindElement(By.Id("AP_Register_txtEmailAddress_Validation")));
            }
            else if (successOrFailure.Equals("emailsDoNotMatch"))
            {
                wait.Until((d) => d.FindElement(By.Id("AP_Register_txtConfirmEmailAddress_Validation")));
            }
            else if (successOrFailure.Equals("passwordFormatInvalid"))
            {
                wait.Until((d) => d.FindElement(By.Id("AP_Register_txtPassword_Validation")));
            }
            else if (successOrFailure.Equals("passwordsDoNotMatch"))
            {
                wait.Until((d) => d.FindElement(By.Id("AP_Register_txtConfirmPassword_Validation")));
            }
            else if (successOrFailure.Equals("missingGenderOption"))
            {
                wait.Until((d) => d.FindElement(By.XPath("//span[@class='field-validation-message field-validation-error']")));
            }
            else if (successOrFailure.Equals("missingAcceptTerms"))
            {
                wait.Until((d) => d.FindElement(By.Id("AP_Register_chkAgreeToTerms_Validation")));
            }
            else
            {
                throw new Exception("Unexpected error returned.");
            }

            return new UNiDAY_JoinNowPage();
        }
    }
}
