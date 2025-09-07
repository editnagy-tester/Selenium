using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Security.AccessControl;
using OpenQA.Selenium.Chrome;

namespace SeleniumProject.Hooks
{
    [TestFixture]
    public abstract class TestBase
    {
        // This class can be used to set up and tear down test environments, initialize WebDriver instances, and manage common test configurations. 
        protected IWebDriver driver;

        [OneTimeSetUp] //runs once before any tests in the derived class
        public void GlobalSetup() {
        
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.linkedin.com/");

            AcceptCookies();
            LogIn("smallcatnip@gmail.com", "Badcatnip123"); //test profile for linkedin
        }

        //[SetUp]
        //public void TestSetup()
        //{
        //    // runs before each test
        //}

        [OneTimeTearDown] //runs once after all tests in the derived class
        public void GlobalTeardown() {
            if (driver != null)
            { 
                driver.Quit();   // closes browser + ends WebDriver session
                driver.Dispose(); // extra cleanup (safe to call after Quit)
            }
        }

        private void AcceptCookies() {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var acceptCookiesButton = wait.Until(d => d.FindElement(By.CssSelector("button[action-type='ACCEPT']")));
            acceptCookiesButton.Click();
        }

        private void LogIn(string email, string password) {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var signInButton = wait.Until(d => d.FindElement(By.CssSelector("a[href*='/login/hu']")));
            signInButton.Click();
            var usernameField = wait.Until(d => d.FindElement(By.Id("username")));
            usernameField.SendKeys(email);
            var passwordField = driver.FindElement(By.Id("password"));
            passwordField.SendKeys(password);
            var submitButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Click();

            //check if it was successful and header is visible
            var header = wait.Until(d => d.FindElement(By.ClassName("global-nav__content")));

        }
    }
}
