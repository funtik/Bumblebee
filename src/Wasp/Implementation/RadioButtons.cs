using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class RadioButtons<TResult> : IRadioButtons<TResult> where TResult : IBlock
    {
        private IBlock ParentBlock { get; set; }
        private By By { get; set; }

        public RadioButtons(IBlock parent, By by)
        {
            this.ParentBlock = parent;
            this.By = by;
        }

        public virtual IEnumerable<IOption<TResult>> Options
        {
            get
            {
                return this.ParentBlock.Tag.FindElements(this.By)
                    .Where(opt => opt.Displayed)
                    .Select(opt => new RadioButton<TResult>(this.ParentBlock, opt));
            }
        }
    }
}
