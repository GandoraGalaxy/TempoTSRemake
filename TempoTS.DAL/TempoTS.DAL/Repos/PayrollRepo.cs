using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempoTS.DAL.EF;
using TempoTS.DAL.Repos.Base;
using TempoTS.Models.Entities;

namespace TempoTS.DAL.Repos
{
    public class PayrollRepo : RepoBase<Payroll>
    {
        public PayrollRepo(DbContextOptions<TSContext> options) : base(options)
        {

        }
        public PayrollRepo()
        {

        }

        public override IEnumerable<Payroll> GetAll()
            => Table.OrderBy(x => x.Id);

        public override IEnumerable<Payroll> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.Id), skip, take);
    }
}
