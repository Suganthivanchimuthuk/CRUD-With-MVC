using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
    public class RegistrationRepository : IRegistrationRepository
    {

        private readonly SampleDbContext _context;
        public RegistrationRepository(SampleDbContext context)
        {
            _context = context;
        }

        public Registration FindByNumber(long number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> GetRegistrations()
        {
            throw new NotImplementedException();
        }

        public void Insert(Registration reg)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($" exec Insertdata '{reg.UserName}','{reg.Password}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Login(String UserName, String Password)
        {
            try
            {

            }

        }

    }
}
