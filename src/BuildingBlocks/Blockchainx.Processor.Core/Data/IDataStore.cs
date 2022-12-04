
using System;
using System.Threading.Tasks;

namespace Blockchain.Processor.Core.Data
{
    public interface IDataStore : IDisposable
    {
        int CreateDataStorage();
        int ResetDataStorage();
    }
}
