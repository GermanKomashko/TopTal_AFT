using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTal.Core
{
    public class Driver
    {
        private static IWebDriver _driverInstance;

        public static IWebDriver DriverInstance
        {
            get
            {
                if (_driverInstance == null)
                {
                    var profile = new FirefoxProfile();
                    profile.EnableNativeEvents = false;

                    _driverInstance = new FirefoxDriver(profile);
                }

                return _driverInstance;
            }

        }

        public static void Close()
        {
            if (_driverInstance != null)
            {
                _driverInstance.Quit();
                _driverInstance = null;
            }
        }
    }
}
