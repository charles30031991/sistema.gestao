
using System.Data.Entity.ModelConfiguration;
using Sistema.Gestao.Domain.Entities;

namespace Sistema.Gestao.Infra.Data.EntityConfig
{
    public class FuncionarioConfiguration : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(p => p.Empresa)
                .WithMany()
                .HasForeignKey(p => p.EmpresaId);
        }
    }
}
