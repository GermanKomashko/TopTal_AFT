using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTal.Utilities;

namespace TopTal.PageObjects
{
    public class LandingPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[.='Login']")]
        private IWebElement _loginButton;
        

        public LandingPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);

            PrepareLandingPage();
        }

        public void PrepareLandingPage()
        {
            TShirtPopUpHandler popUpHandler = new TShirtPopUpHandler(Driver);

            if (popUpHandler.IsTshirtPopUpExists())
            {
                popUpHandler.CloseTShirtPopUp(); 
            }
        }

        public LoginPage OpenLoginPage() 
        {
            _loginButton.Click();

            return new LoginPage(Driver);
        }
    }
}
