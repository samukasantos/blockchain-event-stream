
using Blockchain.Processor.Core.Mediator;
using Blockchain.Processor.Domain.Repositories;
using Blockchain.Processor.EventStream.Service.Application.Commands.Handlers;
using Blockchain.Processor.EventStream.Service.Application.Events;
using Blockchain.Processor.EventStream.Service.Application.Events.Handlers;
using Blockchain.Processor.EventStream.Service.Application.Models;
using Blockchain.Processor.EventStream.Service.Application.Services;
using Blockchain.Processor.EventStream.Service.Application.Services.Interfaces;
using Blockchain.Processor.EventStream.Service.Commands;
using Blockchain.Processor.EventStream.Service.Commands.Handlers;
using Blockchain.Processor.EventStream.Service.Data.Context;
using Blockchain.Processor.EventStream.Service.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blockchain.Processor.EventStream.Service.Configuration
{
    public static class DependencyServiceExtensions
    {
        #region Methods

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //MediatR
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // DataContext
            services.AddScoped<NftEDataContext>();

            //Repository
            services.AddScoped<IWalletRepository, WalletRepository>();

            //Services
            services.AddScoped<IWalletApplicationService, WalletApplicationService>();

            //Tracker
            services.AddSingleton<ITransactionTracker, TransactionTracker>();

            //Command.Handlers
            services.AddScoped<IRequestHandler<MintCommand, int>, MintCommandHandler>();
            services.AddScoped<IRequestHandler<BurnCommand, int>, BurnCommandHandler>();
            services.AddScoped<IRequestHandler<TransferCommand, int>, TransferCommandHandler>();
            services.AddScoped<IRequestHandler<ResetCommand, int>, ResetCommandHandler>();
            services.AddScoped<IRequestHandler<NftOwnershipCommand, int>, NftOwnershipCommandHandler>();
            services.AddScoped<IRequestHandler<WalletCommand, int>, WalletCommandHandler>();

            //Logging
            services.AddLogging(configure => configure.AddConsole());

            return services;
        } 

        #endregion
    }
}
