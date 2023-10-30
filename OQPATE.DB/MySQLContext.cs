using Microsoft.EntityFrameworkCore;
using OQPATE.DB.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace OQPATE.DB
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options)
            : base(options){ }

        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<CountryStates> CountryStates { get; set; } 
        public DbSet<JobServices> JobServices { get; set; } 
        public DbSet<ServiceCategory> ServiceCategories { get; set; }   
        public DbSet<Users> Users { get; set; } 
        public DbSet<EraseResults> EraseResults { get; set; }
        public DbSet<TicketProcess> TicketProcesses { get; set; }
        public DbSet<TestResults> TestResults { get; set; }


       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var MySQLVersion = new Version(8,4,27);
            var serverVersion = new MySqlServerVersion(MySQLVersion);
        }
    }
}