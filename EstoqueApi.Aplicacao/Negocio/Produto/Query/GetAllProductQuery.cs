using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Produto.Query
{
	public class GetAllProductQuery : IRequest<IEnumerable<Dominio.Entidade.Produto>>
	{

	}
}
