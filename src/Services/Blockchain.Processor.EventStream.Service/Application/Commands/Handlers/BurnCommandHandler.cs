
using Blockchain.Processor.Core.Messages;
using Blockchain.Processor.Domain.Entities;
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
    public class BurnCommandHandler : IRequestHandler<BurnCommand, int>
    {
        #region Fields

        private readonly IWalletRepository walletRepository;
        private readonly ITransactionTracker transactionTracker;
        private readonly ILogger<BurnCommandHandler> logger;

        #endregion

        #region Constructor

        public BurnCommandHandler(IWalletRepository walletRepository,
            ITransactionTracker transactionTracker,
            ILogger<BurnCommandHandler> logger)
        {
            this.walletRepository = walletRepository;
            this.transactionTracker = transactionTracker;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public async Task<int> Handle(BurnCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                var result = walletRepository.Delete(request.TokenId);

                if(result > 0) 
                {
                    transactionTracker.AddTransaction(result);
                    return await Task.FromResult(result);
                }

                throw new Exception("Failed to execute Burn transaction.");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);

                throw;
            }
        }
    }

    #endregion
}
