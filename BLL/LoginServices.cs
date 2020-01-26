using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class LoginServices
    {
        public static void UpdateEntityLogin(int Id, string newPassword)
        {
            using (var db = new LoyaltyDB())
            {
                var loginToUpdate = db.Logins.Find(Id);

                loginToUpdate.Password = newPassword;

                db.SaveChanges();
            }
        }
    }
}
