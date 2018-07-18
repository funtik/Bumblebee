using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class Checkbox : Element, ICheckbox
    {
        public Checkbox(IBlock parent, By by) : base(parent, by)
        {
        }

        public Checkbox(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public TCustomResult Check<TCustomResult>() where TCustomResult : IBlock
        {
            if (!this.Selected) this.Tag.Click();
            return this.Session.CurrentBlock<TCustomResult>(this.ParentBlock.Tag);
        }

        public TCustomResult Uncheck<TCustomResult>() where TCustomResult : IBlock
        {
            if (this.Selected) this.Tag.Click();
            return this.Session.CurrentBlock<TCustomResult>(this.ParentBlock.Tag);
        }

        public TCustomResult Toggle<TCustomResult>() where TCustomResult : IBlock
        {
            this.Tag.Click();
            return this.Session.CurrentBlock<TCustomResult>(this.ParentBlock.Tag);
        }
    }

    public class Checkbox<TResult> : Checkbox, ICheckbox<TResult> where TResult : IBlock
    {
        public Checkbox(IBlock parent, By by) : base(parent, by)
        {
        }

        public Checkbox(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public virtual TResult Check()
        {
            if (!this.Selected) this.Tag.Click();
            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }

        public virtual TResult Uncheck()
        {
            if (this.Selected) this.Tag.Click();
            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }

        public virtual TResult Toggle()
        {
            this.Tag.Click();
            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }
    }
}
