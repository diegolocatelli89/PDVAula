using Csystems.Aula02.Dominio.Entidades;
using Csystems.Aula02.Persistencia.Dados.SQLServer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Csystems.Aula02.Web.Models
{
    public class PreparaDbContexto : CreateDatabaseIfNotExists<ApplicationDbContext>
    //public class PreparaDbContexto : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        PdvDbContexto pdvDbContexto = new PdvDbContexto();
        protected override void Seed(ApplicationDbContext contexto)
        {
            PopularBaseDados(contexto);
            base.Seed(contexto);
        }

        private void PopularBaseDados(ApplicationDbContext contexto)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contexto));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contexto));

                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Cliente"));
                roleManager.Create(new IdentityRole("Vendedor"));

                var adm = new ApplicationUser() { UserName = "admin@vasis.com.br", Email = "admin@vasis.com.br", CNPJ = "04838544000188", Empresa = "C-Systems" };
                if (userManager.Create(adm, "Gold@2016").Succeeded)
                {
                    userManager.AddToRole(adm.Id, "Admin");
                }
                
                var cli = new ApplicationUser() { UserName = "visitante@vasis.com.br", Email = "visitante@vasis.com.br", CNPJ = "04838521312388", Empresa = "C-Systems" };
                if (userManager.Create(cli, "Gold@2016").Succeeded)
                {
                    userManager.AddToRole(cli.Id, "Cliente");
                }

                PopularClientes(pdvDbContexto);
                PopularCategorias(pdvDbContexto);
                PopularProdutos(pdvDbContexto);
            }
            catch (Exception err)
            {

                throw ;
            }
        }

        private void PopularClientes(PdvDbContexto contexto)
        {
            List<Cliente> clientes = new List<Cliente>();

            for (int i = 0; i < 100; i++)
            {
                Cliente cli = new Cliente();
                cli.Nome = Faker.Name.NomeCompleto();
                cli.CPF = Faker.RandomNumber.Next(10000000).ToString();
                cli.Fantasia = cli.Nome;
                contexto.Clientes.Add(cli);
            }
            contexto.SaveChanges();
        }

        private void PopularCategorias(PdvDbContexto contexto)
        {
            contexto.Categorias.Add(new Categoria { Descricao = "Carnes" });
            contexto.Categorias.Add(new Categoria { Descricao = "Laticinio" });
            contexto.Categorias.Add(new Categoria { Descricao = "Limpeza" });
            contexto.Categorias.Add(new Categoria { Descricao = "Pet" });            
            contexto.SaveChanges();
        }

        private void PopularProdutos(PdvDbContexto contexto)
        {
            var cat1 = contexto.Categorias.Where(x => x.Descricao == "Carnes").FirstOrDefault();
            contexto.Produtos.Add(new Produto { Descricao = "Picanha", Categoria = cat1, CategoriaId = cat1.CategoriaId});
            var cat2 = contexto.Categorias.Where(x => x.Descricao == "Laticinio").FirstOrDefault();
            contexto.Produtos.Add(new Produto { Descricao = "Leite Lider", Categoria = cat2, CategoriaId = cat2.CategoriaId });
            var cat3 = contexto.Categorias.Where(x => x.Descricao == "Limpeza").FirstOrDefault();
            contexto.Produtos.Add(new Produto { Descricao = "Veja Multi uso", Categoria = cat3, CategoriaId = cat3.CategoriaId });
            contexto.SaveChanges();
        }
    }
}