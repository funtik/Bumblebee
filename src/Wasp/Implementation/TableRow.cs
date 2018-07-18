using System.Collections;
using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;

using Wasp.Interfaces;

namespace Wasp.Implementation
{
    public class TableRow : Element, ITableRow
    {
        private readonly IDictionary<string, string> _data;

        public string this[int index]
        {
            get { return this._data.Values.ElementAt(index); }
        }

        public string this[string column]
        {
            get { return this._data[column]; }
        }

        public TableRow(IBlock parent, By @by) : base(parent, @by)
        {
            this._data = this.ParentBlock.Tag
                .FindElement(By.TagName("thead"))
                .FindElement(By.TagName("tr"))
                .FindElements(By.TagName("th"))
                .Zip(this.FindElements(By.TagName("td")), (header, cell) => new KeyValuePair<string, string>(header.Text, cell.Text))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        public TableRow(IBlock parent, IWebElement tag) : base(parent, tag)
        {
            this._data = this.ParentBlock.Tag
                .FindElement(By.TagName("thead"))
                .FindElement(By.TagName("tr"))
                .FindElements(By.TagName("th"))
                .Zip(this.FindElements(By.TagName("td")), (header, cell) => new KeyValuePair<string, string>(header.Text, cell.Text))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return this._data.Values.GetEnumerator();
        }
    }
}
