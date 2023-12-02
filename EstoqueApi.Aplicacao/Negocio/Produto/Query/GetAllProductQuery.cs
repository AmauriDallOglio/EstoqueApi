using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
	public class GetAllProductQuery : IRequest<IEnumerable<Dominio.Entidade.Produto>>
	{

	}
}
