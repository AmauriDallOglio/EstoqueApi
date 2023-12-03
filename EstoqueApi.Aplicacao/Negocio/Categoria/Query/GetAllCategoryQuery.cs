using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
	public class GetAllCategoryQuery : IRequest<IEnumerable<Dominio.Entidade.Categoria>>
	{
	}
}
