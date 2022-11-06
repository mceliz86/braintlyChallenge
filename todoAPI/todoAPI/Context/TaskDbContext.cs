using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoAPI.Helpers;
using todoAPI.Entities;

namespace todoAPI.Context
{
    public class TaskDbContext : DbContext
    {
        private readonly IOptions<RDSConnectionString> _rdsConfig;

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        public TaskDbContext(IOptions<RDSConnectionString> rdsConfig)
        {
            _rdsConfig = rdsConfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"server={_rdsConfig.Value.Server}; user={_rdsConfig.Value.User}; password={_rdsConfig.Value.Password} ;port={_rdsConfig.Value.Port}; database={_rdsConfig.Value.Database}",
                new MySqlServerVersion(new Version(8, 0, 28))
            );
        }
    }
}
