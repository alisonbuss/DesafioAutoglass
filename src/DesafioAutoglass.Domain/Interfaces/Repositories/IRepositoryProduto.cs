
using DesafioAutoglass.Domain.Entities;

namespace DesafioAutoglass.Domain.Interfaces.Repositories
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        // Reading(Consultation):
        Task<Produto> GetByCodigo(string codigo);

        Task<Produto> GetByDescricao(string Descricao);
    }
}
