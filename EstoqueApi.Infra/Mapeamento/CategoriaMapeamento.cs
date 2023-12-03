using EstoqueApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace EstoqueApi.Infra.Mapeamento
{
	public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder.ToTable("CATEGORIA");
			builder.Property(p => p.Id).HasColumnName("ID").UseIdentityColumn();

			builder.Property(p => p.Descricao).HasColumnName("DESCRICAO").HasColumnType("varchar").HasMaxLength(50).IsRequired();

            builder.HasMany(c => c.Produtos).WithMany(p => p.Categorias).UsingEntity(j => j.ToTable("CategoriaProduto"));

        }
	}
}