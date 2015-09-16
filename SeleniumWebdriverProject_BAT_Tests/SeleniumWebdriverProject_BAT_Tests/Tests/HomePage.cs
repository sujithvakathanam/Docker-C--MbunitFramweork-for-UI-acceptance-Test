using System;
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
        
        
        [SetUp]
        public void Setup()
        {
            
            helper = new Helper();
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
