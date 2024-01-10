using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public interface IRegistrationRepository
    {
        public IEnumerable<Registration> GetRegistrations();

        public bool Login(String UserName, String Password);

    }
}
