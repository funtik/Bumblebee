using OpenQA.Selenium;

using Wasp.Extensions;
using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class RadioButton<TResult> : Option<TResult> where TResult : IBlock
    {
        public RadioButton(IBlock parent, By by) : base(parent, by)
        {
        }

        public RadioButton(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public override string Text
        {
            get { return this.ParentBlock.Tag.FindElement(By.CssSelector("label[for=\"" + this.Tag.GetID() + "\"]")).Text; }
        }
    }
}
