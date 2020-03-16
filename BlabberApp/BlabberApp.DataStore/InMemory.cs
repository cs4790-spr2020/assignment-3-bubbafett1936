using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlabberApp.DataStore
{
    public class InMemory<T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationContext Context;
        private DbSet<T> _entities;

        public InMemory(ApplicationContext context) {
            Context = context;
            _entities = context.Set<T>();
        }

        public void Add(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");

            _entities.Add(entity);
            Context.SaveChanges();
        }

        public void Remove(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");
            
            _entities.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(T entity) {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Context.SaveChanges();
        }

        public IEnumerable<T> GetAll() {
            return _entities.AsEnumerable();
        }

        public T GetBySysID(string sysId) {
            if (sysId.Equals("") )
                throw new ArgumentNullException("sysID");

            return _entities.Where(e => e.SysID == sysId).FirstOrDefault();
        }

        public Dictionary<string,T> GetByUserID(string userId) {
            if (userId.Equals("") )
                throw new ArgumentNullException("userID");

            Dictionary<string, T> dict = _entities.ToDictionary(e => e.SysID);
            Dictionary<string, T> result = new Dictionary<string, T>();
            foreach (KeyValuePair<string, T> kvp in dict) {
                if (kvp.Value.User == userId) result.Add(kvp.Key, kvp.Value);
            }

            return result;
        }
    }
}
