namespace Bumblebee.Interfaces
{
	public interface ICheckbox : IElement, ISelectable
	{
		TCustomResult Check<TCustomResult>() where TCustomResult : IBlock;
		TCustomResult Uncheck<TCustomResult>() where TCustomResult : IBlock;
		TCustomResult Toggle<TCustomResult>() where TCustomResult : IBlock;
	}

#pragma warning disable CS0618 // 'IGenericElement<TResult>' is obsolete: 'This interface is not needed and will be removed in a future release.'
	public interface ICheckbox<out TResult> : ICheckbox, IGenericElement<TResult>
#pragma warning restore CS0618 // 'IGenericElement<TResult>' is obsolete: 'This interface is not needed and will be removed in a future release.'
		where TResult : IBlock
	{
		TResult Check();
		TResult Uncheck();
		TResult Toggle();
	}
}
