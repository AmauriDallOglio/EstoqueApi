using EstoqueApi.Aplicacao.Negocio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class ProdutoController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProdutoController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("ObterProduto"), ActionName("ObterProduto")]
        public async Task<IActionResult> Obter(CancellationToken cancellationToken)
		{
			var produtos = await _mediator.Send(new GetAllProductQuery(), cancellationToken)
				.ConfigureAwait(false);
			return produtos.Any() ? Ok(produtos) : NoContent();
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("Create"), ActionName("Create")]
        public async Task<IActionResult> Create(CreateProductCommand createCommand,
			CancellationToken cancellationToken)
		{

			if (!createCommand.Validation.IsValid)
				return BadRequest(createCommand.Validation.Errors);

			var sucesso = await _mediator.Send(createCommand, cancellationToken)
				.ConfigureAwait(false);

			return Ok(sucesso);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("Update"), ActionName("Update")]
        public async Task<IActionResult> Update(UpdateProductCommand updateCommand, CancellationToken cancellationToken)
		{
			var sucesso = await _mediator.Send(updateCommand, cancellationToken).ConfigureAwait(false);
			return sucesso ? Ok(true) : BadRequest();
		}

		//[HttpDelete]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesResponseType(StatusCodes.Status400BadRequest)]
		//public async Task<IActionResult> Delelete(DeleteCommand deleteCommand, CancellationToken cancellationToken)
		//{
		//	var sucesso = await _mediator.Send(deleteCommand, cancellationToken).ConfigureAwait(false);
		//	return sucesso ? Ok(true) : BadRequest();
		//}
	}
}
