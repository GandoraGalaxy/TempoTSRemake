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
    public class TimeClockRepo : RepoBase<TimeClock>
    {
        public TimeClockRepo(DbContextOptions<TSContext> options) : base(options)
        {

        }
        public TimeClockRepo()
        {

        }

        public override IEnumerable<TimeClock> GetAll()
            => Table.OrderBy(x => x.Id);

        public override IEnumerable<TimeClock> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.Id), skip, take);
    }
}
