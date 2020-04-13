using DAL;
using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static AccountDetailsViewModel GetAccountDetails(Customer customer)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                var account = db.Accounts.Include("Transactions").Where(a => a.CustomerID == customer.CustomerID).FirstOrDefault();

                var customerAccountDetails = new AccountDetailsViewModel
                {
                    CustomerFullname = customer.ToString(),
                    AccountNumber = account.CustomerID.ToString(),
                    Email = customer.Email,
                    Address = customer.Address,
                    ActualPeriod = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month),
                    Transactions = account.Transactions,
                    AccumulatedPoints = account.CurrentPointsBalance,
                    CashEquivalent = account.CurrentMoneyBalance
                };

                return customerAccountDetails;
            }            
        }
    }
}
