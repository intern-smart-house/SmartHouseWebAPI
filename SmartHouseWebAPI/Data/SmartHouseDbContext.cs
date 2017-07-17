using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartHouseWebAPI.Data.Models;

namespace SmartHouseWebAPI.Data
{
    public class SmartHouseDbContext : DbContext
    {
        public SmartHouseDbContext(DbContextOptions<SmartHouseDbContext> options)
        : base(options)
        { }

        public DbSet<CommandLog> CommandLogs { get; set; }
        public DbSet<TemperatureLog> TemperatureLogs { get; set; }
    }
}
