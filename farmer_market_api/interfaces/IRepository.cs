using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace farmer_market_api.interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Add(T entity);
        T? Update(T entity);
        bool Delete(T entity);
        T? GetByID(int id);

    }
}