using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueApi.Dominio.Entidade
{
	public class Estoque
	{
		public int Id { get; set; }
		public int Produto_Id { get; set; }
        [ForeignKey("Produto_Id")]
        public Produto Produto { get; set; }
        public Qualitativo InfoCompra { get; set; }
	}
}
