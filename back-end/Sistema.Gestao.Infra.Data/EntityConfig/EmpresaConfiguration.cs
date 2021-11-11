

using System.Data.Entity.ModelConfiguration;
using Sistema.Gestao.Domain.Entities;

namespace Sistema.Gestao.Infra.Data.EntityConfig
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
