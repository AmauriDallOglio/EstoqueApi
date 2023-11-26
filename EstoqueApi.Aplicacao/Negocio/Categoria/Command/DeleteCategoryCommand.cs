using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Categoria.Command
{
	public class DeleteCategoryCommand : IRequest<bool>
	{
		public int Id { get; set; }
	}
}
