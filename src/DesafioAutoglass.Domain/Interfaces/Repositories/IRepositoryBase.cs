
namespace DesafioAutoglass.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        // Reading(Consultation):
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);

        // Writing(Persistence):
        Task<TEntity> Add(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task Remove(TEntity obj);

    }
}
