

using MediatR;

namespace Blockchain.Processor.Core.Messages
{
    public abstract class Command : IRequest<int>
    {
        #region Properties

        public abstract void Validate();

        #endregion
    }
}
