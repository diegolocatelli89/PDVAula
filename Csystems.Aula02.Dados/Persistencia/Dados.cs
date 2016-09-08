
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csystems.Aula02.Dominio.Entidades;


namespace Csystems.Aula02.Persistencia.Dados
{
    public static class Dados
    {

        public static List<Cliente> Clientes = new List<Cliente>();

        public static List<Cliente> CarregaLista()
        {
            if (Clientes.Count <=0)
            {
                Clientes.Add(new Cliente {ClienteId = 1, Nome = "Diego", CPF = "0000000000"});
                Clientes.Add(new Cliente {ClienteId = 2, Nome = "Denner", CPF = "512343154"});
                Clientes.Add(new Cliente {ClienteId = 3, Nome = "Donizetti", CPF = "511224154"});
            }
            return Clientes;
        }

        public static void Editar(Cliente cliente)
        {
            var model = Clientes.First(x => x.ClienteId == cliente.ClienteId);
            Dados.Clientes.Remove(model);
            Dados.Clientes.Add(cliente);
        }
    }
}
