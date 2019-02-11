using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public static class TransactionServices
    {
        public static void AddNew(Transaction transaction)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
        }

        public static ICollection<Transaction> GetAccountTransactions(int customerID, DateTime date)
        {
           using (LoyaltyDB db = new LoyaltyDB())
            {
                return db.Transactions.Where(c => c.CustomerID == customerID).Where(t => t.TransactionDate.Month == date.Month && t.TransactionDate.Year == date.Year).ToList();
            }
        }

        public static Transaction GetById(int transactionID)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                return db.Transactions.Find(transactionID);
            }
        }
    }
}
