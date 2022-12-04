
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Processor.EventStream.Service.Application.Events.Handlers
{
    public class WalletExecutedEventHandler : INotificationHandler<WalletExecutedEvent>
    {
        #region Methods

        public Task Handle(WalletExecutedEvent notification, CancellationToken cancellationToken)
        {
            if (!notification.Tokens.Any()) 
            {
                Console.WriteLine($"Wallet {notification.Address} hold no Tokens.");
            }
            else 
            {
                Console.WriteLine($"Wallet {notification.Address} hold {notification.Tokens.Count()} Token(s):");
                foreach (var token in notification.Tokens)
                {
                    Console.WriteLine($"{token}");
                }
            }

            return Task.CompletedTask;
        } 

        #endregion
    }
}
