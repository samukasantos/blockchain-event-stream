
using Blockchain.Processor.Domain.Entities;
using Blockchain.Processor.EventStream.Service.Application.Dto.Response;

namespace Blockchain.Processor.EventStream.Service.Adapters
{
    public static class WalletAdapter
    {
        #region Methods
        
        public static NftOwnershipResponse ToNftResponse(this Wallet wallet)
        {
            return new NftOwnershipResponse
            {
                TokenId = wallet.TokenId,
                Address = wallet.Address,
            };
        }

        public static WalletResponse ToWalletResponse(this Wallet wallet)
        {
            return new WalletResponse
            {
                Address = wallet.Address,
            };
        } 
        
        #endregion
    }
}
