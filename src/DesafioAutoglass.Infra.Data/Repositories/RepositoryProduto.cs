
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Domain.Interfaces.Repositories;

using DesafioAutoglass.Infra.Data.Context;

namespace DesafioAutoglass.Infra.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        public RepositoryProduto(DbContextBase dbContext) : base(dbContext)
        {

        }

        // Customizations:

        // Reading(Consultation):

        public async Task<Produto> GetByCodigo(string codigo)
        {
            var produto = await this.dbSet.AsNoTracking()
                                          .FirstOrDefaultAsync(entity => entity.Codigo == codigo)
                                          .ConfigureAwait(false);
            return produto!;
        }

        public async Task<Produto> GetByDescricao(string descricao)
        {
            var produto = await this.dbSet.AsNoTracking()
                                          .FirstOrDefaultAsync(entity => entity.Descricao == descricao)
                                          .ConfigureAwait(false);
            return produto!;
        }

        // Writing(Persistence):

        // Override:
        public override async Task Remove(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            // const string deleteSQL = @"
            //     DELETE FROM [domain].[Produtos] WHERE [Id] = @Id;
            // ";
            const string updateStatusSQL = @"
                UPDATE [domain].[Produtos] SET [Situacao] = 0 WHERE [Id] = @Id;
            ";

            var id = new SqlParameter("@Id", produto.Id);

            await this.dbContext.Database.ExecuteSqlRawAsync(updateStatusSQL, id).ConfigureAwait(false);
        }

    }
}
