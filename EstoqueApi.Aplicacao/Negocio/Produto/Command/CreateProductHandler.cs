using EstoqueApi.Dominio.Entidade;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IRepositorioGenerico<Produto> _produtoRepository;
        private readonly IRepositorioGenerico<Dominio.Entidade.Categoria> _categoiaRepository;

        public CreateProductHandler(IRepositorioGenerico<Dominio.Entidade.Produto> produtoRepository,
            IRepositorioGenerico<Dominio.Entidade.Categoria> categoiaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoiaRepository = categoiaRepository;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var categorias = _categoiaRepository.GetAll()
                .Where(x => request.IdCategorias.Contains(x.Id)).ToList();


            var produto = new Dominio.Entidade.Produto
            {
                Descricao = request.Descricao,
                Categorias = categorias
            };
            await _produtoRepository.AddAsync(produto, cancellationToken).ConfigureAwait(false);
            return await _produtoRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
