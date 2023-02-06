
using DesafioAutoglass.Application.Dtos;

namespace DesafioAutoglass.Application.Interfaces
{
    public interface IAppServiceProduto : IDisposable
    {
        // Reading(Consultation):
        Task<IEnumerable<DtoProduto>> GetAllProdutos();
        Task<DtoProduto> GetProdutoById(Guid id);
        Task<DtoProduto> GetProdutoByCodigo(string codigo);
        Task<DtoProduto> GetProdutoByDescricao(string descricao);

        // Writing(Persistence):
        Task<DtoProduto> CreateProduto(DtoProduto dtoProduto);
        Task<DtoProduto> UpdateProduto(DtoProduto dtoProduto);
        Task DeleteProduto(DtoProduto dtoProduto);
    }
}
