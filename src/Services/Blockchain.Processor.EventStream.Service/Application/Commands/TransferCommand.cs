
using Blockchain.Processor.Core.Enumerators;
using Blockchain.Processor.Core.Messages;
using System;

namespace Blockchain.Processor.EventStream.Service.Commands
{
    public class TransferCommand : Command, ICommand
    {
        #region Properties

        public string TokenId { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public CommandType CommandType => CommandType.Transfer;

        #endregion

        #region Constructor

        public TransferCommand(string tokenId, string from, string to)
        {
            TokenId = tokenId;
            From = from;
            To = to;
        }

        #endregion

        #region Methods

        public override void Validate()
        {
            if (string.IsNullOrEmpty(TokenId))
            {
                throw new Exception("TokenId is required.");
            }

            if (string.IsNullOrEmpty(From))
            {
                throw new Exception("Origin is required.");
            }

            if (string.IsNullOrEmpty(To))
            {
                throw new Exception("Destination is required.");
            }
        }

        #endregion
    }
}
