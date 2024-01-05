using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDataAccessLayer
{
      public class Registration
    { 
    
        [Key]
        public long RegistrationId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
