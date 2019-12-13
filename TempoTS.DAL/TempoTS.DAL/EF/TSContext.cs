using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TempoTS.Models.Entities;

namespace TempoTS.DAL.EF
{
    public class TSContext : DbContext
    {
        public TSContext()
        {

        }

        public TSContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=TempoTSRemodel;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }
    }
}
