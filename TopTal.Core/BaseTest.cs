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
using TopTal.Core.Models;
using TopTal.Utilities;

namespace TopTal.Core
{
    public abstract class BaseTest
    {
        public IWebDriver Driver;

        public BaseTest() 
        {
            Driver = new FirefoxDriver();
        }


        [TestInitialize]
        public void Init()
        {
            HostConfigs hostConfigs = ConfigurationProvider.GetHostConfigurations();
            NtlmAuthentication ntlmAuthentication = new NtlmAuthentication();

            Driver.Manage().Window.Maximize();
            Driver.Url = hostConfigs.Url;

            ntlmAuthentication
                .InsertCredenntialsAndLogin(hostConfigs.Login, hostConfigs.Password);

        }


        [TestCleanup]
        public void CleanUp() 
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Quit();
        }
    }
}
