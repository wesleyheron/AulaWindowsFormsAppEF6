using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaForms.Repositorios
{
    interface IRepositorio<TEntity> where TEntity: class
    {
        TEntity ListarPorId(int id);
        IEnumerable<TEntity> ListarTodos();
        void Adicionar(TEntity item);
        void Atualizar(TEntity item);
        void Excluir(int id);
        void Salvar();
        
    }
}
