using AutoItX3Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace TopTal.Core
{
    public abstract class BaseTest
    {
        public IWebDriver Driver;

        private readonly string url = "http://toptal:staging@staging.toptal.net/";


        public BaseTest() 
        {
            Driver = new FirefoxDriver();
        }


        [TestInitialize]
        public void Init() 
        {
            Driver.Manage().Window.Maximize();
            Driver.Url = url;
            AutoriseToProxy();
        }


        [TestCleanup]
        public void CleanUp() 
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Quit();
        }


        private void AutoriseToProxy()
        {
            var autoIT = new AutoItX3();

            //Set Selenium page load timeout to 2 seconds so it doesn't wait forever
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(2));
            
            //Wait for the authentication window to appear, then send username and password
            autoIT.WinWait("Требуется Аутентификация", "Welcome to Toptal", 10);
            autoIT.WinActivate("Authentication Required");
            autoIT.Send("toptal");
            autoIT.Send("{TAB}");
            autoIT.Send("staging");
            autoIT.Send("{ENTER}");

            //Return Selenium page timeout to infinity again
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(-1));
        }
    }
}
