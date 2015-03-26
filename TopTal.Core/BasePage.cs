using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;


namespace TopTal.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected Actions Actions;


        public BasePage(IWebDriver driver) 
        {
            Driver = driver;

            Actions = new Actions(Driver);
        }
    }
}
