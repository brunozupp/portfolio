using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjeto.Repositories
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        int Insert(T entity);

        bool Update(T entity);

        bool Delete(int id);
    }
}
