using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string userNameID { get; set; }
        public string pickUpDay { get; set; }

        public virtual Schedule schedule { get; set; }

        public async Task<DeclaresIdentity> GenerateUserIdentityAsync(UserMan)
        
    }
}