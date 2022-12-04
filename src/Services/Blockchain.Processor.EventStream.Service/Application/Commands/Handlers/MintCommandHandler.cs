using Blockchain.Processor.Domain.Entities;
using Blockchain.Processor.Domain.Repositories;
using Blockchain.Processor.EventStream.Service.Application.Models;
using Blockchain.Processor.EventStream.Service.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blockchain.Processor.EventStream.Service.Application.Commands.Handlers
{
    public class MintCommandHandler : IRequestHandler<MintCommand, int>
    {
        #region Fields

        private readonly IWalletRepository walletRepository;
        private readonly ITransactionTracker transactionTracker;
        private readonly ILogger<MintCommandHandler> logger;

        #endregion

        #region Constructor

        public MintCommandHandler(IWalletRepository walletRepository, 
            ITransactionTracker transactionTracker, 
            ILogger<MintCommandHandler> logger)
        {
            this.walletRepository = walletRepository;
            this.transactionTracker = transactionTracker;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public async Task<int> Handle(MintCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                var result = walletRepository.Add(new Wallet(request.TokenId, request.Address));

                if (result > 0) 
                {
                    transactionTracker.AddTransaction(result);
                    return await Task.FromResult(result);
                }

                throw new Exception("Failed to execute Mint transaction.");
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
