
using Blockchain.Processor.Core.Messages;
using MediatR;

namespace Blockchain.Processor.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        #region Fields

        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Methods
        public void PublishEvents<T>(T @event) where T : Event
        {
            mediator.Publish(@event).ConfigureAwait(false);
        }

        public void SendCommand<T>(T command) where T : ICommand
        {
            mediator.Send(command).ConfigureAwait(false);
        }

        #endregion
    }
}
