using System.Collections.Generic;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Domain.Interfaces {
    public interface IRepository<T> where T : BaseEntity 
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetBySysID(string sysId);
        T GetByUserID(string userId);
    }
}
