using Wasp.Setup;

namespace Wasp.Interfaces
{
    public interface IHasSession
    {
        Session Session { get; }
    }
}
