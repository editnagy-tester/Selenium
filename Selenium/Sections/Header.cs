using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Sections
{
    public class HeaderSection
    {
        private readonly IWebDriver driver;

        //common class for all header buttons
        private By HeaderButtons => By.CssSelector("a.YTEbxfHDGCFyuvPAyVvzNRyzZYcheiwKQ");
        //search button
        private By SearchButton => By.ClassName("search-global-typeahead__collapsed-search-button");
        //search input field
        private By SearchInput => By.CssSelector("input[data-view-name='search-global-typeahead-input']");

        //hrefContains values for different buttons:
        private readonly Dictionary<string, string> buttonHrefs = new()
        {
            {"Home", "/feed/"},
            {"My Network", "/mynetwork/"},
            {"Jobs", "/jobs/"},
            {"Messages", "/messaging/"},
            {"Notifications", "/notifications/"},
            {"Profile", "/me/"}
        };

        public HeaderSection(IWebDriver webDriver)
        {
            driver = webDriver;
        }
        public void ClickHeaderButtonByName(string buttonName)
        {
            if (!buttonHrefs.ContainsKey(buttonName))
            {
                throw new ArgumentException($"No header button found with name '{buttonName}'.");
            }
            string hrefPart = buttonHrefs[buttonName];
            ClickHeaderButtonByHref(hrefPart);
        }
        private void ClickHeaderButtonByHref(string hrefContains)
        {
            var buttons = driver.FindElements(HeaderButtons);
            var buttonToClick = buttons.FirstOrDefault(b => b.GetAttribute("href").Contains(hrefContains));
            if (buttonToClick == null)
            {
                throw new NoSuchElementException($"No header button found with href containing '{hrefContains}'");
            }
            //log here TO DO
            buttonToClick.Click();
                
        }

        public void ClickSearchButton()
        {
            var searchButton = DriverHelpers.WaitForElement(driver, SearchButton, 20);
            //log here TO DO
            searchButton.Click();
        }

        public void TypeSearchTextAndPressEnter(string text)
        {
            var searchInput = driver.FindElement(SearchInput);
            searchInput.Clear();
            searchInput.SendKeys(text);
            searchInput.SendKeys(Keys.Enter);
            //log here TO DO
        }
    }
}
