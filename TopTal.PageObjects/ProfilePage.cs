using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTal.PageObjects
{
    public class ProfilePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[.='Add New Job']")]
        protected IWebElement AddNewJobButton;


        public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public BasicInfoPage ClickAddNewJobButton() 
        {
            AddNewJobButton.Click();

            return new BasicInfoPage(Driver);
        }

        public IReadOnlyCollection<IWebElement> GetErrorsList()
        {
            return Driver.FindElements(By.ClassName("error"));
        }

    }
}
