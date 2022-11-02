using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface INetCafeDataAccess<TEntity>
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity? Get(dynamic key);
        public int Add(TEntity o);
        public bool Remove(int id);
        public bool Update(TEntity o);
    }
}
