using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjeto.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<int> Insert(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(int id);
    }
}
