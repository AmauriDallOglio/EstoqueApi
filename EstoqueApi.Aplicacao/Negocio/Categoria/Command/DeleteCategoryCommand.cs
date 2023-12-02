using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
	public class DeleteCategoryCommand : IRequest<bool>
	{
		public int Id { get; set; }
	}
}
