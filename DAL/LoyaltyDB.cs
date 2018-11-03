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
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class LoyaltyDB : DbContext
    {
        //public LoyaltyDB() : base(GetConnectionString("compummc_loyaltydb", "CloudDB"))//Descomentar para usar BD en la nube
        //{
        //    Database.SetInitializer(new LoyaltyDBInitializer());
        //}

        public LoyaltyDB() : base(GetConnectionString("LoyaltyDB", "LocalDB"))//Descomentar para usar BD local de pruebas
        {
            Database.SetInitializer(new LoyaltyDBInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
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
