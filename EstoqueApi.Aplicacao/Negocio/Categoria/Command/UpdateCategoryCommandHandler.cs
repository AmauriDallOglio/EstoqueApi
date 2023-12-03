using EstoqueApi.Infra.Repositorio;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IRepositorioGenerico<Dominio.Entidade.Categoria> _categoriaRepository;

        public UpdateCategoryCommandHandler(IRepositorioGenerico<Dominio.Entidade.Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByKeysAsync(cancellationToken,
                request.Id).ConfigureAwait(false);

            categoria.Descricao = request.Descricao;

            _categoriaRepository.Update(categoria);
            return await _categoriaRepository.CommitAsync(cancellationToken).ConfigureAwait(false);

        }
    }
}
