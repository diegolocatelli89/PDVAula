using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Csystems.Aula02.Repositorio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        T Incluir(T entidade);
        T Alterar(T entidade);
        void Excluir(T entidade);
        IQueryable<T> ObterTodos();
        T Obter(Expression<Func<T, bool>> filtro);
        //IUnitOfOwork UnitOfWord { get; }
    }
}
