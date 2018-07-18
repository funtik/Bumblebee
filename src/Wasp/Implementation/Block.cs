using System;
using System.Collections.Generic;

using OpenQA.Selenium;

using Wasp.Interfaces;
using Wasp.Setup;

namespace Wasp.Implementation
{
    public abstract class Block : IBlock
    {
        public Session Session { get; private set; }

        public IWebElement Tag { get; protected set; }

        protected Block(Session session)
        {
            this.Session = session;

            if (this.Session.Monkey != null)
            {
                this.Session.Monkey.Invoke(this);
            }
        }

        public IList<IWebElement> FindElements(By by)
        {
            if (this.Tag == null)
            {
                throw new NullReferenceException("You can't call GetElements on a block without first initializing Tag.");
            }

            return this.Tag.FindElements(by);
        }

        [Obsolete("This method is obsolete. It will be removed in a future version. Please use FindElements() instead.")]
        public IList<IWebElement> GetElements(By by)
        {
            if (this.Tag == null)
            {
                throw new NullReferenceException("You can't call GetElements on a block without first initializing Tag.");
            }

            return this.Tag.FindElements(by);
        }

        public IWebElement FindElement(By by)
        {
            if (this.Tag == null)
            {
                throw new NullReferenceException("You can't call GetElement on a block without first initializing Tag.");
            }

            return this.Tag.FindElement(by);
        }

        [Obsolete("This method is obsolete. It will be removed in a future version. Please use FindElement() instead.")]
        public IWebElement GetElement(By by)
        {
            if (this.Tag == null)
            {
                throw new NullReferenceException("You can't call GetElement on a block without first initializing Tag.");
            }

            return this.Tag.FindElement(by);
        }

        public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
        {
            return new WebDragAndDropPerformer(this.Session.Driver);
        }

        public virtual void VerifyMonkeyState()
        {
        }
    }
}
