
using Blockchain.Processor.Core.Data;
using Blockchain.Processor.Domain.Entities;
using Blockchain.Processor.Domain.Repositories;
using Blockchain.Processor.EventStream.Service.Data.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Blockchain.Processor.EventStream.Service.Data.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        #region Fields

        private readonly ILogger<WalletRepository> logger;

        #endregion

        #region Properties

        public IDataStore DataContext { get; private set; }

        #endregion

        #region Constructor

        public WalletRepository(NftEDataContext context, ILogger<WalletRepository> logger)
        {
            DataContext = context;
            this.logger = logger;
        }

        #endregion

        #region Methods

        public int Add(Wallet wallet)
        {
            try
            {
                var context = DataContext as NftEDataContext;
                var command = context.CreateCommand();

                command.CommandText = @"INSERT INTO Wallet 
                                            (Id, TokenId, Address, CreatedAt, CreatedBy)
                                        VALUES
                                            (@Id, @TokenId, @Address, @CreatedAt, @CreatedBy)";

                command.Parameters.AddWithValue("Id", wallet.Id);
                command.Parameters.AddWithValue("TokenId", wallet.TokenId);
                command.Parameters.AddWithValue("Address", wallet.Address);
                command.Parameters.AddWithValue("CreatedAt", wallet.CreatedAt);
                command.Parameters.AddWithValue("CreatedBy", wallet.CreatedBy);

                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }

        public int Delete(string tokenId)
        {
            try
            {
                var context = DataContext as NftEDataContext;
                var command = context.CreateCommand();

                command.CommandText = @"DELETE FROM Wallet WHERE TokenId = @TokenId";
                command.Parameters.AddWithValue("TokenId", tokenId);

                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }

        public int Transfer(string tokenId, string addressFrom, string addressTo)
        {
            try
            {
                var context = DataContext as NftEDataContext;
                var command = context.CreateCommand();

                var walletOrigin = SelectByTokenId(tokenId);

                if(walletOrigin != null) 
                {
                    if (walletOrigin.Address == addressFrom) 
                    {
                        var result = Add(new Wallet(tokenId, addressTo));

                        if(result > 0) 
                        {
                            command.CommandText = @"DELETE FROM Wallet WHERE Address = @Address AND TokenId = @TokenId";
                            command.Parameters.AddWithValue("TokenId", tokenId);
                            command.Parameters.AddWithValue("Address", addressFrom);
                            return command.ExecuteNonQuery();
                        }
                    }
                }

                return 0;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }

        public Wallet SelectByTokenId(string tokenId)
        {
            Wallet wallet = null;
            try
            {
                var context = DataContext as NftEDataContext;
                var command = context.CreateCommand();

                command.CommandText = @"SELECT TokenId, Address FROM Wallet WHERE TokenId = @TokenId";
                command.Parameters.AddWithValue("TokenId", tokenId);

                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    wallet = new Wallet(reader.GetString(0), reader.GetString(1));
                }

                return wallet;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }

        public List<Wallet> Select(string address)
        {
            var wallets = new List<Wallet>();
            try
            {
                var context = DataContext as NftEDataContext;
                var command = context.CreateCommand();

                command.CommandText = @"SELECT TokenId, Address FROM Wallet WHERE Address = @Address";
                command.Parameters.AddWithValue("Address", address);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    wallets.Add(new Wallet(reader.GetString(0), reader.GetString(1)));
                }

                return wallets;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }

        #endregion
    }
}
