using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TopTal.PageObjects
{
    public class WhatsNextPage : ProfilePage
    {
        [FindsBy(How = How.ClassName, Using = "wizard_complete__title")]
        private IWebElement _confimTitle;

        [FindsBy(How = How.ClassName, Using = "js-goto-job")]
        private IWebElement _jumpToJobButton;

        public WhatsNextPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string ConfirmTitle
        {
            get { return _confimTitle.Text; }
        }


        public void ClickJumpToJobButton()
        {
            _jumpToJobButton.Click();   
        }
    }
}
