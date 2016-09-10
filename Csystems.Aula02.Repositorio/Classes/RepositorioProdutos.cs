using Csystems.Aula02.Dominio.Entidades;
using Csystems.Aula02.Persistencia.Dados.SQLServer.Interfaces;

namespace Csystems.Aula02.Repositorio.Classes
{
    public class RepositorioProdutos : Repositorio<Produto>
    {
        public RepositorioProdutos(IUnitOfWork unitOfWork) : base (unitOfWork)
        {

        }
    }
}
 