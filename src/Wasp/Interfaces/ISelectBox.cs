using System.Collections.Generic;

namespace Wasp.Interfaces
{
    public interface ISelectBox : IElement
    {
        IEnumerable<IOption> Options { get; }
    }

#pragma warning disable CS0618 // 'IGenericElement<TResult>' is obsolete: 'This interface is not needed and will be removed in a future release.'
    public interface ISelectBox<out TResult> : IGenericElement<TResult>
#pragma warning restore CS0618 // 'IGenericElement<TResult>' is obsolete: 'This interface is not needed and will be removed in a future release.'
        where TResult : IBlock
    {
        IEnumerable<IOption<TResult>> Options { get; }
    }
}
