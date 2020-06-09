using bdiEntidades.Entidades;
using bdiNegocios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bdiRepositorio.Mapiamentos
{
    public  class ContatoMapeamento: IEntityTypeConfiguration<Contato>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato", "ContatoApi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("id");

            builder.Property(x => x.Nome)
                .HasColumnName("contato_nome")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Sexo)
                .HasColumnName("contato_sexo")
                .HasMaxLength(1)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("contato_dt_nascimento")
                .IsRequired();

            builder.Property(x => x.Idade)
               .HasColumnName("contato_idade")
               .IsRequired();
        }
    }
}
