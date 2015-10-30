using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
//using NUnit.Framework;
using OpenQA.Selenium;
using MbUnit.Framework;
using SeleniumWebdriverProject_BAT_Tests.Helpers;

namespace SeleniumWebdriverProject_BAT_Tests.Tests
{
   
    [TestFixture]
    [Parallelizable(TestScope.All)]
    public class HomePage
    {
        private IWebDriver _driver;
        private Helper helper;
        private static string[] browsers = ConfigurationManager.AppSettings["Browsers"].Split(',');
        private string browser;

        public static IEnumerable<string> GetBrowser
        {
            get
            {
                foreach (var selectedBrowser in browsers)
                {
                    yield return selectedBrowser;
                }
            }
        }
        
        [Factory("GetBrowser")]
        public HomePage(string browser)
        {
            this.browser = browser;
        }
        
        [SetUp]
        public void Setup()
        {
            
            helper = new Helper(browser);
            _driver = helper.Driver;
        }
        
        [Test]
        public void HomePage_Hero()
        {

            _driver.Navigate().GoToUrl(helper.BaseUrl);
            Thread.Sleep(1000);
            IWebElement HeroId = _driver.FindElement(By.CssSelector(".hero-home"));
            Assert.IsTrue(HeroId.Displayed);
            helper.GetSessionId();
        }


        [Test]
        public void HomePage_CampaignTeaser()
        {
            _driver.Navigate().GoToUrl(helper.BaseUrl);
            Thread.Sleep(1000);
            IWebElement CampaginTeaserId = helper.Driver.FindElement(By.CssSelector(".campaign-teaser a"));
            Assert.IsTrue(CampaginTeaserId.Displayed);
            helper.GetSessionId();
        }


        [Test]
        public void HomePage_CampaignOffers()
        {
            _driver.Navigate().GoToUrl(helper.BaseUrl);
            Thread.Sleep(1000);
            IWebElement CampaignOfferId = helper.Driver.FindElement(By.CssSelector(".campaign-offers"));
            Assert.IsTrue(CampaignOfferId.Displayed);
            helper.GetSessionId();
            
        }

        [TearDown]
        public void Teardown()
        {
            
            Console.WriteLine("Teardown SessionId");
            helper.GetSessionId();
            helper.Driver.Quit();
        }
    }
}
