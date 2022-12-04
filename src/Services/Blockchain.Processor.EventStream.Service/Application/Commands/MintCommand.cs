
using Blockchain.Processor.Core.Enumerators;
using Blockchain.Processor.Core.Messages;
using System;

namespace Blockchain.Processor.EventStream.Service.Commands
{
    public class MintCommand : Command, ICommand
    {
        #region Properties

        public string TokenId { get; private set; }
        public string Address { get; private set; }
        public CommandType CommandType => CommandType.Mint;

        #endregion

        #region Constructor

        public MintCommand(string tokenId, string address)
        {
            TokenId = tokenId;
            Address = address;
        }

        #endregion

        #region Methods

        public override void Validate()
        {
            if (string.IsNullOrEmpty(TokenId))
            {
                throw new Exception("TokenId is required.");
            }

            if (string.IsNullOrEmpty(Address))
            {
                throw new Exception("Address is required.");
            }
        }

        #endregion

    }
}
