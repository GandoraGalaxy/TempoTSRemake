using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TempoTS.Models.Entities.Base;

namespace TempoTS.Models.Entities
{
    [Table("TimeClock", Schema = "TimeSheet")]
    public class TimeClock : EntityBase
    {
        public DateTime ClockIn { get; set; }

        public DateTime InLunch { get; set; }

        public DateTime OutLunch { get; set; }

        public DateTime ClockOut { get; set; }

        public DateTime TotalHours { get; set; }

        public User EmployeeID { get; set; }
    }
}
