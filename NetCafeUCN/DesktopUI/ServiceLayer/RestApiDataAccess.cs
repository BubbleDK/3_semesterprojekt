using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.Desktop.ServiceLayer
{
    internal class RestApiDataAccess : INetCafeService<TEntity>
    {
        public int Add(TEntity o)
        {
            throw new NotImplementedException();
        }

        public TEntity? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity o)
        {
            throw new NotImplementedException();
        }
    }
}
