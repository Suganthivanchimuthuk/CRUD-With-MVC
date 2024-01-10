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

        //public Registration FindByNumber(long number)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Registration> GetRegistrations()
        {
            try
            {
                IEnumerable<Registration> result = _context.Registration.FromSqlRaw<Registration>($" exec GetallReg ");
                return result.ToList();
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
           
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
                var output = _context.Registration.FromSqlRaw<Registration>($"exec  VerifyPassword '{UserName}','{Password}'").ToList();

                if(output.Count>0 & output!=null)             
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                throw;
            }
           

        }

    }
}
