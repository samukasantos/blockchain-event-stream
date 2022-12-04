
using Blockchain.Processor.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Threading;
using Blockchain.Processor.EventStream.Service.Application.Events;
using Blockchain.Processor.EventStream.Service.Application.Models;
using Blockchain.Processor.Core.Mediator;

namespace Blockchain.Processor.EventStream.Service.Commands.Handlers
{
    public class ResetCommandHandler : IRequestHandler<ResetCommand, int>
    {
        #region Fields

        private readonly IWalletRepository walletRepository;
        private readonly IMediatorHandler handler;
        private readonly ILogger<ResetCommandHandler> logger;

        #endregion


        #region Constructor

        public ResetCommandHandler(IWalletRepository walletRepository,
            IMediatorHandler handler,
            ILogger<ResetCommandHandler> logger)
        {
            this.walletRepository = walletRepository;
            this.handler = handler;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public async Task<int> Handle(ResetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                walletRepository.DataContext.ResetDataStorage();

                handler.PublishEvents(new ResetExecutedEvent());

                return await Task.FromResult(1);
                
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
