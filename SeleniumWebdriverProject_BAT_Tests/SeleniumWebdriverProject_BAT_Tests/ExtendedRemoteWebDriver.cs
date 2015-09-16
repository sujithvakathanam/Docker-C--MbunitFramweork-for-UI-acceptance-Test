using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace SeleniumWebdriverProject_BAT_Tests
{
   
    public class ExtendedRemoteWebDriver : RemoteWebDriver, ITakesScreenshot

    {

        private readonly Uri _remoteHost;

        public ExtendedRemoteWebDriver(Uri remoteHost, ICapabilities capabilities)
            : base(remoteHost, capabilities)

        {

            _remoteHost = remoteHost;

        }

        public string GetNodeHost()

        {

            var uri = new Uri(string.Format("http://{0}:{1}/grid/api/testsession?session={2}", _remoteHost.Host, _remoteHost.Port, SessionId));
            

            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = "POST";

            request.ContentType = "application/json";



            using(var httpResponse = (HttpWebResponse)request.GetResponse())

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

            {

                var response = JObject.Parse(streamReader.ReadToEnd());

                return response.SelectToken("proxyId").ToString();

            }

        }

       

        //this will allow screenshots to be taken from the remote browser

        public new Screenshot GetScreenshot()

        {

            return new Screenshot(Execute(DriverCommand.Screenshot, null).Value.ToString());

        }

    }
}
