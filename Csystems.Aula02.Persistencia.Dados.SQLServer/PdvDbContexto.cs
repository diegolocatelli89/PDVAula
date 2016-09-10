using Csystems.Aula02.Dominio.Entidades;
using Csystems.Aula02.Persistencia.Dados.SQLServer.Configuracao;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Data.Entity.Core;
using System.Linq;
using Csystems.Aula02.Persistencia.Dados.SQLServer.Interfaces;

namespace Csystems.Aula02.Persistencia.Dados.SQLServer
{
    public class PdvDbContexto : DbContext, IUnitOfWork
    {
        public virtual IDbSet<Produto> Produtos { get; set; }
        public virtual IDbSet<Categoria> Categorias { get; set; }
        public virtual IDbSet<Cliente> Clientes { get; set; }
        public PdvDbContexto()
            : base("DefaultConnection")
        {
            //Database.SetInitializer(new PreparaDbContexto());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(150));

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ClienteConfiguracao());

        }

        public int Commit()
        {
            try
            {
                return SaveChanges();
            }
            catch(Exception err)
            {
                throw new EntityException("Falha no banco de dados: " + err.Message);
            }
        }

        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

    }
}

