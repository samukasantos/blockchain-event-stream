
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Processor.EventStream.Service.Application.Events.Handlers
{
    public class TransactionExecutedEventHandler : INotificationHandler<TransactionExecutedEvent>
    {
        #region Methods
        
        public Task Handle(TransactionExecutedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Read {notification.NumberOfTransactions} transaction(s).");

            return Task.CompletedTask;
        } 
        
        #endregion
    }
}
