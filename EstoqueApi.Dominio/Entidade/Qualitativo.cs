namespace EstoqueApi.Dominio.Entidade
{
	public class Qualitativo
	{
		public int Quantidade { get; set; }
		public UnidadeMedidaEnum UnidadeMedida { get; set; }
		public decimal PrecoUnidade { get; set; }
	}
}
