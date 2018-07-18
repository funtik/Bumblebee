using System;
using System.Globalization;

using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class NumericField : TextField, INumericField
    {
        public NumericField(IBlock parent, By by) : base(parent, by)
        {
        }

        public NumericField(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public virtual TCustomResult EnterNumber<TCustomResult>(double number) where TCustomResult : IBlock
        {
            this.Tag.Clear();
            this.Tag.SendKeys(number.ToString(CultureInfo.CurrentUICulture));
            return this.Session.CurrentBlock<TCustomResult>(this.ParentBlock.Tag);
        }

        public virtual double? Value
        {
            get
            {
                double result;
                return Double.TryParse(this.Text ?? String.Empty, out result) ? result : new double?();
            }
        }
    }

    public class NumericField<TResult> : NumericField, INumericField<TResult> where TResult : IBlock
    {
        public NumericField(IBlock parent, By by) : base(parent, by)
        {
        }

        public NumericField(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public virtual TResult EnterNumber(double number)
        {
            return this.EnterNumber<TResult>(number);
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
