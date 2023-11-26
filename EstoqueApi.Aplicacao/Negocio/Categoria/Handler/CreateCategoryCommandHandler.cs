using EstoqueApi.Aplicacao.Negocio.Categoria.Command;
using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Categoria.Handler
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
	{
		private readonly IRepositorioGenerico<Dominio.Entidade.Categoria> _categoriaRepository;

		public CreateCategoryCommandHandler(IRepositorioGenerico<Dominio.Entidade.Categoria> categoriaRepository)
		{
			_categoriaRepository = categoriaRepository;
		}

		public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			//if (request.Validation.ErrorMessage != null)
			//	return false;

			var categoria = new Dominio.Entidade.Categoria
			{
				Descricao = request.Descricao
			};

			await _categoriaRepository.AddAsync(categoria, cancellationToken)
				.ConfigureAwait(false);

			return await _categoriaRepository.CommitAsync(cancellationToken)
				.ConfigureAwait(false);
		}
	}
}
