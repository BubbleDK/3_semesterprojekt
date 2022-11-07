using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCafeUCN.tests
{
    public class DesktopApp_UserServiceTests
    {
        [Fact]
        public void TestAddMethod()
        {
            Person person = new Customer();
            person.Email = "rasmus@ramus.dk";
            person.Phone = "12345678";
            person.Name = "Rasmus";

        }
    }
}
