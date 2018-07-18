using System;

using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class DateField : TextField, IDateField
    {
        public DateField(IBlock parent, By by) : base(parent, by)
        {
        }

        public DateField(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public virtual TCustomResult EnterDate<TCustomResult>(DateTime date) where TCustomResult : IBlock
        {
            var executor = (IJavaScriptExecutor)this.Session.Driver;
            executor.ExecuteScript(String.Format("arguments[0].value = '{0:yyyy-MM-dd}';", date), this.Tag);

            return this.Session.CurrentBlock<TCustomResult>(this.ParentBlock.Tag);
        }

        public virtual DateTime? Value
        {
            get
            {
                DateTime result;
                return DateTime.TryParse(this.Text ?? String.Empty, out result) ? result : new DateTime?();
            }
        }
    }

    public class DateField<TResult> : DateField, IDateField<TResult>
        where TResult : IBlock
    {
        public DateField(IBlock parent, By by) : base(parent, by)
        {
        }

        public DateField(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public virtual TResult EnterDate(DateTime date)
        {
            return this.EnterDate<TResult>(date);
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
