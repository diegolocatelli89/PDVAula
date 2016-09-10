using Csystems.Aula02.Dominio.Entidades;
using Csystems.Aula02.Persistencia.Dados.SQLServer.Interfaces;

namespace Csystems.Aula02.Repositorio.Classes
{
    public class RepositorioClientes : Repositorio<Cliente>
    {
        public RepositorioClientes(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
