using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Categoria.Query
{
	public class GetAllCategoriesQuery : IRequest<IEnumerable<Dominio.Entidade.Categoria>>
	{
	}
}
