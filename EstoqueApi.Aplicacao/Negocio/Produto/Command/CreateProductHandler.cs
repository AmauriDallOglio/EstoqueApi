using EstoqueApi.Dominio.Entidade;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IRepositorioGenerico<Produto> _produtoRepository;
        private readonly IRepositorioGenerico<Categoria> _categoiaRepository;

        public CreateProductHandler(IRepositorioGenerico<Produto> produtoRepository,  IRepositorioGenerico<Categoria> categoiaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoiaRepository = categoiaRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var categorias = _categoiaRepository.GetAll().Where(x => request.IdCategorias.Contains(x.Id)).ToList();
            var produto = new Produto
            {
                Descricao = request.Descricao,
                Categorias = categorias
            };
            await _produtoRepository.AddAsync(produto, cancellationToken).ConfigureAwait(false);
            return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
