
using Blockchain.Processor.Core.Messages;
using System.Collections.Generic;

namespace Blockchain.Processor.EventStream.Service.Application.Events
{
    public class WalletExecutedEvent : Event
    {
        #region Properties

        public string Address { get; private set; }
        public List<string> Tokens { get; private set; }

        #endregion

        #region Constructor

        public WalletExecutedEvent(string address, List<string> tokens)
        {
            Address = address;
            Tokens = tokens ?? new List<string>();
        }

        #endregion
    }
}
