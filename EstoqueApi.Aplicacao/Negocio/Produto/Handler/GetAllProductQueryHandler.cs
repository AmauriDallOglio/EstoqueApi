using EstoqueApi.Aplicacao.Negocio.Produto.Query;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Produto.Handler
{
	public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Dominio.Entidade.Produto>>
    {
        private readonly IRepositorioGenerico<Dominio.Entidade.Produto> _produtoRepository;

        public GetAllProductQueryHandler(IRepositorioGenerico<Dominio.Entidade.Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Dominio.Entidade.Produto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetAllAsync(
                    noTracking: false,
                    includeProperties: "Categorias,Estoque",
                    cancellationToken: cancellationToken
                ).ConfigureAwait(false);
        }
    }
}
