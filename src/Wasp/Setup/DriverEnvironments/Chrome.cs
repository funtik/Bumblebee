using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Wasp.Setup.DriverEnvironments
{
    public class Chrome : IDriverEnvironment
    {
        public IWebDriver CreateWebDriver()
        {
            var driver = new ChromeDriver(Directory.GetCurrentDirectory());
            FixDriverCommandExecutionDelay(driver);
            Thread.Sleep(500);
            try
            {
                driver.Manage().Window.Maximize();
            }
            catch
            {
                driver.Manage().Window.Size = new Size(1920, 1080);
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return driver;
        }

        private static void FixDriverCommandExecutionDelay(RemoteWebDriver driver)
        {
            try
            {
                PropertyInfo commandExecutorProperty = typeof(RemoteWebDriver).GetProperty("CommandExecutor",
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty);
                ICommandExecutor commandExecutor = (ICommandExecutor)commandExecutorProperty.GetValue(driver);

                FieldInfo GetRemoteServerUriField(ICommandExecutor executor)
                {
                    return executor.GetType().GetField("remoteServerUri",
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField);
                }

                FieldInfo remoteServerUriField = GetRemoteServerUriField(commandExecutor);

                if (remoteServerUriField == null)
                {
                    FieldInfo internalExecutorField = commandExecutor.GetType()
                        .GetField("internalExecutor", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
                    commandExecutor = (ICommandExecutor)internalExecutorField.GetValue(commandExecutor);
                    remoteServerUriField = GetRemoteServerUriField(commandExecutor);
                }

                if (remoteServerUriField != null)
                {
                    string remoteServerUri = remoteServerUriField.GetValue(commandExecutor).ToString();

                    string localhostUriPrefix = "http://localhost";

                    if (remoteServerUri.StartsWith(localhostUriPrefix))
                    {
                        remoteServerUri = remoteServerUri.Replace(localhostUriPrefix, "http://127.0.0.1");

                        remoteServerUriField.SetValue(commandExecutor, new Uri(remoteServerUri));
                        return;
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
