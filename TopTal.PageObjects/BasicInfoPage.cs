using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTal.PageObjects
{
    public class BasicInfoPage : ProfilePage
    {
        [FindsBy(How = How.Id, Using = "new_job_title")] private IWebElement _titleField;

        [FindsBy(How = How.Id, Using = "new_job_description")] private IWebElement _descriptionField;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")] private IWebElement _nextJobDetailsButton;


        public BasicInfoPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }


        public string TitleField
        {
            set { _titleField.SendKeys(value); }

            get { return _titleField.Text; }
        }


        public string DescriptionField
        {
            set { _descriptionField.SendKeys(value); }

            get { return _descriptionField.Text; }
        }


        public void ClearTitleField()
        {
            _titleField.Clear();
        }

        public void ClearDescriptionField()
        {
            _descriptionField.Clear();
        }

        public DetailsPage ClickNextButton()
        {
            _nextJobDetailsButton.Click();

            return new DetailsPage(Driver);
        }

        public void FillBasicInfoPage(string title, string description)
        {
            TitleField = title;
            DescriptionField = description;

            ClickNextButton();
        }
    }
}
