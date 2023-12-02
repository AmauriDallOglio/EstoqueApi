using EstoqueApi.Aplicacao.Negocio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : Controller
    {
        private readonly IMediator _mediator;

        public EstoqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{idProduto:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("ObterProdutoEstoque"), ActionName("ObterProdutoEstoque")]
        public async Task<IActionResult> GetProdutoEstoque([FromRoute] int idProduto, CancellationToken cancellationToken = default)
        {
            var estoque = await _mediator.Send(new ProdutoEstoqueQuery
            {
                IdProduto = idProduto
            }, cancellationToken).ConfigureAwait(false);
            return estoque == null ? NoContent() : Ok(estoque);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("Create"), ActionName("Create")]
        public async Task<IActionResult> Create(EstoqueCommand estoqueCommand, CancellationToken cancellationToken = default)
        {
            var sucesso = await _mediator.Send(estoqueCommand, cancellationToken).ConfigureAwait(false);
            return sucesso ? Ok(true) : BadRequest();
        }
    }
}