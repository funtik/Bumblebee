using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

using Wasp.Helpers;

namespace Wasp.Setup.DriverEnvironments
{
    public class RemoteFirefox : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var uri = $"http://{ConfigHelper.GetInstance().SeleniumHubServer}/wd/hub";
            var capability = new DesiredCapabilities();
            capability.SetCapability(CapabilityType.BrowserName, new FirefoxOptions().BrowserName);
            capability.SetCapability(CapabilityType.AcceptSslCertificates, true);
            capability.SetCapability(CapabilityType.Platform, "Windows");
            var driver = new RemoteWebDriver(new Uri(uri), capability, ConfigHelper.GetInstance().DefaultCommandTimeout);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = ConfigHelper.GetInstance().DefaultImplicitWait;
            return driver;
        }
    }
}
