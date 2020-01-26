using Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Descomentar para utilizar con bases de datos MySql
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LoyaltyDB : DbContext
    {
        //Descomentar para usar BD MySql en la nube, requiere configurar la cadena de conexion con sus datos
        //public LoyaltyDB() : base(GetConnectionString("compummc_loyaltydb", "CloudDB"))
        //{
        //    Database.SetInitializer(new LoyaltyDBInitializer());
        //}

        //Descomentar para usar BD MySql local de pruebas
        //public LoyaltyDB() : base(GetConnectionString("LoyaltyDB", "LocalDB"))
        //{
        //    Database.SetInitializer(new LoyaltyDBInitializer());
        //}

        //Descomentar para usar BD SQL Server local de pruebas
        //public LoyaltyDB() : base("MSCloudDB")
        //{
        //    //Database.SetInitializer(new LoyaltyDBInitializer());
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<LoyaltyDB, DAL.Migrations.Configuration>());
        //}

        //Descomentar para usar BD SQL Server local de pruebas
        public LoyaltyDB() : base("LoyaltyDB")
        {
            //Database.SetInitializer(new LoyaltyDBInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LoyaltyDB, DAL.Migrations.Configuration>());
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ApplicationSetting> ApplicationSettings { get; set; }

        public static string GetConnectionString(string dbName, string dbConnectionStringName)
        {
            var connString = ConfigurationManager.ConnectionStrings[dbConnectionStringName].ConnectionString.ToString();

            return String.Format(connString, dbName);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
