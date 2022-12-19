using NetCafeUCN.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.DAL.DAO
{
    public interface INetCafeUCNUserDAO
    {
        public IEnumerable<User> GetAll();
        public UserLogin GetHashByEmail(string email);
        public User GetUserByLogin(string Email, string passwordHash);
    }
}
