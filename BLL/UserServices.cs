using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class UserServices
    {
        public static User GetUserLogin(string username, string password)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                User user = db.Users.Where(u => u.Username == username && u.Password == password).SingleOrDefault();

                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public static User GetUserById(int userLoguedID)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                User user = db.Users.Find(userLoguedID);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void Update(User user)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
