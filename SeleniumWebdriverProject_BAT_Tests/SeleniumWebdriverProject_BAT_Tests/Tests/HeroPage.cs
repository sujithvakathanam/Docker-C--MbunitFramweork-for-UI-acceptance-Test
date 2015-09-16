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
    public class HeroPage 
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
        public void HomePage_TopCities()
        {
            _driver.Navigate().GoToUrl(helper.BaseUrl);
            Thread.Sleep(1000);
            IWebElement TopCitiesId = helper.Driver.FindElement(By.CssSelector(".top-cities"));
            Assert.IsTrue(TopCitiesId.Displayed);
            helper.GetSessionId();

        }


        [Test]
        public void HomePage_PopularAreas()
        {
            _driver.Navigate().GoToUrl(helper.BaseUrl);
            Thread.Sleep(1000);
            IWebElement PopularAreasId = helper.Driver.FindElement(By.CssSelector(".popular-areas"));
            Assert.IsTrue(PopularAreasId.Displayed);
            helper.GetSessionId();

        }

        [Test]
        public void HomePage_MicoPromotion()
        {
            _driver.Navigate().GoToUrl(helper.BaseUrl);
            Thread.Sleep(2000);
            IWebElement MicroPromotionId = helper.Driver.FindElement(By.CssSelector(".micro-promotions"));
            Assert.IsTrue(MicroPromotionId.Displayed);
            Assert.IsTrue(helper.Driver.FindElement(By.CssSelector("header nav li.inline")).Displayed);
            Assert.IsTrue(helper.Driver.FindElement(By.CssSelector("html body article section footer")).Displayed);
            helper.GetSessionId();

        }



        [Test]
        public void HomePage_Hero()
        {

            _driver.Navigate().GoToUrl(helper.BaseUrl);
            Thread.Sleep(1000);
            IWebElement HeroId = helper.Driver.FindElement(By.CssSelector(".hero-home"));
            Assert.IsTrue(HeroId.Displayed);
            helper.GetSessionId();

        }

        [TearDown]
        public void Teardown()
        {

            Console.WriteLine("Teardown SessionId");
            //helper.GetSessionId();
            helper.Driver.Quit();
        }
    }
}
