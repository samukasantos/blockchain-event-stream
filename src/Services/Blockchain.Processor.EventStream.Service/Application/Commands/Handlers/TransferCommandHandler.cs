
using Blockchain.Processor.Core.Messages;
using Blockchain.Processor.Domain.Repositories;
using Blockchain.Processor.EventStream.Service.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;
using Blockchain.Processor.EventStream.Service.Application.Models;

namespace Blockchain.Processor.EventStream.Service.Application.Commands.Handlers
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, int>
    {
        #region Fields

        private readonly IWalletRepository walletRepository;
        private readonly ITransactionTracker transactionTracker;
        private readonly ILogger<TransferCommandHandler> logger;

        #endregion

        #region Constructor

        public TransferCommandHandler(IWalletRepository walletRepository,
            ITransactionTracker transactionTracker,
            ILogger<TransferCommandHandler> logger)
        {
            this.walletRepository = walletRepository;
            this.transactionTracker = transactionTracker;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public async Task<int> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                var result = walletRepository.Transfer(request.TokenId, request.From, request.To);

                if (result > 0) 
                {
                    transactionTracker.AddTransaction(result);
                    return await Task.FromResult(result);
                }

                throw new Exception("Failed to execute Transfer transaction.");
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
