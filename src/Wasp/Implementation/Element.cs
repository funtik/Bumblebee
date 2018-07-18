using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public abstract class Element : SpecificBlock
    {
        public IBlock ParentBlock { get; private set; }

        protected Element(IBlock parent, By by) : base(parent.Session, parent.Tag.FindElement(by))
        {
            this.ParentBlock = parent;
        }

        protected Element(IBlock parent, IWebElement tag) : base(parent.Session, tag)
        {
            this.ParentBlock = parent;
        }

        public virtual string Text
        {
            get { return this.Tag.Text; }
        }

        public virtual bool Selected
        {
            get { return this.Tag.Selected; }
        }
    }
}
