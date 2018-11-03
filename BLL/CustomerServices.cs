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
                    Names = Nombre,
                    Username = Usuario,
                    Password = Contrasena,
                    PaternalLastname = ApellidoPaterno,
                    Phone = Telefono,
                    CreatedDate = DateTime.Now
                });
            }
        }

        public static List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();

            using (LoyaltyDB db = new LoyaltyDB())
            {
                list = db.Customers.ToList();
            }

            return list;
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

        public static bool UsernameExists(string username)
        {
            using (LoyaltyDB db = new LoyaltyDB())
            {
                Customer customer = db.Customers.Where(u => u.Username == username).SingleOrDefault();

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
                return db.Customers.Where(x => x.Names.Contains(text) || x.PaternalLastname.Contains(text) || x.MaternalLastname.Contains(text) 
                || x.Phone.Contains(text) || x.Cellphone.Contains(text) || x.Email.Contains(text)).ToList();
            }
        }
    }
}
