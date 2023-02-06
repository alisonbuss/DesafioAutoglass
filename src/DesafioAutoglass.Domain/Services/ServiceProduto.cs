
using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Domain.Interfaces.Services;
using DesafioAutoglass.Domain.Interfaces.Repositories;

namespace DesafioAutoglass.Domain.Services
{
    public class ServiceProduto : IServiceProduto
    {
        private readonly IRepositoryProduto repositoryProduto;

        public ServiceProduto(IRepositoryProduto repositoryProduto)
        {
            this.repositoryProduto = repositoryProduto;
        }

        // Reading(Consultation):
        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            return await this.repositoryProduto.GetAll();
        }

        public async Task<Produto> GetProdutoById(Guid id)
        {
            return await this.repositoryProduto.GetById(id);
        }

        public async Task<Produto> GetProdutoByCodigo(string codigo)
        {
            return await this.repositoryProduto.GetByCodigo(codigo);
        }

        public async Task<Produto> GetProdutoByDescricao(string descricao)
        {
            return await this.repositoryProduto.GetByDescricao(descricao);
        }

        // Writing(Persistence):
        public async Task<Produto> CreateProduto(Produto produto)
        {
            return await this.repositoryProduto.Add(produto);
        }

        public async Task<Produto> UpdateProduto(Produto produto)
        {
            return await this.repositoryProduto.Update(produto);
        }

        public async Task DeleteProduto(Produto produt)
        {
            await this.repositoryProduto.Remove(produt);
        }

    }
}
