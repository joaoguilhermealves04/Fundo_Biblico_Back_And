using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Dominio.Interfaces.RepositoryBase
{
    public interface IRepositoryBase<TEntity>:IDisposable where TEntity :class
    {
        Task<TEntity> ObterPorId(Guid id);
        Task Adicionar(TEntity entity);
        void Atualizar (TEntity entity);
        Task Remover(TEntity entity);
        Task<IEnumerable<TEntity>> ObterTodos();
    }
}
