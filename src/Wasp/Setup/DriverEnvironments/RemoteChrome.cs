using System;
using System.Drawing;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

using Wasp.Helpers;

namespace Wasp.Setup.DriverEnvironments
{
    public class RemoteChrome : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var uri = $"http://{ConfigHelper.GetInstance().SeleniumHubServer}/wd/hub";
            var capability = new DesiredCapabilities();
            capability.SetCapability(CapabilityType.BrowserName, DesiredCapabilities.Chrome().BrowserName);
            capability.SetCapability(CapabilityType.Platform, "LINUX");
            var driver = new RemoteWebDriver(new Uri(uri), capability, TimeSpan.FromSeconds(60));
            Thread.Sleep(500);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Timeouts().ImplicitWait = ConfigHelper.GetInstance().DefaultImplicitWait;
            return driver;
        }
    }
}
