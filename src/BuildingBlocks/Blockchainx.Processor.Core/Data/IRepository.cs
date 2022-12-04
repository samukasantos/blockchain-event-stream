
using Blockchain.Processor.Core.DomainObjects;
using System;

namespace Blockchain.Processor.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IDataStore DataContext { get; }
    }
}
