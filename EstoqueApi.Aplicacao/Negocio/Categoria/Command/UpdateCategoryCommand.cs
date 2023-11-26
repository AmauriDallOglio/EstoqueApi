using MediatR;

namespace EstoqueApi.Aplicacao.Negocio.Categoria.Command
{
	public class UpdateCategoryCommand : IRequest<bool>
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
	}
}
