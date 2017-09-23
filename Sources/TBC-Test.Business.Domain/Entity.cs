using System;
using AGrynCo.Lib;

namespace TBC_Test.Business.Domain
{
    public class Entity<TId> : BaseClass, IEntity<TId>
    {
        protected Entity()
        {
            Created = DateTime.UtcNow;
        }

        public DateTime? Created { get; set; }
        public DateTime? Deleted { get; set; }

        object IEntity.Id
        {
            get { return Id; }
            set { Id = (TId) value; }
        }

        public TId Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Updated { get; set; }
    }

    public class IdentityEntity : Entity<int>
    {
    }
}