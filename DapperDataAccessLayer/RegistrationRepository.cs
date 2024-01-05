using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
     public class RegistrationRepository:IRegistrationRepository
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

        public IEnumerable<Registration> GetAllRegistration()
        {
            throw new NotImplementedException();
        }

        public void Insert(Registration reg)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("sp");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
