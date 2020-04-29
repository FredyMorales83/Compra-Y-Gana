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
    public static class CustomerServices
    {
        public static void AddNewCustomer(string Nombre, string ApellidoPaterno, string ApellidoMaterno, string Direccion, string Telefono, 
            string Celular, string Correo, string Usuario, string Contrasena)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                db.Customers.Add(new Customer
                {
                    Address = Direccion,
                    Cellphone = Celular,
                    Email = Correo,
                    MaternalLastname = ApellidoMaterno,
                    Name = Nombre,
                    PaternalLastname = ApellidoPaterno,
                    Phone = Telefono,
                    CreatedDate = DateTime.Now,
                    Login = new Login { Username = Usuario, Password = Contrasena }
                });
            }
        }

        public static List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();

            using (LoyaltyDB db = new LoyaltyDB())
            {
                list = db.Customers.Include("Login").ToList();
            }

            return list;
        }

        public static Customer GetCustomerLogin(string username, string password)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                var customer = db.Customers.Include("Login").Where(m => m.Login.Username == username).SingleOrDefault();

                if (customer != null)
                {
                    var managerPasswordDecrypted = RegexUtilities.PasswordDecrypt(customer.Login.Password);

                    if (managerPasswordDecrypted == password)
                    {
                        return customer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public static void AddNew(Customer customer)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public static void Update(Customer customer)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                customer.ModifiedDate = DateTime.Now;
                var newPassword = RegexUtilities.PasswordEncrypt(customer.Login.Password);
                LoginServices.UpdateEntityLogin(customer.Login.LoginId, newPassword);
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public static Customer FindById(int id)
        {
            Customer customer = null;

            using (LoyaltyDB db = new LoyaltyDB())
            {
                customer = db.Customers.Find(id);

                if (customer != null)
                {
                    return customer;
                }
            }

            return null;
        }

        public static Customer GetCustomerById(int customerID)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                Customer customer = db.Customers.Include("Login").Where(m => m.CustomerID == customerID).SingleOrDefault();

                if (customer != null)
                {
                    return customer;
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool UsernameExists(string username)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                Customer customer = db.Customers.Where(u => u.Login.Username == username).SingleOrDefault();

                if (customer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool NicknameExists(string nickname)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                var customer = db.Customers.Where(u => u.Nickname == nickname).SingleOrDefault();

                if (customer != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<Customer> FindByCustomerData(string text)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                return db.Customers.Where(x => x.Name.Contains(text) || x.PaternalLastname.Contains(text) || x.MaternalLastname.Contains(text) 
                || x.Phone.Contains(text) || x.Cellphone.Contains(text) || x.Email.Contains(text) || x.Nickname.Contains(text)).ToList();
            }
        }
    }
}
