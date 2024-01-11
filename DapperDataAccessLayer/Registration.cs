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
        [Required(ErrorMessage = "Please Enter UserName")]
        [StringLength(50,ErrorMessage ="Please do not enter values over 50 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mismatch Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Invalid UserName or Password")]
        public string ConfirmPassword { get; set; }
    }
}
