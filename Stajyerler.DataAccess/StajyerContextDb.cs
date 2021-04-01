using Microsoft.EntityFrameworkCore;
using Stajyerler.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stajyerler.DataAccess
{
    public class StajyerContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-5H47J03\\LYNXSQL; Database=InternDb;uid=sa ;pwd=123123");
        }

        public DbSet<Stajyer> Stajyers { get; set; }
    }
}
