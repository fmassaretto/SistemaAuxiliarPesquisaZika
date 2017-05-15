using System.Collections.Generic;

namespace SistemaAuxiliarPesquisaZika.Domain.Interface
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        TEntity SelectById(int id);
        IEnumerable<TEntity> SelectAll();
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Disposed();
    }
}
