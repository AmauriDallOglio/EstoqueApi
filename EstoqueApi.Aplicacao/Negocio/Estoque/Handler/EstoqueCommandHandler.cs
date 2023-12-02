using EstoqueApi.Dominio.Entidade;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class EstoqueCommandHandler : IRequestHandler<EstoqueCommand, bool>
    {
        private readonly IRepositorioGenerico<Estoque> _genericRepository;
        private readonly IRepositorioGenerico<Produto> _produtoRepository;

        public EstoqueCommandHandler(
            IRepositorioGenerico<Estoque> genericRepository,
            IRepositorioGenerico<Produto> produtoRepository)
        {
            _genericRepository = genericRepository;
            _produtoRepository = produtoRepository;
        }


        public async Task<bool> Handle(EstoqueCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetByKeysAsync(cancellationToken, request.IdProduto)
                ?? throw new ArgumentException("Id do produto inválido!");

            var estoque = new Estoque
            {
                //Produto = produto,
                ProdutoId = produto.Id,
                InfoCompra = new Qualitativo
                {
                    PrecoUnidade = request.PrecoUnidade,
                    Quantidade = request.Quantidade,
                    UnidadeMedida = request.UnidadeMedida
                }
            };

            await _genericRepository.AddAsync(estoque, cancellationToken).ConfigureAwait(false);
            return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
