
using Microsoft.EntityFrameworkCore;

using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Domain.Interfaces.Repositories;

using DesafioAutoglass.Infra.Data.Context;

namespace DesafioAutoglass.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContextBase dbContext;
        protected readonly DbSet<TEntity> dbSet;

        public RepositoryBase(DbContextBase dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        // Reading(Consultation):

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var list = await this.dbSet.AsNoTracking()
                                       .ToListAsync()
                                       .ConfigureAwait(false);
            return list;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var entity = await this.dbSet.AsNoTracking()
                                         .FirstOrDefaultAsync(entity => entity.Id == id)
                                         .ConfigureAwait(false);
            return entity!;
        }

        // Writing(Persistence):

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await this.dbSet.AddAsync(entity).ConfigureAwait(false);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var currentEntity = await GetById(entity.Id);
            if (currentEntity == null)
                throw new System.ArgumentNullException(nameof(currentEntity));

            this.dbContext.Entry(currentEntity).CurrentValues.SetValues(entity);

            this.dbSet.Update(currentEntity);

            await dbContext.SaveChangesAsync();

            return await Task.FromResult<TEntity>(currentEntity).ConfigureAwait(false);
        }

        public virtual async Task Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var currentEntity = await GetById(entity.Id);
            if (currentEntity == null)
                throw new System.ArgumentNullException(nameof(currentEntity));

            this.dbSet.Remove(currentEntity);

            await dbContext.SaveChangesAsync();

            await Task.CompletedTask.ConfigureAwait(false);
        }

        public virtual void Dispose()
        {
            dbContext.Dispose();
        }

    }
}
