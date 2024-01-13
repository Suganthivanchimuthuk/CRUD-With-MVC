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
            try
            {
                var result = _context.Registration.FromSqlRaw<Registration>($"exec FindbyId {number}").ToList().FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Registration> GetRegistrations()
        {
            try
            {
                IEnumerable<Registration> result = _context.Registration.FromSqlRaw<Registration>($" exec GetallReg ");
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void Insert(Registration reg)
        {
            try
            {
                _context.Database.ExecuteSqlRaw($" exec Insertdata '{reg.UserName}','{reg.Password}','{reg.ConfirmPassword}'");
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

                if (output.Count > 0 & output != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool Register(Registration reg)
        {
            try
            {
                var res = _context.Registration.FromSqlRaw<Registration>($"exec VerifyRegistration '{reg.UserName}','{reg.Password}','{reg.ConfirmPassword}'").ToList();

                if (res.Count > 0 & res != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteRegistration(long id)
        {
            try
            {
                var result = _context.Database.ExecuteSqlRaw($"exec DeleteRegistration {id}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateReg(long id, Registration reg)
        {
            try
            {
                var record = _context.Database.ExecuteSqlRaw($"exec UpdateReg {id},'{reg.UserName}','{reg.Password}','{reg.ConfirmPassword}'");

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
            
            

        


















