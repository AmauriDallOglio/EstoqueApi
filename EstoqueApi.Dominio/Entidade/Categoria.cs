namespace EstoqueApi.Dominio.Entidade
{
	public class Categoria
	{
		public int Id { get; set; }
		public string Descricao { get; set; } = string.Empty;
		public ICollection<Produto> Produtos { get; set; } = default;
	}
}
