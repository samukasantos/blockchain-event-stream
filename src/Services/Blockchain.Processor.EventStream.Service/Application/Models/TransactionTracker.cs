
using System.Xml.Schema;

namespace Blockchain.Processor.EventStream.Service.Application.Models
{
    public interface ITransactionTracker
    {
        int NumberOfTransactions { get; }
        void AddTransaction(int transaction);
        void Clear();
        
    }

    public class TransactionTracker : ITransactionTracker
    {
        #region Properties

        public int NumberOfTransactions { get; private set; }

        #endregion

        #region Methods

        public void AddTransaction(int transaction) 
        {
            if(transaction > 0) 
            {
                NumberOfTransactions += transaction;
            }
        }

        public void Clear() 
        {
            NumberOfTransactions = 0;
        }

        #endregion
    }
}
