namespace Bumblebee.Interfaces
{
	public interface IClickable : IElement, IHasText
	{
		TResult Click<TResult>() where TResult : IBlock;
	}

#pragma warning disable CS0618 // 'IGenericElement<TResult>' is obsolete: 'This interface is not needed and will be removed in a future release.'
	public interface IClickable<out TResult> : IClickable, IGenericElement<TResult>
#pragma warning restore CS0618 // 'IGenericElement<TResult>' is obsolete: 'This interface is not needed and will be removed in a future release.'
		where TResult : IBlock
	{
		TResult Click();
	}
}
