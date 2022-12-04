
using Blockchain.Processor.Core.Data;
using Blockchain.Processor.EventStream.Service.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SQLite;

namespace Blockchain.Processor.EventStream.Service.Data.Context
{
    public class NftEDataContext : IDataStore, IDisposable
    {

        #region Fields

        private readonly ILogger<NftEDataContext> logger;

        #endregion

        #region Properties

        public SQLiteConnection Connection => CreateConnection();

        #endregion

        #region Constructor

        public NftEDataContext(ILogger<NftEDataContext> logger)
        {
            this.logger = logger;
        }

        #endregion

        #region Methods

        private SQLiteConnection CreateConnection() 
        {
            SQLiteConnection connection;

            try
            {
                connection = new SQLiteConnection(EventStreamConstants.EventStoreConnectionString);

                connection.Open();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }

            return connection;
        }

        public int CreateDataStorage() 
        {
            try
            {
                var command = CreateCommand();
                command.CommandText = 
                    @"CREATE TABLE IF NOT EXISTS Wallet (
                        Id CHAR(36) NOT NULL,
                        TokenId VARCHAR(256) NOT NULL,
                        Address VARCHAR(256) NOT NULL,
                        CreatedAt DATETIME(6) NOT NULL, 
                        CreatedBy VARCHAR(120) NOT NULL,
                        PRIMARY KEY (Id)
                    );";

                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }

        public int ResetDataStorage()
        {
            try
            {
                var command = CreateCommand();
                command.CommandText = @"DELETE FROM Wallet;";
                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message, e);
                throw;
            }
        }

        public SQLiteCommand CreateCommand() 
        {
            var connection = CreateConnection();
            return connection.CreateCommand();
        }

        public void Dispose()
        {
            Connection.Dispose();
        }


        #endregion
    }
}
