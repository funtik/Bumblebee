using OpenQA.Selenium;

namespace Wasp.Setup
{
    public interface IDriverEnvironment
    {
        IWebDriver CreateWebDriver();
    }
}
