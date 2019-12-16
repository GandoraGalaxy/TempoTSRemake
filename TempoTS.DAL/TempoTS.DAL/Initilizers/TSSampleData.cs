using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TempoTS.DAL.EF;
using TempoTS.Models.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TempoTS.DAL.Initilizers
{
    public class TSSampleData
    {
        public static IEnumerable<Department> GetDivisions() => new List<Department>
        {
            new Department {Name = "Floor Walker"},
            new Department {Name = "Retail"},
            new Department {Name = "Pets"},
            new Department {Name = "Cashier"},
            new Department {Name = "Home Goods"}
        };

        public static IEnumerable<TimeClock> GetTime() => new List<TimeClock>
        {
            new TimeClock {ClockIn = new DateTime(2019, 12, 7)},
            new TimeClock {ClockOut = new DateTime(2019, 12, 7)},
            new TimeClock {InLunch = new DateTime(2019, 12, 7)},
            new TimeClock {OutLunch = new DateTime(2019, 12, 7)},
            new TimeClock {EmployeeID = new User()},
        };

        public static IEnumerable<Payroll> GetPayroll() => new List<Payroll>
        {
            new Payroll {Salary = 150.0M},
            new Payroll {Salary = 75.0M},
            new Payroll {Salary = 150.0M},
            new Payroll {Salary = 250.0M},
        };
    }
}
