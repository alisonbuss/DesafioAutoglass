
namespace DesafioAutoglass.Domain.Entities
{
    public class EntityBase : IEntity
    {
        public EntityBase(Guid id)
        {
            Id = id;
        }

        protected EntityBase() { }

        public Guid Id { get; set; }

    }
}
