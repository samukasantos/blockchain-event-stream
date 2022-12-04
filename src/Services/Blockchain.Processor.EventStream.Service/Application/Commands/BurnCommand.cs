
using Blockchain.Processor.Core.Enumerators;
using Blockchain.Processor.Core.Messages;
using System;

namespace Blockchain.Processor.EventStream.Service.Commands
{
    public class BurnCommand : Command, ICommand
    {
        #region Properties
        
        public string TokenId { get; private set; }
        public CommandType CommandType => CommandType.Burn;

        #endregion


        #region Constructor

        public BurnCommand(string tokenId)
        {
            TokenId = tokenId;
        }

        #endregion

        #region Methods

        public override void Validate()
        {
            if (string.IsNullOrEmpty(TokenId))
            {
                throw new Exception("TokenId is required.");
            }
        }

        #endregion

    }
}
