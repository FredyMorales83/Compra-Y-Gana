using AuxiliarUtilities;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class ManagerServices
    {
        public static Manager GetManagerLogin(string username, string password)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                var manager = db.Managers.Include("Login").Where(m => m.Login.Username == username).SingleOrDefault();

                var managerPasswordDecrypted = RegexUtilities.PasswordDecrypt(manager.Login.Password);

                if (managerPasswordDecrypted == password)
                {
                    return manager;
                }
                else
                {
                    return null;
                }
            }
        }

        public static Manager GetManagerById(int managerLoguedID)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                Manager manager = db.Managers.Include("Login").Where(m => m.ManagerID == managerLoguedID).SingleOrDefault();

                if (manager != null)
                {
                    return manager;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void Update(Manager manager)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {                
                var newPassword = RegexUtilities.PasswordEncrypt(manager.Login.Password);
                LoginServices.UpdateEntityLogin(manager.Login.LoginId, newPassword);
                db.Entry<Manager>(manager).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
