using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
	public class GetAllCategoriesQuery : IRequest<IEnumerable<Dominio.Entidade.Categoria>>
	{
	}
}
