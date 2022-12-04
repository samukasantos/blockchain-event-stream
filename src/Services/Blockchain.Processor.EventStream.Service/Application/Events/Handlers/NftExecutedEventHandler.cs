
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Processor.EventStream.Service.Application.Events.Handlers
{
    public class NftExecutedEventHandler : INotificationHandler<NftExecutedEvent>
    {
        #region Methods
        
        public Task Handle(NftExecutedEvent notification, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(notification.Address))
            {
                Console.WriteLine($"Token {notification.TokenId} is not owned by any wallet.");
            }
            else
            {
                Console.WriteLine($"Token {notification.TokenId} is owned by {notification.Address}.");
            }
            return Task.CompletedTask;
        } 

        #endregion
    }
}
