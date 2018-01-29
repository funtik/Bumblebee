using System.Collections.Generic;
using System.Linq;

using Bumblebee.Interfaces;

using OpenQA.Selenium;

namespace Bumblebee.Implementation
{
	public class SelectBox : Element, ISelectBox
	{
		public SelectBox(IBlock parent, By by) : base(parent, by)
		{
		}

		public SelectBox(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

		public virtual IEnumerable<IOption> Options
		{
			get { return FindElements(By.TagName("option")).Select(opt => new Option(this, opt)); }
		}
	}

	public class SelectBox<TResult> : SelectBox, ISelectBox<TResult>
		where TResult : IBlock
	{
		public SelectBox(IBlock parent, By by) : base(parent, by)
		{
		}

		public SelectBox(IBlock parent, IWebElement element) : base(parent, element)
		{
		}

#pragma warning disable CS0114 // 'SelectBox<TResult>.Options' hides inherited member 'SelectBox.Options'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
		public virtual IEnumerable<IOption<TResult>> Options
#pragma warning restore CS0114 // 'SelectBox<TResult>.Options' hides inherited member 'SelectBox.Options'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword.
		{
			get { return FindElements(By.TagName("option")).Select(opt => new Option<TResult>(ParentBlock, opt)); }
		}
	}
}
