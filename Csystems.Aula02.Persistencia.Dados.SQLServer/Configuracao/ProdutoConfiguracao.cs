using Csystems.Aula02.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csystems.Aula02.Persistencia.Dados.SQLServer.Configuracao
{
    public class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            ToTable("Produto");
            HasKey(k => k.ProdutoId);

            Property(k => k.Descricao).IsRequired().HasMaxLength(100);
            HasRequired(k => k.Categoria)
            .WithMany()
            .HasForeignKey(k => k.CategoriaId);            
        }
    }
}
