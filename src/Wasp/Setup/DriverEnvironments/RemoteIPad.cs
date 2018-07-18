using System;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace Wasp.Setup.DriverEnvironments
{
    public class RemoteIPad : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var uri = $"http://172.30.28.98:4767/wd/hub";
            var capability = new DesiredCapabilities();
            capability.SetCapability(CapabilityType.BrowserName, new SafariOptions().BrowserName);
            capability.SetCapability("platformName", "iOS");
            capability.SetCapability("deviceName", "iPad");
            capability.SetCapability("udid", "a70e4a654e8329ef5d5ae9f0782afac73c0192a7");
            capability.SetCapability("startIWDP", true);
            capability.SetCapability(CapabilityType.Platform, "Mac");
            capability.SetCapability(CapabilityType.AcceptSslCertificates, true);
            capability.SetCapability(CapabilityType.AcceptInsecureCertificates, true);
            var driver = new RemoteWebDriver(new Uri(uri), capability);
            Thread.Sleep(500);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }
    }
}
