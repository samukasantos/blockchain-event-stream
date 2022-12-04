using Blockchain.Processor.Core.Enumerators;
using Blockchain.Processor.Core.Messages;
using System;

namespace Blockchain.Processor.EventStream.Service.Commands
{
    public class WalletCommand : Command, ICommand
    {
        #region Properties

        public string Address { get; private set; }
        public CommandType CommandType => CommandType.None;

        #endregion

        #region Constructor

        public WalletCommand(string address)
        {
            this.Address = address;
        }

        #endregion

        #region Methods

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Address))
            {
                throw new Exception("Address is required.");
            }
        } 

        #endregion
    }
}
