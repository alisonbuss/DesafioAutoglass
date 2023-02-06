
using Microsoft.AspNetCore.Mvc;

using DesafioAutoglass.Common.Interfaces;
using DesafioAutoglass.Application.Interfaces;
using DesafioAutoglass.Application.Dtos;

namespace DesafioAutoglass.Service.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/protudos")]
    [Produces("application/json")]
    public class ProdutoController : ControllerBaseAPI
    {
        private readonly ILoggerManager<ProdutoController> logger;
        private readonly IAppServiceProduto appServiceProduto;

        public ProdutoController(
            ILoggerManager<ProdutoController> logger, IAppServiceProduto appServiceProduto
        ) : base()
        {
            this.logger = logger;
            this.appServiceProduto = appServiceProduto;
        }

        // Reading(Consultation):

        // GET: api/v1/protudos
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<DtoProduto>>> ReadAll()
        {
            this.logger.LogInfo("ProdutoController.ReadAll: GET: api/v1/protudos");

            // Testing a delay...
            await Task.Delay(2000);

            var models = await this.appServiceProduto.GetAllProdutos();

            return Ok(models);
        }

        // GET: api/v1/protudos/123
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<DtoProduto>> ReadById(Guid id)
        {
            this.logger.LogInfo($"ProdutoController.ReadById: GET: api/v1/protudos/{id}");

            var model = await this.appServiceProduto.GetProdutoById((Guid) id);

            if (model == null)
                return NotFound("Error: The protudo not found.");

            return Ok(model);
        }

        // GET: api/v1/protudos/produtoA
        [HttpGet]
        [Route("{descricao}")]
        public async Task<ActionResult<DtoProduto>> ReadByDescricao(string descricao)
        {
            this.logger.LogInfo($"ProdutoController.ReadByDescricao: GET: api/v1/protudos/{descricao}");

            if (descricao == null)
                return BadRequest("Error: The protudo descricao is null!");

            var model = await this.appServiceProduto.GetProdutoByDescricao(descricao);

            if (model == null)
                return NotFound("Error: The protudo not found.");

            return Ok(model);
        }

        // Writing(Persistence):

        // POST: api/v1/protudos
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<DtoProduto>> Create([FromBody] DtoProduto model)
        {
            this.logger.LogInfo("ProdutoController.Create: POST: api/v1/protudos");

            var newModel = await this.appServiceProduto.CreateProduto(model);

            if (newModel == null)
                return BadRequest("Error: On persistence.");

            return Ok(newModel);
        }

        // PUT: api/v1/protudos
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<DtoProduto>> Update([FromBody] DtoProduto model)
        {
            this.logger.LogInfo("ProdutoController.Update: PUT: api/v1/protudos");

            var updatedModel = await this.appServiceProduto.UpdateProduto(model);

            if (updatedModel == null)
                return BadRequest("Error: On persistence.");

            return Ok(updatedModel);
        }

        // DELETE: api/v1/protudos/33
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> Remove(Guid? id)
        {
            this.logger.LogInfo($"ProdutoController.Remove: DELETE: api/v1/protudos/{id}");

            if (id == null)
                return BadRequest("Error: The protudo ID is null!");

            var model = await this.appServiceProduto.GetProdutoById((Guid) id);

            if (model == null)
                return NotFound("Error: The protudo not found.");

            await this.appServiceProduto.DeleteProduto(model);

            return NoContent();
        }

    }
}
