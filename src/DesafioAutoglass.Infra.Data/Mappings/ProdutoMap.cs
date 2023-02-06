
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DesafioAutoglass.Domain.Entities;

namespace DesafioAutoglass.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            // Define specific table name.
            builder.ToTable("Produtos", schema: "domain");

            // Create primary key:
            builder
                .HasKey(entity => entity.Id);

            // Columns:
            builder.Property(entity => entity.Codigo)
                .HasColumnType("nvarchar(33)")
                .HasMaxLength(33)
                .IsRequired();

            builder.Property(entity => entity.Descricao)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(entity => entity.Situacao)
                .HasColumnType("bit")
                .HasConversion<bool>()
                .IsRequired();

            builder.Property(entity => entity.DataFabricacao)
                .HasColumnType("DATE")
                // .HasConversion<DateOnlyConverter, DateOnlyComparer>()
                .IsRequired();

            builder.Property(entity => entity.DataValidade)
                .HasColumnType("DATE")
                // .HasConversion<DateOnlyConverter, DateOnlyComparer>()
                .IsRequired();

            builder.Property(entity => entity.CodigoFornecedor)
                .HasColumnType("nvarchar(33)")
                .HasMaxLength(33)
                .IsRequired();

            builder.Property(entity => entity.DescricaoFornecedor)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(entity => entity.CNPJFornecedor)
                .HasColumnType("nvarchar(14)")
                .HasMaxLength(14)
                .IsRequired();

            // Add Indexing:
            builder.HasIndex(entity => entity.Codigo).IsUnique();

        }

    }
}
