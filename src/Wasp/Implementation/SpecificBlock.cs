using OpenQA.Selenium;

using Wasp.Interfaces;
using Wasp.Setup;

namespace Wasp.Implementation
{
    public abstract class SpecificBlock : Block, ISpecificBlock
    {
        protected SpecificBlock(Session session, IWebElement tag) : base(session)
        {
            this.Tag = tag;
        }
    }
}
