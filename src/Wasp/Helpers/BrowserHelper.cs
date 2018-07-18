using System;

using Wasp.Enums;
using Wasp.Setup;
using Wasp.Setup.DriverEnvironments;

namespace Wasp.Helpers
{
    public static class BrowserHelper
    {
        public static Session StartBrowser(BrowserType browserType = BrowserType.None)
        {
            if (browserType == BrowserType.None)
            {
                Enum.TryParse(ConfigHelper.GetInstance().WebDriverName, true, out browserType);
            }

            Session browser = null;

            if (ConfigHelper.GetInstance().IsLocalTestRun)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        browser = Threaded<Session>.With(new Chrome());
                        break;
                    case BrowserType.Ie:
                        browser = Threaded<Session>.With(new InternetExplorer());
                        break;
                    case BrowserType.Firefox:
                        browser = Threaded<Session>.With(new Firefox());
                        break;
                    default:
                        browser = Threaded<Session>.With(new Chrome());
                        break;
                }
            }
            else
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        browser = Threaded<Session>.With(new RemoteChrome());
                        break;
                    case BrowserType.Ie:
                        browser = Threaded<Session>.With(new RemoteIE());
                        break;
                    case BrowserType.Firefox:
                        browser = Threaded<Session>.With(new RemoteFirefox());
                        break;
                    case BrowserType.AndroidMobile:
                        browser = Threaded<Session>.With(new RemoteAndroid());
                        break;
                    case BrowserType.AndroidTablet:
                        browser = Threaded<Session>.With(new RemoteAndroid("tablet"));
                        break;
                    case BrowserType.IosMobile:
                        browser = Threaded<Session>.With(new RemoteIPhone());
                        break;
                    case BrowserType.IosTablet:
                        browser = Threaded<Session>.With(new RemoteIPad());
                        break;
                    default:
                        browser = Threaded<Session>.With(new RemoteChrome());
                        break;
                }
            }

            return browser;
        }
    }
}
