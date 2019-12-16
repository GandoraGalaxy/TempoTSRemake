using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempoTS.DAL.EF;
using Microsoft.Extensions.DependencyInjection;

namespace TempoTS.DAL.Initilizers
{
    public class TSDataInitializer
    {
        public static void InitializeData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<TSContext>();
            InitializeData(context);
        }
        public static void InitializeData(TSContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }
        public static void ClearData(TSContext context)
        {
            ExecuteDeleteSQL(context, "TimeClock");
            ExecuteDeleteSQL(context, "Users");
            ResetIdentity(context);
        }
        public static void ExecuteDeleteSQL(TSContext context, string tableName)
        {
            var sql = $"Delete from TimeSheet.{tableName}";
            context.Database.ExecuteSqlCommand(sql);
        }
        public static void ResetIdentity(TSContext context)
        {
            var tables = new[] { "Divisions", "Users", "Payroll", "Role", "TimeClock" };
            foreach (var itm in tables)
            {
                var sql = $"DBCC CHECKIDENT (\"TimeSheet.{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlCommand(sql);
            }
        }

        public static void SeedData(TSContext context)
        {
            try
            {
                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(TSSampleData.GetDepartment());
                    context.SaveChanges();
                }
                if (!context.TimeClocks.Any())
                {
                    context.TimeClocks.AddRange(TSSampleData.GetTime());
                    context.SaveChanges();
                }
                if (!context.Payrolls.Any())
                {
                    context.Payrolls.AddRange(TSSampleData.GetPayroll());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
