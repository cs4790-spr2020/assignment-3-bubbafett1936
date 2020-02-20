using System;
using System.Collections.Generic;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class InMemory : IDataStore
    {
        private List<IDatum> _items = new List<IDatum>();
        public bool Create(IDatum datum) {
            _items.Add(datum);

            return true;
        }
        public IDatum Read(int idx) {
            return _items[idx];
        }
        public bool Update(int idx, IDatum datum){
            if (idx < 0) throw new ArgumentOutOfRangeException("Out of range");
            _items[idx] = datum;

            return true;
        }
        public bool Delete(int idx){
            try {
                _items.RemoveAt(idx);
            } catch(ArgumentOutOfRangeException e) {
                throw e;
            }

            return true;
        }
    }
}
