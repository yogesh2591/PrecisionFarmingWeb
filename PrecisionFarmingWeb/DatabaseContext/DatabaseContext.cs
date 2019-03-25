using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrecisionFarmingWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PrecisionFarmingWeb.Models

{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Site> SITES { get; set; }
        public virtual DbSet<GpsSensor> GPS_SENSOR { get; set; }
        public virtual DbSet<GpsSensorData> GPS_SENSOR_DATA { get; set; }
        public virtual DbSet<PhSensor> PH_SENSOR { get; set; }
        public virtual DbSet<PhSensorData> PH_SENSOR_DATA { get; set; }
        public virtual DbSet<TempAndHumiditySensor> TEMP_HUMIDITY_SENSOR { get; set; }
        public virtual DbSet<TempAndHumiditySensorData> TEMP_HUMIDITY_SENSOR_DATA { get; set; }
        public virtual DbSet<Users> USERS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
