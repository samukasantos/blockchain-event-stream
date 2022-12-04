
using Blockchain.Processor.Core.Messages;

namespace Blockchain.Processor.EventStream.Service.Application.Events
{
    public class TransactionExecutedEvent : Event
    {
        #region Properties

        public int NumberOfTransactions { get; private set; }

        #endregion

        #region Constructor

        public TransactionExecutedEvent(int numberOfTransacations)
        {
            NumberOfTransactions = numberOfTransacations;
        }

        #endregion
    }
}
