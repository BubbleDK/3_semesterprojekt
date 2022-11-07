using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class BookingDataAccess : INetCafeDataAccess<Booking>
    {
        public bool Add(Booking o)
        {
            throw new NotImplementedException();
        }

        public Booking? Get(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Booking o)
        {
            throw new NotImplementedException();
        }
    }
}