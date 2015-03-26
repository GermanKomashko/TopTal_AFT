using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TopTal.Utilities
{
    public static class Scrolling
    {
        public static void ScrollDown(IWebDriver driver, int pixels)
        {
            ((IJavaScriptExecutor)driver)
                 .ExecuteScript(String.Format("window.scroll(0, {0});", pixels));     
        }
    }
}
