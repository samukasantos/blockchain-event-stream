
namespace Blockchain.Processor.Core.Messages
{
    public interface ICommandHandler
    {
        int Handle(ICommand command);
    }
}
