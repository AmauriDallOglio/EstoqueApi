using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Dominio.Entidade.Categoria>>
    {
        private readonly IRepositorioGenerico<Dominio.Entidade.Categoria> _categoriaRepository;

        public GetAllCategoryQueryHandler(IRepositorioGenerico<Dominio.Entidade.Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Dominio.Entidade.Categoria>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _categoriaRepository.GetAllAsync(
                noTracking: true,
                cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}