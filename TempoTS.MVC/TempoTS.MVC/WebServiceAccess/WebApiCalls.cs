using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TempoTS.MVC.Configuration;
using TempoTS.Models.Entities;
using TempoTS.MVC.WebServiceAccess.Base;

namespace TempoTS.MVC.WebServiceAccess
{
    public class WebApiCalls : WebApiCallsBase, IWebApiCalls
    {
        public WebApiCalls(IWebServiceLocator settings) : base(settings)
        {

        }

        public Task<IList<Department>> AddDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> AddPayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> AddTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> AddUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Department>> GetDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> GetPayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> GetTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Department>> RemoveDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> RemovePayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> RemoveTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> RemoveUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Department>> UpdateDivisionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Payroll>> UpdatePayrollAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TimeClock>> UpdateTimeClockAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> UpdateUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
