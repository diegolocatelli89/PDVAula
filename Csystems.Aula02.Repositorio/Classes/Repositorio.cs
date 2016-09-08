using Csystems.Aula02.Persistencia.Dados.SQLServer;
using Csystems.Aula02.Persistencia.Dados.SQLServer.Interfaces;
using Csystems.Aula02.Repositorio.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Csystems.Aula02.Repositorio.Classes
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _contexto;

        public DbSet<T> PdvDbContexto { get; private set; }

        public Repositorio(IUnitOfWork unitOfWork)
        {
            _contexto = ((PdvDbContexto)unitOfWork).Set<T>();

            _unitOfWork = unitOfWork;
        }
        public T Alterar()
        {
            throw new NotImplementedException();
        }

        public bool Excluir()
        {
            throw new NotImplementedException();
        }

        public bool Incluir()
        {
            throw new NotImplementedException();
        }

        public T Obter(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
