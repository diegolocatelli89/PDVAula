using Csystems.Aula02.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace Csystems.Aula02.Persistencia.Dados.SQLServer.Configuracao
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            ToTable("Clientes");
            HasKey(m => m.ClienteId);

            Property(m => m.Nome).IsRequired().HasMaxLength(100);
            Property(m => m.Fantasia).IsRequired().HasMaxLength(100);
            Property(m => m.CPF).IsRequired().HasMaxLength(20);
        }
    }
}
