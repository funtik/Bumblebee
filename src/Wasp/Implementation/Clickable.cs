using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class Clickable : Element, IClickable, IDoubleClickable
    {
        public Clickable(IBlock parent, By by) : base(parent, by)
        {
        }

        public Clickable(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public virtual TResult Click<TResult>()
            where TResult : IBlock
        {
            this.Tag.Click();

            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }

        public virtual TResult DoubleClick<TResult>()
            where TResult : IBlock
        {
            new Actions(this.Session.Driver)
                .MoveToElement(this.Tag)
                .DoubleClick()
                .Build()
                .Perform();

            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }
    }

    public class Clickable<TResult> : Clickable, IClickable<TResult>, IDoubleClickable<TResult>
        where TResult : IBlock
    {
        public Clickable(IBlock parent, By by) : base(parent, by)
        {
        }

        public Clickable(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public virtual TResult Click()
        {
            return this.Click<TResult>();
        }

        public virtual TResult DoubleClick()
        {
            return this.DoubleClick<TResult>();
        }
    }
}
