using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoAPI.Helpers;
using todoAPI.Models;

namespace todoAPI.Context
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskItem> tasks { get; set; }
        public DbSet<Priority> priorities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=braintly-db.cdauuadcsjn9.us-west-2.rds.amazonaws.com;user=ticGLF4df7;password=ticGLF4df7;port=3306;database=braintly_db_ticGLF4df7",
                new MySqlServerVersion(new Version(8, 0, 28))
            );
        }
    }
}
