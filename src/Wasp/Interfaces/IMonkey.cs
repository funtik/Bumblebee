using System.Collections.Generic;

namespace Wasp.Interfaces
{
    public interface IMonkey
    {
        void Invoke(IBlock block);
        IList<string> Logs { get; }
        void VerifyState();
    }
}
