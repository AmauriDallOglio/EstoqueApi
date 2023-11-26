using EstoqueApi.Aplicacao.Negocio.Produto.Command;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Produto.Handler
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
	{
		private readonly IRepositorioGenerico<Dominio.Entidade.Produto> _genericRepository;
		private readonly IRepositorioGenerico<Dominio.Entidade.Categoria> _categoiaRepository;

		public UpdateProductCommandHandler(IRepositorioGenerico<Dominio.Entidade.Produto> genericRepository, IRepositorioGenerico<Dominio.Entidade.Categoria> categoiaRepository)
		{
			_genericRepository = genericRepository;
			_categoiaRepository = categoiaRepository;
		}

		public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			//todo: validar a rquest

			var produtos = await _genericRepository.GetAllAsync(filter: x => x.Id == request.Id, includeProperties: "Categorias").ConfigureAwait(false);

			var produto = produtos.FirstOrDefault() ?? throw new ArgumentNullException($"Produto {request.Id} não encontrado.");


			produto.Descricao = request.Descricao;
			if (request.IdCategorias.Any())
			{
				var categorias = _categoiaRepository.GetAll().Where(x => request.IdCategorias.Contains(x.Id)).ToList();
				produto.Categorias = categorias;
			}

			_genericRepository.Update(produto);

			return await _genericRepository.CommitAsync(cancellationToken).ConfigureAwait(false);
		}
	}
}
