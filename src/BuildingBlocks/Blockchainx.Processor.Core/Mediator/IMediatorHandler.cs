
using Blockchain.Processor.Core.Messages;

namespace Blockchain.Processor.Core.Mediator
{
    public interface IMediatorHandler
    {
        void PublishEvents<T>(T @event) where T : Event;
        void SendCommand<T>(T command) where T : ICommand;
    }
}
