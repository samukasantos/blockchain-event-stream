using Blockchain.Processor.Core.Mediator;
using Blockchain.Processor.Core.Messages;
using Blockchain.Processor.EventStream.Service.Adapters;
using Blockchain.Processor.EventStream.Service.Application.Dto.Request;
using Blockchain.Processor.EventStream.Service.Application.Events;
using Blockchain.Processor.EventStream.Service.Application.Models;
using Blockchain.Processor.EventStream.Service.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blockchain.Processor.EventStream.Service.Application.Services
{
    public class WalletApplicationService : IWalletApplicationService
    {
        #region Fields

        private readonly IMediatorHandler handler;
        private readonly ITransactionTracker transactionTracker;
        private List<ICommand> commands = new();

        #endregion

        #region Constructor

        public WalletApplicationService(IMediatorHandler handler, ITransactionTracker transactionTracker)
        {
            this.handler = handler;
            this.transactionTracker = transactionTracker;
        }

        #endregion

        #region Methods

        public IWalletApplicationService ProcessCommand(CommandRequest request)
        {
            if (!string.IsNullOrEmpty(request.ReadInline))
            {
                commands = CommandAdapter.ConvertJsonToCommands(request.ReadInline);
                return this;
            }

            if (!string.IsNullOrEmpty(request.ReadFile))
            {
                commands = CommandAdapter.ConvertFileToCommands(request.ReadFile);
                return this;
            }

            if (!string.IsNullOrEmpty(request.NFT))
            {
                commands.Add(CommandAdapter.CreateNftOwnershipCommand(request.NFT));
                return this;
            }

            if (!string.IsNullOrEmpty(request.Wallet))
            {
                commands.Add(CommandAdapter.CreateWalletCommand(request.Wallet));
                return this;
            }

            if (request.Reset)
            {
                commands.Add(CommandAdapter.CreateResetCommand());
                return this;
            }

            return this;
        }

        public int Dispatch()
        {
            if (commands.Any()) 
            {
                foreach (var command in commands)
                {
                    handler.SendCommand(command);
                }
            }

            CheckTransactions();

            return 0;
        }

        private void CheckTransactions() 
        {
            if (transactionTracker != null)
            {
                if (transactionTracker.NumberOfTransactions > 0) 
                {
                    handler.PublishEvents(new TransactionExecutedEvent(transactionTracker.NumberOfTransactions));
                    transactionTracker.Clear();
                }
            }
        }

        #endregion
    }
}
