using Blockchain.Processor.EventStream.Service.Application.Dto.Request;
using Blockchain.Processor.EventStream.Service.Application.Services.Interfaces;
using Blockchain.Processor.EventStream.Service.Configuration;
using Blockchain.Processor.EventStream.Service.Data.Context;
using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace Blockchain.Processor.EventStream.Service
{
    public class Program
    {
        #region Methods

        static int Main(string[] args)
        {
            var serviceProvider = ConfigureServiceProvider();
            
            InitializeDatabase(serviceProvider);

            var result = Parser.Default.ParseArguments<CommandRequest>(args)
                    .MapResult((CommandRequest command) =>
                    {
                        var service = serviceProvider.GetService<IWalletApplicationService>();
                        return service.ProcessCommand(command).Dispatch();
                    },
                    errs => 1);

            return result;
        }

        static void InitializeDatabase(ServiceProvider provider)
        {
            var context = provider.GetService<NftEDataContext>();
            context.CreateDataStorage();
        }

        static ServiceProvider ConfigureServiceProvider() 
        {
            var services = new ServiceCollection();
            
            services.AddMediatR(typeof(Program));

            return services.AddServices().BuildServiceProvider();
        }

        #endregion
    }
}
