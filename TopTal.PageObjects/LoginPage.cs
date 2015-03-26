using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TopTal.PageObjects
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "user_email")]
        private IWebElement _emailField;

        [FindsBy(How = How.Id, Using = "user_password")]
        private IWebElement _passwordField;

        [FindsBy(How = How.Name, Using = "commit")]
        private IWebElement _loginButton;
        
        
        public LoginPage(IWebDriver driver) : base (driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }


        public ProfilePage LogOn(string email, string password) 
        {
            _emailField.SendKeys(email);
            _passwordField.SendKeys(password);

            _loginButton.Click();

            return new ProfilePage(Driver);
        }
    }
}
