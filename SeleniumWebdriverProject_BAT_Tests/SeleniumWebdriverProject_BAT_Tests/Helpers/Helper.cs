using System;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumWebdriverProject_BAT_Tests.Helpers
{
    public class Helper
    {
        public  IWebDriver Driver;
        public string BaseUrl;
        
        public string Browser;
        

        public Helper()
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            Browser = ConfigurationManager.AppSettings["Browser"];
            GetDriver(Browser);
        }
 
     
        public void GetDriver(string browser)
        {

            DesiredCapabilities capability = null;
            switch (browser)
            {

                case "firefox":

                    capability = DesiredCapabilities.Firefox();

                    break;

                case "chrome":

                    capability = DesiredCapabilities.Chrome();

                    break;

                case "ie":

                    capability = DesiredCapabilities.InternetExplorer();

                    break;

                default:

                    capability = DesiredCapabilities.Firefox();

                    break;
            }
            //capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            //var remotehost = new Uri("http://localhost:4444/wd/hub");


            capability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Linux));
            var remotehost = new Uri("http://192.168.59.103:4444/wd/hub");
            
            Driver = new RemoteWebDriver(remotehost, capability);
          

        }

        
        public void GetSessionId()
        {
            var sessionIdProperty = typeof(RemoteWebDriver).GetProperty("SessionId", BindingFlags.Instance | BindingFlags.NonPublic);
            if (sessionIdProperty != null)
            {
                SessionId sessionId = sessionIdProperty.GetValue(Driver, null) as SessionId;
                if (sessionId == null)
                {
                    Trace.TraceWarning("Could not obtain SessionId.");
                }
                else
                {
                    Trace.TraceInformation("SessionId is " + sessionId.ToString());
                    
                }
            }
        }

   
    }
}
