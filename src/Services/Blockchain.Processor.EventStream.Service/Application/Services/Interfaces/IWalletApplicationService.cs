
using Blockchain.Processor.Core.Mediator;
using Blockchain.Processor.EventStream.Service.Application.Dto.Request;

namespace Blockchain.Processor.EventStream.Service.Application.Services.Interfaces
{
    public interface IWalletApplicationService
    {
        IWalletApplicationService ProcessCommand(CommandRequest request);
        int Dispatch();
    }
}
