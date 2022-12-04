
using Blockchain.Processor.Core.Messages;

namespace Blockchain.Processor.EventStream.Service.Application.Events
{
    public class NftExecutedEvent : Event
    {
        #region Properties

        public string TokenId { get; private set; }
        public string Address { get; private set; }

        #endregion

        #region Constructor

        public NftExecutedEvent(string tokenId, string address)
        {
            TokenId = tokenId;
            Address = address;
        }

        #endregion
    }
}
