using OpenQA.Selenium.BiDi.Network;
using SeleniumProject.Hooks;
using SeleniumProject.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Tests
{
    public class Search : TestBase
    {
        private HeaderSection header;

        [SetUp]
        public void Setup()
        {
            header = new HeaderSection(driver);
        }
        [Test]
        public void SearchForJobs()
        {
           header.TypeSearchTextAndPressEnter("QA Engineer");
        }
    }
}
