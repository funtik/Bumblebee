using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class Option : Element, IOption
    {
        public Option(IBlock parent, By by) : base(parent, by)
        {
        }

        public Option(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public virtual TResult Click<TResult>() where TResult : IBlock
        {
            this.ParentBlock.Tag.Click();
            this.Tag.Click();
            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }
    }

    public class Option<TResult> : Clickable<TResult>, IOption<TResult> where TResult : IBlock
    {
        public Option(IBlock parent, By by) : base(parent, by)
        {
        }

        public Option(IBlock parent, IWebElement element) : base(parent, element)
        {
        }
    }
}
