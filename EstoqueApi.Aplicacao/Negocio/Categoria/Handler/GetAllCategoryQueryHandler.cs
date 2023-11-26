using EstoqueApi.Aplicacao.Negocio.Categoria.Query;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Categoria.Handler
{
	public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Dominio.Entidade.Categoria>>
	{
		private readonly IRepositorioGenerico<Dominio.Entidade.Categoria> _categoriaRepository;

		public GetAllCategoryQueryHandler(IRepositorioGenerico<Dominio.Entidade.Categoria> categoriaRepository)
		{
			_categoriaRepository = categoriaRepository;
		}

		public async Task<IEnumerable<Dominio.Entidade.Categoria>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
		{
			return await _categoriaRepository.GetAllAsync(
				noTracking: true,
				cancellationToken: cancellationToken
				).ConfigureAwait(false);
		}
	}
}