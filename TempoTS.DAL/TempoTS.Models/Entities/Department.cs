using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TempoTS.Models.Entities.Base;

namespace TempoTS.Models.Entities
{
    [Table("Departments", Schema = "TimeSheet")]
    public class Department : EntityBase
    {
        public string Name { get; set; }

        [ForeignKey(nameof(User))]
        public User ManagerID { get; set; }
    }
}
