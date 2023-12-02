using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{ 
	public class UpdateCategoryCommand : IRequest<bool>
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
	}
}
