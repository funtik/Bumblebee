using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class TextField : Element, ITextField
    {
        public TextField(IBlock parent, By by) : base(parent, by)
        {
        }

        public TextField(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public TResult Press<TResult>(Key key) where TResult : IBlock
        {
            this.Tag.SendKeys(key.Value);

            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }

        public virtual TCustomResult EnterText<TCustomResult>(string text) where TCustomResult : IBlock
        {
            this.Tag.Clear();

            return this.AppendText<TCustomResult>(text);
        }

        public virtual TResult AppendText<TResult>(string text) where TResult : IBlock
        {
            this.Tag.SendKeys(text);

            return this.Session.CurrentBlock<TResult>(this.ParentBlock.Tag);
        }

        public override string Text
        {
            get { return this.Tag.GetAttribute("value"); }
        }
    }

    public class TextField<TResult> : TextField, ITextField<TResult> where TResult : IBlock
    {
        public TextField(IBlock parent, By by) : base(parent, by)
        {
        }

        public TextField(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public TResult Press(Key key)
        {
            return this.Press<TResult>(key);
        }

        public virtual TResult EnterText(string text)
        {
            return this.EnterText<TResult>(text);
        }

        public virtual TResult AppendText(string text)
        {
            return this.AppendText<TResult>(text);
        }
    }
}
