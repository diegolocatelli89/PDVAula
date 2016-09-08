using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csystems.Aula02.Persistencia.Dados.SQLServer.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
        void Rollback();
    }
}
