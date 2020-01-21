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
                var manager = db.Managers.Where(m => m.Login.Username == username && m.Login.Password == password).SingleOrDefault();

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
                var managerToUpdate = db.Managers.Include("Login").Where(m => m.ManagerID == manager.ManagerID).SingleOrDefault();


                managerToUpdate.Login.Username = manager.Login.Username;
                managerToUpdate.Login.Password = manager.Login.Password;

                //db.Entry(manager).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
