using Csystems.Aula02.Dominio.Entidades;
using Csystems.Aula02.Persistencia.Dados.SQLServer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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
            }
            catch (Exception)
            {

                throw;
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
                contexto.Clientes.Add(cli);
            }
            contexto.SaveChanges();
        }
    }
}