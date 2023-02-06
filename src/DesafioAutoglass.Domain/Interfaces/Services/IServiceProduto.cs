using DesafioAutoglass.Domain.Entities;

namespace DesafioAutoglass.Domain.Interfaces.Services
{
    public interface IServiceProduto
    {
        // Reading(Consultation):
        Task<IEnumerable<Produto>> GetAllProdutos();
        Task<Produto> GetProdutoById(Guid id);
        Task<Produto> GetProdutoByCodigo(string codigo);
        Task<Produto> GetProdutoByDescricao(string Descricao);

        // Writing(Persistence):
        Task<Produto> CreateProduto(Produto Produto);
        Task<Produto> UpdateProduto(Produto Produto);
        Task DeleteProduto(Produto Produto);
    }
}
