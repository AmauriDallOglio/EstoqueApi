using EstoqueApi.Aplicacao.Negocio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("ObterProdutoEstoque/{idProduto:int}")] // Rota para obter estoque de um produto por ID
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProdutoEstoque([FromRoute] int idProduto, CancellationToken cancellationToken = default)
        {
            var estoque = await _mediator.Send(new GetAllEstoqueQuery
            {
                IdProduto = idProduto
            }, cancellationToken).ConfigureAwait(false);
            return estoque == null ? NoContent() : Ok(estoque);
        }

        [HttpPost("Inserir"), ActionName("Inserir")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(EstoqueCommand estoqueCommand, CancellationToken cancellationToken = default)
        {
            var sucesso = await _mediator.Send(estoqueCommand, cancellationToken).ConfigureAwait(false);
            return sucesso ? Ok(true) : BadRequest();
        }
    }
}