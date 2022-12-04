
using Blockchain.Processor.Core.DomainObjects;
using System;

namespace Blockchain.Processor.Domain.Entities
{
    public class Wallet : Entity, IAggregateRoot
    {

        #region Properties

        public string TokenId { get; private set; }
        public string Address { get; private set; }

        #endregion

        #region Constructor

        public Wallet(string tokenId, string address)
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
