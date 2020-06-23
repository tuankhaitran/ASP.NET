using EccomerceWeb.DataAccess;
using EccomerceWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EccomerceWeb.Controllers
{
    public class ProductController : Controller
    {

        private TrendUpProductDbContext db = new TrendUpProductDbContext();
        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);

        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    using (var context = new TrendUpProductDbContext())
                    {
                        context.Products.Add(product);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");

                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
