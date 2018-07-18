using System;

using OpenQA.Selenium.Firefox;

namespace Wasp.Setup.DriverEnvironments
{
    public class Firefox : SimpleDriverEnvironment<FirefoxDriver>
    {
        public Firefox()
        {
        }

        public Firefox(TimeSpan timeToWait) : base(timeToWait)
        {
        }
    }
}
