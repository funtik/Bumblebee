using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    internal class WebDragAndDropPerformer : IPerformsDragAndDrop
    {
        public IWebDriver Driver { get; private set; }

        public WebDragAndDropPerformer(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void DragAndDrop(IWebElement drag, IWebElement drop)
        {
            new Actions(this.Driver).DragAndDrop(drag, drop).Build().Perform();
        }

        public void DragAndDrop(IWebElement drag, int xDrop, int yDrop)
        {
            new Actions(this.Driver).DragAndDropToOffset(drag, xDrop, yDrop).Build().Perform();
        }
    }
}
