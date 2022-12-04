using Blockchain.Processor.Core.Mediator;
using Blockchain.Processor.Domain.Repositories;
using Blockchain.Processor.EventStream.Service.Application.Events;
using Blockchain.Processor.EventStream.Service.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Processor.EventStream.Service.Application.Commands.Handlers
{
    public class WalletCommandHandler : IRequestHandler<WalletCommand, int>
    {
        #region Fields

        private readonly IWalletRepository walletRepository;
        private readonly IMediatorHandler handler;
        private readonly ILogger<WalletCommandHandler> logger;

        #endregion

        #region Constructor

        public WalletCommandHandler(IWalletRepository walletRepository,
            IMediatorHandler handler,
            ILogger<WalletCommandHandler> logger)
        {
            this.walletRepository = walletRepository;
            this.handler = handler;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public async Task<int> Handle(WalletCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                var wallets = walletRepository.Select(request.Address);

                if (!wallets.Any())
                {
                    handler.PublishEvents(new WalletExecutedEvent(request.Address, null));
                }
                else 
                {
                    handler.PublishEvents(new WalletExecutedEvent(request.Address, wallets.Select(c => c.TokenId).ToList()));
                }

                return await Task.FromResult(0);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);

                throw;
            }
        }

        #endregion
    }
}
