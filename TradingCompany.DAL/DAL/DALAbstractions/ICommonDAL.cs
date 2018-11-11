using System.Collections.Generic;

namespace TradingCompany.DAL
{
    interface ICommonDAL<T> where T : class, new()
    {
        List<T> Get();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity, int entityId);
        void Delete(int id);
    }
}
