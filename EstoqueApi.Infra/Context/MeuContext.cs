using EstoqueApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;

namespace EstoqueApi.Infra.Context
{
	public class MeuContext : DbContext
	{
		public MeuContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Estoque> Estoques { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuContext).Assembly);
		}
	}
}
