﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Schedule
    {
           [Key]
        public int ScheduleID { get; set; }
        public int PickUpDays { get; set; }
        public string ScheduledDays { get; set; }
        public string AdditionalDay { get; set; }
        public decimal TrashCost { get; set; }
      
        public DateTime? VacationModeStart { get; set; }
        public DateTime? VacationModeEnd { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}