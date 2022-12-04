

using System;

namespace Blockchain.Processor.Core.DomainObjects
{
    public abstract class Entity
    {
        #region Properties

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string CreatedBy { get; private set; }


        #endregion

        #region Constructor

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            CreatedBy = "Internal Api";
        }

        #endregion

        #region Methods

        public abstract void Validate();

        #endregion

    }
}
