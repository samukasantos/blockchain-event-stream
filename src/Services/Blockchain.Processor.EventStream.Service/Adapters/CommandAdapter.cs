
using Blockchain.Processor.Core.Enumerators;
using Blockchain.Processor.EventStream.Service.Application.Dto.Request;
using Blockchain.Processor.EventStream.Service.Commands;
using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using Blockchain.Processor.Core.Messages;

namespace Blockchain.Processor.EventStream.Service.Adapters
{
    public class CommandAdapter
    {
        #region Methods

        public static List<ICommand> ConvertFileToCommands(string filePath)
        {
            var commands = new List<ICommand>();
            try
            {
                if (File.Exists(filePath))
                {
                    using var file = File.OpenText(@$"{filePath}");

                    var serializer = new JsonSerializer();

                    if (serializer.Deserialize(file, typeof(List<ActionRequest>)) is List<ActionRequest> actions)
                    {
                        commands = ConvertActionsToCommands(actions);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return commands;
        }

        public static List<ICommand> ConvertJsonToCommands(string json) 
        {
            var commands = new List<ICommand>();
            try
            {
                var actions = JsonConvert.DeserializeObject<List<ActionRequest>>(json);

                if(actions != null) 
                {
                    commands = ConvertActionsToCommands(actions);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return commands;
        }

        public static ICommand CreateNftOwnershipCommand(string nft) 
        {
            return new NftOwnershipCommand(nft);
        }

        public static ICommand CreateWalletCommand(string address)
        {
            return new WalletCommand(address);
        }

        public static ICommand CreateResetCommand()
        {
            return new ResetCommand();
        }

        private static List<ICommand> ConvertActionsToCommands(List<ActionRequest> actions) 
        {
            var commands = new List<ICommand>();

            foreach (var action in actions)
            {
                switch (action.Type)
                {
                    case CommandType.Mint:
                        commands.Add(new MintCommand(action.TokenId, action.Address));
                        break;
                    case CommandType.Burn:
                        commands.Add(new BurnCommand(action.TokenId));
                        break;
                    case CommandType.Transfer:
                        commands.Add(new TransferCommand(action.TokenId, action.From, action.To));
                        break;
                    default:
                        break;
                }
            }

            return commands;
        }
        
        #endregion
    }
}
