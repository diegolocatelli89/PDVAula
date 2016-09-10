using Csystems.Aula02.Dominio.Entidades;
using Csystems.Aula02.Persistencia.Dados.SQLServer.Interfaces;

namespace Csystems.Aula02.Repositorio.Classes
{
    public class RepositorioCategorias : Repositorio<Categoria>
    {
        public RepositorioCategorias(IUnitOfWork unitOfWork) : base (unitOfWork)
        {

        }
    }
}
