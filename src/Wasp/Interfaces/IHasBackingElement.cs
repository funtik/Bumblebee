using OpenQA.Selenium;

namespace Wasp.Interfaces
{
    public interface IHasBackingElement
    {
        IWebElement Tag { get; }
    }
}
