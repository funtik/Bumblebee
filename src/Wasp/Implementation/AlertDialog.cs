using System;

using OpenQA.Selenium;

using Wasp.Interfaces;
using Wasp.Setup;
using Wasp.Support;

namespace Wasp.Implementation
{
    public class AlertDialog : Block, IAlertDialog
    {
        private IWebElement Parent { get; set; }
        private IAlert Alert { get; set; }

        public AlertDialog(Session session) : base(session)
        {
            this.Parent = null;
            this.Alert = this.WaitForAlert();
        }

        public AlertDialog(IWebElement parent, Session session) : base(session)
        {
            this.Parent = parent;
            this.Alert = this.WaitForAlert();
        }

        private IAlert WaitForAlert()
        {
            var wait = new WebDriverWait(this.Session.Driver, new TimeSpan(0, 0, 5));
            return wait.Until(d => d.SwitchTo().Alert());
        }

        public virtual TResult Accept<TResult>() where TResult : IBlock
        {
            this.Alert.Accept();
            return this.Session.CurrentBlock<TResult>(this.Parent);
        }

        public virtual TResult Dismiss<TResult>() where TResult : IBlock
        {
            this.Alert.Dismiss();
            return this.Session.CurrentBlock<TResult>(this.Parent);
        }

        public virtual IAlertDialog EnterText(string text)
        {
            this.Alert.SendKeys(text);
            return this;
        }

        public virtual string Text
        {
            get { return this.Alert.Text; }
        }
    }
}
