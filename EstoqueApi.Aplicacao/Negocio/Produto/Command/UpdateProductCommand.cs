using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
	public class UpdateProductCommand : IRequest<bool>
	{
		public int Id { get; set; }
		public string Descricao { get; set; }

		public int[] IdCategorias { get; set; }
	}
}
