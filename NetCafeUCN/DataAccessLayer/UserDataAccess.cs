using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDataAccess : INetCafeDataAccess<Person>
    {
        public int Add(Person o)
        {
            throw new NotImplementedException();
        }

        public Person? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person o)
        {
            throw new NotImplementedException();
        }
    }
}
