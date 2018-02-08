using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class DriverRoute
    {
        [Key]
        public int Id { get; set; }
         [Required]
         public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public int WorkersId { get; set; }
        public virtual Workers Workers { get; set; }
    }
}