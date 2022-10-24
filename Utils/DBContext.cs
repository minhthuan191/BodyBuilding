using BodyBuildingApp.Models;
using BodyBuildingApp.Utils.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BodyBuildingApp.Utils
{
    public class DBContext : DbContext
    {
        private IConfig Config;
        public DBContext(IConfig config)
        {
            this.Config = config;
        }

        public DbSet<Customer> Customer { set; get; }
        public DbSet<BodyStatus> BodyStatus { set; get; }
        public DbSet<DailyFood> DailyFood { set; get; }
        public DbSet<DailyPlan> DailyPlan { set; get; }
        public DbSet<Exercise> Exercise { set; get; }
        public DbSet<FoodDetail> FoodDetail { set; get; }
        public DbSet<Instruction> Instruction { set; get; }
        public DbSet<Schedule> Schedule { set; get; }
        public DbSet<Session> Session { set; get; }
        public DbSet<Target> Target { set; get; }
        public DbSet<Trainer> Trainer { set; get; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=BodyBuilderApp;User ID=sa;Password=1234567890;MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true");
            optionsBuilder.UseSqlServer("Data Source=34.88.79.255;Initial Catalog=BodyBuilderApp;User ID=sqlserver;Password=8P$,%{fkMtDA-]t3;MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true");
        }

        public static async Task<Boolean> InitDatabase(IConfig config)
        {
            var dbContext = new DBContext(config);
            bool result = await dbContext.Database.EnsureCreatedAsync();
            if (result)
            {
                Console.WriteLine("Database created");
            }

            return true;
        }
    }
}
