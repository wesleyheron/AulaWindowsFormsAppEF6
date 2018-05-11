using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaForms.Repositorios
{
    public abstract class Repositorio<TEntity> : IDisposable, IRepositorio<TEntity> where TEntity : class
    {
        EscolaDbContext _contexto = new EscolaDbContext();
        
        public void Adicionar(TEntity item)
        {
            _contexto.Set<TEntity>().Add(item);
        }

        public void Atualizar(TEntity item)
        {
            _contexto.Entry(item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public void Excluir(int id)
        {
            var entidadeASerDeletada = _contexto.Set<TEntity>().Find(id);
            _contexto.Set<TEntity>().Remove(entidadeASerDeletada);
        }

        public TEntity ListarPorId(int id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ListarTodos()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}
