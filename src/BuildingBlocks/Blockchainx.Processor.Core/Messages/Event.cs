using MediatR;
using System;

namespace Blockchain.Processor.Core.Messages
{
    public class Event : INotification
    {
        #region Methods

        public string Id { get; private set; }
        public DateTime Timestamp { get; }
        public string EventType { get; }
        public string Message { get; set; }

        #endregion

        #region  Construtor

        public Event()
        {
            Id = Guid.NewGuid().ToString();
            EventType = GetType().Name;
            Timestamp = DateTime.Now;
        }

        #endregion
    }
}
