using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TempoTS.Models.Entities.Base;

namespace TempoTS.Models.Entities
{
    [Table("Payroll", Schema = "TimeSheet")]
    public class Payroll : EntityBase
    {
        public decimal Salary { get; set; }

        public User EmployeeID { get; set; }
    }
}
