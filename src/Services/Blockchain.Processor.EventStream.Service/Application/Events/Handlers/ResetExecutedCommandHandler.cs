
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Processor.EventStream.Service.Application.Events.Handlers
{
    public class ResetExecutedCommandHandler : INotificationHandler<ResetExecutedEvent>
    {
        #region Methods
        
        public Task Handle(ResetExecutedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Program was reset.");

            return Task.CompletedTask;
        } 
        
        #endregion
    }
}
