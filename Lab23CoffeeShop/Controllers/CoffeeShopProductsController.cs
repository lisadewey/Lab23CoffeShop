using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab23CoffeeShop.Models;

namespace Lab23CoffeeShop.Controllers
{
    public class CoffeeShopProductsController : Controller
    {
        private CoffeeShopEntities db = new CoffeeShopEntities();

        // GET: CoffeeShopProducts
        public ActionResult Index()
        {
            return View(db.CoffeeShopProducts.ToList());
        }

        // GET: CoffeeShopProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeShopProduct coffeeShopProduct = db.CoffeeShopProducts.Find(id);
            if (coffeeShopProduct == null)
            {
                return HttpNotFound();
            }
            return View(coffeeShopProduct);
        }

        // GET: CoffeeShopProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeShopProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Quantity,Price")] CoffeeShopProduct coffeeShopProduct)
        {
            if (ModelState.IsValid)
            {
                db.CoffeeShopProducts.Add(coffeeShopProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coffeeShopProduct);
        }

        // GET: CoffeeShopProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeShopProduct coffeeShopProduct = db.CoffeeShopProducts.Find(id);
            if (coffeeShopProduct == null)
            {
                return HttpNotFound();
            }
            return View(coffeeShopProduct);
        }

        // POST: CoffeeShopProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Quantity,Price")] CoffeeShopProduct coffeeShopProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffeeShopProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffeeShopProduct);
        }

        // GET: CoffeeShopProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeShopProduct coffeeShopProduct = db.CoffeeShopProducts.Find(id);
            if (coffeeShopProduct == null)
            {
                return HttpNotFound();
            }
            return View(coffeeShopProduct);
        }

        // POST: CoffeeShopProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeShopProduct coffeeShopProduct = db.CoffeeShopProducts.Find(id);
            db.CoffeeShopProducts.Remove(coffeeShopProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
