using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

using Wasp.Helpers;

namespace Wasp.Setup.DriverEnvironments
{
    public class RemoteIPhone : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var uri = $"http://172.30.28.98:4766/wd/hub";
            var capability = new DesiredCapabilities();
            capability.SetCapability(CapabilityType.BrowserName, new SafariOptions().BrowserName);
            capability.SetCapability("platformName", "iOS");
            capability.SetCapability("deviceName", "FK2PQMAAG5QQ");
            capability.SetCapability("udid", "b929e43a9395f94562fd2508e4dbda0197bc75db");
            capability.SetCapability("startIWDP", true);
            capability.SetCapability(CapabilityType.Platform, "Mac");
            capability.SetCapability(CapabilityType.AcceptSslCertificates, true);
            capability.SetCapability(CapabilityType.AcceptInsecureCertificates, true);
            var driver = new RemoteWebDriver(new Uri(uri), capability, ConfigHelper.GetInstance().DefaultCommandTimeout);
            Thread.Sleep(500);
            driver.Manage().Timeouts().ImplicitWait = ConfigHelper.GetInstance().DefaultImplicitWait;
            return driver;
        }
    }
}
