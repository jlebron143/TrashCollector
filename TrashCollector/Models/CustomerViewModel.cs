using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class CustomerViewModel
    {
        [Key]
        
       [Required]
        public string CustomersID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string pickUpDay { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }

        public virtual Schedule Schedule { get; set; }



    }
}