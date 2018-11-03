using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class AccountServices
    {
        public static void NewAccount(Account account)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public static decimal GetCurrentPointsBalance(int CustomerID)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                var CurrentPointBalance = db.Accounts.Where(c => c.CustomerID == CustomerID).Select(p => p.CurrentPointsBalance).SingleOrDefault();

                return CurrentPointBalance;
            }
        }

        public static void UpdateCurrentPointsBalance(Account account, decimal points)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                account.ModifiedDate = DateTime.Now;
                account.CurrentPointsBalance += points;
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static Account FindById(int customerID)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                var account = db.Accounts.Find(customerID);

                return account;
            }
        }

        public static void Withdraw(Account account, decimal amountOfPointsToWithdraw)
        {
            decimal currentPointsBalance = GetCurrentPointsBalance(account.CustomerID);

            if (currentPointsBalance >= amountOfPointsToWithdraw)
            {
                UpdateCurrentPointsBalance(account, -amountOfPointsToWithdraw);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Monto Gasto/Retiro", "El monto que ingresaste excede el saldo disponible de esta cuenta. Por favor, ingresa un monto menor e inténtalo nuevamente. (CE83721)");
            }
        }

        public static void Deposit(Account account, decimal amountOfPointsToDeposit)
        {
            UpdateCurrentPointsBalance(account, amountOfPointsToDeposit);
        }
    }
}
