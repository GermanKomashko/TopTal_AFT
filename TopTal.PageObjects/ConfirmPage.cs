using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace TopTal.PageObjects
{
    public class ConfirmPage : ProfilePage
    {
        [FindsBy(How = How.XPath, Using = "//label[@for='new_job_accept_review']")]
        private IWebElement _acceptReviewCheckBox;

         [FindsBy(How = How.XPath, Using = "//label[@for='new_job_accept_deposit']")]
        private IWebElement _acceptDepositCheckBox;

         [FindsBy(How = How.XPath, Using = "//label[@for='new_job_accept_interview']")]
        private IWebElement _acceptInterviewCheckbox;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(), 'Submit and See')]")]
        private IWebElement _submitButton;


        public ConfirmPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void ClickAcceptReviewCheckBox()
        {
            _acceptReviewCheckBox.Click();
        }

        public void ClickAcceptDepositCheckBox()
        {
            _acceptDepositCheckBox.Click();
        }

        public void ClickAcceptInterviewCheckBox()
        {
            _acceptInterviewCheckbox.Click();
        }

        public WhatsNextPage ClickSubmitButton()
        {
            _submitButton.Click();

            return new WhatsNextPage(Driver);
        }

        public void ConfirmAllAndSubmit()
        {
            ClickAcceptReviewCheckBox();
            ClickAcceptDepositCheckBox();
            ClickAcceptInterviewCheckBox();

            ClickSubmitButton();
        }
    }
}
