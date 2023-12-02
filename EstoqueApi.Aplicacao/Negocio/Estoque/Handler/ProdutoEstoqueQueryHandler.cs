using EstoqueApi.Dominio.Entidade;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class ProdutoEstoqueQueryHandler : IRequestHandler<ProdutoEstoqueQuery, Estoque>
    {
        private readonly IRepositorioGenerico<Estoque> _genericRepository;

        public ProdutoEstoqueQueryHandler(IRepositorioGenerico<Estoque> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Estoque> Handle(ProdutoEstoqueQuery request, CancellationToken cancellationToken)
        {
            var estoque = await _genericRepository.GetAllAsync(
                    noTracking: true,
                    filter: x => x.ProdutoId == request.IdProduto,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return estoque.FirstOrDefault();

        }
    }
}
