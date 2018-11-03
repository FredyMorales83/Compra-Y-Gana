using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ApplicationSettingServices
    {
        public static ApplicationSetting GetDefaultApplicationSetting()
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                return db.ApplicationSettings.First();
            }            
        }

        public static void Update(ApplicationSetting setting)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                db.Entry(setting).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
