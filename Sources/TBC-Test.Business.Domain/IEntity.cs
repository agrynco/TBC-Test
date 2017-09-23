using System;

namespace TBC_Test.Business.Domain
{
    public interface IEntity
    {
        DateTime? Created { get; set; }
        DateTime? Deleted { get; set; }
        object Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime? Updated { get; set; }
    }

    public interface IEntity<TId> : IEntity
    {
        new TId Id { get; set; }
    }
}