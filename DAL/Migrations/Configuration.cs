namespace DAL.Migrations
{
    using AuxiliarUtilities;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.LoyaltyDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DAL.LoyaltyDB";
        }

        protected override void Seed(DAL.LoyaltyDB db)
        {
            if (db.Managers.Count() == 0)
            {
                Manager manager = new Manager
                {
                    Nickname = "Admistrador predeterminado",
                    Email = "correo@dominio.com",
                    Name = "Administrador",
                    PaternalLastname = "Predeterminado",
                    Login = new Login { Username = "admin", Password = RegexUtilities.PasswordEncrypt("1234") }
                };

                db.Managers.Add(manager);
                db.SaveChanges();

                ApplicationSetting setting = new ApplicationSetting
                {
                    BusinessName = "Empresa predeterminada",
                    BusinessAnniversary = new DateTime(1900, 1, 1),
                    RewardDoublePointsOnBusinessAnniversary = false,
                    RewardDoublePointsOnCustomerAnniversary = false,
                    AllowCashRequest = true,
                    PercentagePoints = 10,
                    PointValueCash = 0.1m
                };

                db.ApplicationSettings.Add(setting);
                db.SaveChanges(); 
            }
        }
    }
}
