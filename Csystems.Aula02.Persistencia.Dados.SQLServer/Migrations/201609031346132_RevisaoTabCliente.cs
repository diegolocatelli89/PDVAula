namespace Csystems.Aula02.Persistencia.Dados.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevisaoTabCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Fantasia", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Fantasia");
        }
    }
}
