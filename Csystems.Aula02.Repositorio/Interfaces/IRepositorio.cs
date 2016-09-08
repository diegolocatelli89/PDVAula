using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csystems.Aula02.Repositorio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        bool Incluir();
        T Alterar();
        bool Excluir();
        IQueryable<T> ObterTodos();
        T Obter(int Id);
    }
}
