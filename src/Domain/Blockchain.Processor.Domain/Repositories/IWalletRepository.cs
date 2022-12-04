
using Blockchain.Processor.Core.Data;
using Blockchain.Processor.Domain.Entities;
using System.Collections.Generic;

namespace Blockchain.Processor.Domain.Repositories
{
    public interface IWalletRepository : IRepository<Wallet>
    {
        int Add(Wallet wallet);
        int Delete(string tokenId);
        Wallet SelectByTokenId(string tokenId);
        List<Wallet> Select(string address);
        int Transfer(string tokenId, string addressFrom, string addressTo);
    }
}
