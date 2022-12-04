
using Blockchain.Processor.Core.Messages;
using Blockchain.Processor.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;
using Blockchain.Processor.Core.Mediator;
using Blockchain.Processor.EventStream.Service.Application.Events;
using Blockchain.Processor.EventStream.Service.Application.Models;

namespace Blockchain.Processor.EventStream.Service.Commands.Handlers
{
    public class NftOwnershipCommandHandler : IRequestHandler<NftOwnershipCommand, int>
    {
        #region Fields

        private readonly IWalletRepository walletRepository;
        private readonly ILogger<NftOwnershipCommandHandler> logger;
        private readonly IMediatorHandler handler;

        #endregion

        #region Constructor

        public NftOwnershipCommandHandler(IWalletRepository walletRepository, 
            IMediatorHandler handler, 
            ILogger<NftOwnershipCommandHandler> logger)
        {
            this.walletRepository = walletRepository;
            this.handler = handler;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public async Task<int> Handle(NftOwnershipCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                var nft = walletRepository.SelectByTokenId(request.TokenId);

                if(nft == null) 
                {
                    handler.PublishEvents(new NftExecutedEvent(request.TokenId, ""));
                }
                else 
                {
                    handler.PublishEvents(new NftExecutedEvent(nft.TokenId, nft.Address));
                }
            }
            catch(Exception e)
            {
                logger.LogError(e.Message, e);

                throw;
            }

            return await Task.FromResult(0);
        }

        #endregion
    }
}
