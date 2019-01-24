using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvemtoryManagement.DatabaseContext;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class ProductStocksController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: ProductStocks
        public ActionResult Index()
        {
            var productStocks = db.ProductStocks.Include(p => p.Products);
            return View(productStocks.ToList());
        }

        // GET: ProductStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStock productStock = db.ProductStocks.Find(id);
            if (productStock == null)
            {
                return HttpNotFound();
            }
            return View(productStock);
        }

        // GET: ProductStocks/Create
        public ActionResult Create()
        {
            ViewBag.ProductsId = new SelectList(db.Products, "Id", "StyleName");
            return View();
        }

        // POST: ProductStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SSize,MSize,LSizw,XlSizw,XxlSize,ProductsId")] ProductStock productStock)
        {
            if (db.ProductStocks.Any(x => x.ProductsId == productStock.ProductsId))
            {
                ModelState.AddModelError("ProductsId", "Style already in a stock");
            }
            if (ModelState.IsValid)
            {
                db.ProductStocks.Add(productStock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductsId = new SelectList(db.Products, "Id", "StyleName", productStock.ProductsId);
            return View(productStock);
        }

        // GET: ProductStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStock productStock = db.ProductStocks.Find(id);
            if (productStock == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductsId = new SelectList(db.Products, "Id", "StyleName", productStock.ProductsId);
            return View(productStock);
        }

        // POST: ProductStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SSize,MSize,LSizw,XlSizw,XxlSize,ProductsId")] ProductStock productStock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productStock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductsId = new SelectList(db.Products, "Id", "StyleName", productStock.ProductsId);
            return View(productStock);
        }

        // GET: ProductStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStock productStock = db.ProductStocks.Find(id);
            if (productStock == null)
            {
                return HttpNotFound();
            }
            return View(productStock);
        }

        // POST: ProductStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductStock productStock = db.ProductStocks.Find(id);
            db.ProductStocks.Remove(productStock);
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
