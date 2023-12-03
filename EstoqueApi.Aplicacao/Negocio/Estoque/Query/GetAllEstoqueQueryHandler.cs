using EstoqueApi.Dominio.Entidade;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{ 
    public class GetAllEstoqueQueryHandler : IRequestHandler<GetAllEstoqueQuery, IEnumerable<Estoque>>
    {
        private readonly IRepositorioGenerico<Estoque> _genericRepository;

        public GetAllEstoqueQueryHandler(IRepositorioGenerico<Estoque> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Estoque>> Handle(GetAllEstoqueQuery request, CancellationToken cancellationToken)
        {
            var estoque = await _genericRepository.GetAllAsync(
                    noTracking: true,
                    includeProperties: "Produto",
                    filter: x => x.Produto_Id == request.IdProduto,
                    cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            return estoque;

        }
    }
}
