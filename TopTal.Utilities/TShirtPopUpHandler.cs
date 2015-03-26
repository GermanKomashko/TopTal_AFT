using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTal.Utilities
{
    public class TShirtPopUpHandler
    {
        private readonly IWebDriver _driver;


        public TShirtPopUpHandler(IWebDriver driver)
        {
            _driver = driver;
        }


        public bool IsTshirtPopUpExists()
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement tshirtModalWindow = 
            _driver.FindElement(By.ClassName("js-bounce_modal-tshirt_form_content"));


            return (tshirtModalWindow != null &&
                    tshirtModalWindow.Displayed &&
                    tshirtModalWindow.Enabled);
        }

        public void CloseTShirtPopUp() 
        {
           IWebElement tshirtModalWindow =
           _driver.FindElement(By.ClassName("js-bounce_modal-tshirt_form_content"));

           tshirtModalWindow.FindElement(By.ClassName("bounce_modal-close_icon")).Click();
        }
    }
}
