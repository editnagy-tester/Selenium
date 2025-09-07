using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Helpers
{
    public static class DriverHelpers
    {
        // This class can contain utility methods for WebDriver operations, such as waiting for elements, taking screenshots, or handling browser alerts.
        public static void LogStep()
        {
            TestContext.Progress.WriteLine($"Step executed at: {DateTime.Now}");
        }

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }
    }
}
