using Csystems.Aula02.Persistencia.Dados.SQLServer;
using Csystems.Aula02.Persistencia.Dados.SQLServer.Interfaces;
using Csystems.Aula02.Repositorio.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        public DbSet<T> Contexto { get { return _contexto; } }

        public T Incluir(T entidade)
        {
            try
            {
                _contexto.Add(entidade);
                ((PdvDbContexto)_unitOfWork).Entry(entidade).State = EntityState.Added;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return entidade;
        }

        public T Alterar(T entidade)
        {
            try
            {
                ((PdvDbContexto)_unitOfWork).Entry(entidade).State = EntityState.Modified;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return entidade;
        }

        public void Excluir(T entidade)
        {
            try
            {
                _contexto.Remove(entidade);
                //Desnecessário
                //((PdvDbContexto)_unitOfWork).Entry(entidade).State = EntityState.Deleted;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public IQueryable<T> ObterTodos()
        {
            return _contexto;
        }

        public T Obter(Expression<Func<T, bool>> filtro)
        {
            return _contexto.FirstOrDefault(filtro);
        }
    }
}
