using System;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

using Wasp.Helpers;

namespace Wasp.Setup.DriverEnvironments
{
    public class RemoteIE : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var uri = $"http://{ConfigHelper.GetInstance().SeleniumHubServer}/wd/hub";
            var capability = new DesiredCapabilities();
            capability.SetCapability(CapabilityType.BrowserName, new InternetExplorerOptions().BrowserName);
            capability.SetCapability(CapabilityType.Platform, "WINDOWS");
            capability.SetCapability("enablePersistentHover", false);
            capability.SetCapability("ie.ensureCleanSession", true);

            var driver = new RemoteWebDriver(new Uri(uri), capability, ConfigHelper.GetInstance().DefaultCommandTimeout);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = ConfigHelper.GetInstance().DefaultImplicitWait;
            return driver;
        }
    }
}
