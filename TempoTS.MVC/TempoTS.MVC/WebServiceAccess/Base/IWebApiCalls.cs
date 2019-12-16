using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempoTS.Models.Entities;

namespace TempoTS.MVC.WebServiceAccess.Base
{
    public interface IWebApiCalls
    {
        Task<IList<Department>> GetDivisionsAsync();
        Task<IList<Payroll>> GetPayrollAsync();
        Task<IList<TimeClock>> GetTimeClockAsync();
        Task<IList<User>> GetUsersAsync();
        Task<IList<Department>> UpdateDivisionsAsync();
        Task<IList<Payroll>> UpdatePayrollAsync();
        Task<IList<TimeClock>> UpdateTimeClockAsync();
        Task<IList<User>> UpdateUsersAsync();
        Task<IList<Department>> AddDivisionsAsync();
        Task<IList<Payroll>> AddPayrollAsync();
        Task<IList<TimeClock>> AddTimeClockAsync();
        Task<IList<User>> AddUsersAsync();
        Task<IList<Department>> RemoveDivisionsAsync();
        Task<IList<Payroll>> RemovePayrollAsync();
        Task<IList<TimeClock>> RemoveTimeClockAsync();
        Task<IList<User>> RemoveUsersAsync();
    }
}
