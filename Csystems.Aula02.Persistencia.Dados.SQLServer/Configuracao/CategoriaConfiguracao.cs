using Csystems.Aula02.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csystems.Aula02.Persistencia.Dados.SQLServer.Configuracao
{
    public class CategoriaConfiguracao : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguracao()
        {
            ToTable("Categoria");
            HasKey(c => c.CategoriaId);
            Property(c => c.Descricao).IsRequired().HasMaxLength(100);
            HasMany(c => c.Produtos)
                .WithRequired(a => a.Categoria)
                .Map(x => x.MapKey("CategoriaId"));
        }
    }
}
