using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

using Wasp.Helpers;

namespace Wasp.Setup.DriverEnvironments
{
    public class RemoteAndroid : IDriverEnvironment
    {
        private readonly string DeviceName;
        private readonly string Version;
        private readonly int Port;

        public RemoteAndroid(string platformType = "mobile", string browser = "chrome")
        {
            if (platformType == "mobile")
            {
                this.DeviceName = "172.27.47.163:5555";
                this.Version = "5.0.2";
                this.Port = 4724;
            }
            else
            {
                this.DeviceName = "172.27.47.164:5555";
                this.Version = "6.0.1";
                this.Port = 4723;
            }
        }

        public IWebDriver CreateWebDriver()
        {
            var uri = $"http://172.30.28.94:{this.Port}/wd/hub";
            var capability = new DesiredCapabilities();
            capability.SetCapability(CapabilityType.BrowserName, new ChromeOptions().BrowserName);
            capability.SetCapability("platformName", "Android");
            capability.SetCapability(CapabilityType.Platform, "Android");
            capability.SetCapability(CapabilityType.Version, this.Version);
            capability.SetCapability("deviceName", this.DeviceName);
            capability.SetCapability(CapabilityType.AcceptSslCertificates, true); 
            capability.SetCapability("ignoreUnimportantViews", true);
            capability.SetCapability("disableAndroidWatchers", true);
            capability.SetCapability("nativeWebScreenshot", true);
            var driver = new RemoteWebDriver(new Uri(uri), capability, ConfigHelper.GetInstance().DefaultCommandTimeout);
            Thread.Sleep(500);
            driver.Manage().Timeouts().ImplicitWait = ConfigHelper.GetInstance().DefaultImplicitWait;
            return driver;
        }
    }
}
