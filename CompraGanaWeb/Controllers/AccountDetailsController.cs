using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;
using Models.ViewModels;

namespace CompraGanaWeb.Controllers
{
    public class AccountDetailsController : Controller
    {
        //[Authorize]
        // GET: AccountDetails
        public ActionResult Index(int customerID)
        {
            //var customer = BLL.CustomerServices.GetAll()./*Where(c => c.CustomerID == 2).*/FirstOrDefault();
            var customer = BLL.CustomerServices.FindById(customerID);

            var customerAccount = BLL.AccountServices.GetAccountDetails(customer);

            return View(customerAccount);
        }

        // GET: AccountDetails/Details/5
        [HttpPost]
        public ActionResult TransactionDetails(int id)
        {
            var transaction = BLL.TransactionServices.GetById(id);

            var transactionViewModel = new TransactionViewModel()
            {
                Descripcion = transaction.Description,
                Fecha = transaction.TransactionDate,
                Monto = transaction.Amount.ToString(),
                Notas = transaction.Notes,
                Transaccion = transaction.TransactionCode.ToString()
            };

            return PartialView("TransactionDetails", transactionViewModel);
        }

        // GET: AccountDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountDetails/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
