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
    public class DepartmentRepo : RepoBase<Department>
    {
        public DepartmentRepo(DbContextOptions<TSContext> options) : base(options)
        {

        }
        public DepartmentRepo()
        {

        }

        public override IEnumerable<Department> GetAll()
            => Table.OrderBy(x => x.Id);

        public override IEnumerable<Department> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.Id), skip, take);


    }
}
