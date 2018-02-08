using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Workers
    {
        [Key]
        public int WorkerID { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string URLReturn { get; set; }

    }
}