using EstoqueApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Infra.Mapeamento
{
    public class EstoqueMapeamento : IEntityTypeConfiguration<Estoque>
	{
		public void Configure(EntityTypeBuilder<Estoque> builder)
		{
			builder.ToTable("ESTOQUE");
            builder.Property(s => s.Produto_Id).IsRequired().HasColumnName("ProdutoId").HasColumnType("guid");
            builder.OwnsOne(n => n.InfoCompra).Property(p => p.PrecoUnidade).HasColumnName("PRECO_UNITARIO").HasPrecision(16, 4);
			builder.OwnsOne(n => n.InfoCompra).Property(p => p.Quantidade).HasColumnName("QUATIDADE");
			builder.OwnsOne(n => n.InfoCompra).Property(p => p.UnidadeMedida).HasColumnName("UNIDADE_MEDIDA");
			// builder.HasOne(n => n.Produto).WithOne(n => n.Estoque).HasForeignKey<Estoque>(k => k.Produto_Id);


          //  builder.HasOne(e => e.Produto).WithOne(p => p.Estoque).HasForeignKey<Estoque>("Id_Produto").HasPrincipalKey<Produto>(p => p.Id).IsRequired(); // Se necessário
            builder.HasOne(e => e.Produto).WithOne(p => p.Estoque).HasForeignKey<Estoque>(e => e.Produto_Id).OnDelete(DeleteBehavior.Cascade);


        }
	}
}

