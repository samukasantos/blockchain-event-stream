using Blockchain.Processor.Core.Enumerators;

namespace Blockchain.Processor.Core.Messages
{
    public interface ICommand
    {
        CommandType CommandType { get; }
        void Validate();
    }
}
