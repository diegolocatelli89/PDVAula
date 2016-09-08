namespace Csystems.Aula02.Persistencia.Dados.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 150, unicode: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        CPF = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
