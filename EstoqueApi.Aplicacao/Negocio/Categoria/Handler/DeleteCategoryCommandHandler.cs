using EstoqueApi.Aplicacao.Negocio;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Categoria.Handler
{
	public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
	{
		private readonly IRepositorioGenerico<Dominio.Entidade.Categoria> _categoriaRepository;

		public DeleteCategoryCommandHandler(IRepositorioGenerico<Dominio.Entidade.Categoria> categoriaRepository)
		{
			_categoriaRepository = categoriaRepository;
		}
		public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var categoria = await _categoriaRepository.GetByKeysAsync(cancellationToken,
				request.Id).ConfigureAwait(false);

			_categoriaRepository.Delete(categoria);

			return await _categoriaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

		}
	}
}
