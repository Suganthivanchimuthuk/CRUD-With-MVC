﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DapperDataAccessLayer
{
    public class VehicleInfo
    {
        public long Id { get; set; }

        [Required(ErrorMessage="Please Enter Your VehicleName"),MaxLength(50)]
        [StringLength(50, ErrorMessage="Please do not enter values over 50 characters")]
         
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter VehicleNumber")]
        [Range (1,100, ErrorMessage="0 is Not Allowed" )]
        public long VehicleNumber { get; set; }

        
        [Required(ErrorMessage = "Please Enter RCNumber")]
        
        public string RCNumber { get; set; }

        [Required(ErrorMessage = "Please Enter OwnerPhoneNumber")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Incorrect Phonenumber")]
        [Display(Name = "OwnerMobileNumber")]
        public long OwnerPhNo { get; set; }

        [Required(ErrorMessage = "Please Enter PurchaseDate")]
        public DateTime PurchaseDate { get; set; }
        public long LocationId { get; set; }
        public List<Location>Locations { get; set; }
    }    

}
