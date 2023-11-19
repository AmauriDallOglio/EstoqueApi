using EstoqueApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Infra.Mapeamento
{
	public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder.ToTable("CATEGORIA");
			builder.Property(p => p.Id).HasColumnName("ID").UseIdentityColumn();

			builder.Property(p => p.Descricao).HasColumnName("DESCRICAO").HasColumnType("varchar").HasMaxLength(50).IsRequired();
		}
	}
}