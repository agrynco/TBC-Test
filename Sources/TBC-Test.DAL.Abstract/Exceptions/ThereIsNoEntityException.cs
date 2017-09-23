using TBC_Test.Business.Domain;

namespace TBC_Test.DAL.Abstract.Exceptions
{
    public class ThereIsNoEntityException<TEntity, TId> : DalException
        where TEntity : IEntity
    {
        public ThereIsNoEntityException(TId id)
            : base($"There is no entity {typeof(TEntity)} with {nameof(IEntity.Id)} = {id}")
        {
            Id = id;
        }

        public TId Id { get; set; }
    }
}