﻿using EstoqueApi.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueApi.Infra.Mapeamento
{
	public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.ToTable("PRODUTO");
            builder.HasKey(p => p.Id);


            builder.HasOne(n => n.Estoque).WithOne(n => n.Produto).OnDelete(DeleteBehavior.Cascade).HasForeignKey<Estoque>(f => f.Produto_Id);
			builder.HasMany(n => n.Categorias).WithMany(n => n.Produtos);
			builder.Property(p => p.Id).HasColumnName("ID").UseIdentityColumn();
			builder.Property(p => p.Descricao).HasColumnName("DESCRICAO").HasColumnType("varchar").HasMaxLength(300).IsRequired();

 
    

        }
    }
}
