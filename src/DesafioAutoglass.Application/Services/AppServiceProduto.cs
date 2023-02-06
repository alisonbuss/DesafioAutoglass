
using AutoMapper;

using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Domain.Interfaces.Services;

using DesafioAutoglass.Application.Interfaces;
using DesafioAutoglass.Application.Dtos;

namespace DesafioAutoglass.Application.Services
{
    public class AppServiceProduto : IAppServiceProduto
    {
        private readonly IMapper mapper;
        private readonly IServiceProduto serviceProduto;

        public AppServiceProduto(IMapper mapper, IServiceProduto serviceProduto)
        {
            this.mapper = mapper;
            this.serviceProduto = serviceProduto;
        }

        // Reading(Consultation):
        public async Task<IEnumerable<DtoProduto>> GetAllProdutos()
        {
            return this.mapper.Map<IEnumerable<DtoProduto>>(
                await this.serviceProduto.GetAllProdutos()
            );
        }

        public async Task<DtoProduto> GetProdutoById(Guid id)
        {
            return this.mapper.Map<DtoProduto>(
                await this.serviceProduto.GetProdutoById(id)
            );
        }

        public async Task<DtoProduto> GetProdutoByCodigo(string codigo)
        {
            return this.mapper.Map<DtoProduto>(
                await this.serviceProduto.GetProdutoByCodigo(codigo)
            );
        }

        public async Task<DtoProduto> GetProdutoByDescricao(string descricao)
        {
            return this.mapper.Map<DtoProduto>(
                await this.serviceProduto.GetProdutoByDescricao(descricao)
            );
        }

        // Writing(Persistence):
        public async Task<DtoProduto> CreateProduto(DtoProduto dtoProduto)
        {
            var currentProduto = this.mapper.Map<Produto>(dtoProduto);

            var newProduto = await this.serviceProduto.CreateProduto(currentProduto);

            return this.mapper.Map<DtoProduto>(newProduto);
        }

        public async Task<DtoProduto> UpdateProduto(DtoProduto dtoProduto)
        {
            var currentProduto = this.mapper.Map<Produto>(dtoProduto);

            var produtoModified = await this.serviceProduto.UpdateProduto(currentProduto);

            return this.mapper.Map<DtoProduto>(produtoModified);
        }

        public async Task DeleteProduto(DtoProduto dtoProduto)
        {
            var currentProduto = this.mapper.Map<Produto>(dtoProduto);

            await this.serviceProduto.DeleteProduto(currentProduto);

            await Task.CompletedTask.ConfigureAwait(false);
        }

        // From class:
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
