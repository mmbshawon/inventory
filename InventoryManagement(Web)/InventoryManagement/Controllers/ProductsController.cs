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
    public class ProductsController : Controller
    {
        private InventoryDbContext db = new InventoryDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.CodeCares).Include(p => p.CodeColors).Include(p => p.CodeFabrics).Include(p => p.CodeFits).Include(p => p.CodeProductGroups).Include(p => p.CodeProductTypes).Include(p => p.CodeSeasons).Include(p => p.ProductSizes);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CodeCaresId = new SelectList(db.CodeCares, "Id", "CaresName");
            ViewBag.CodeColorsId = new SelectList(db.CodeColors, "Id", "ColorsName");
            ViewBag.CodeFabricsId = new SelectList(db.CodeFabrics, "Id", "FabricsName");
            ViewBag.CodeFitsId = new SelectList(db.CodeFits, "Id", "FitsName");
            ViewBag.CodeProductGroupsId = new SelectList(db.CodeProductGroups, "Id", "ProductGroupsName");
            ViewBag.CodeProductTypesId = new SelectList(db.CodeProductTypes, "Id", "ProductTypesName");
            ViewBag.CodeSeasonsId = new SelectList(db.CodeSeasons, "Id", "SeasonsName");
            ViewBag.ProductSizesId = new SelectList(db.ProductSizes, "Id", "SizesName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StyleName,Dpp,Dsp,ProductQuantity,CodeSeasonsId,CodeProductGroupsId,CodeProductTypesId,CodeFabricsId,CodeFitsId,CodeCaresId,CodeColorsId,ProductSizesId")] Products products)
        {
            if (db.Products.Any(x => x.StyleName == products.StyleName))
            {
                ModelState.AddModelError("StyleName", "Style already in a stock");
            }
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodeCaresId = new SelectList(db.CodeCares, "Id", "CaresName", products.CodeCaresId);
            ViewBag.CodeColorsId = new SelectList(db.CodeColors, "Id", "ColorsName", products.CodeColorsId);
            ViewBag.CodeFabricsId = new SelectList(db.CodeFabrics, "Id", "FabricsName", products.CodeFabricsId);
            ViewBag.CodeFitsId = new SelectList(db.CodeFits, "Id", "FitsName", products.CodeFitsId);
            ViewBag.CodeProductGroupsId = new SelectList(db.CodeProductGroups, "Id", "ProductGroupsName", products.CodeProductGroupsId);
            ViewBag.CodeProductTypesId = new SelectList(db.CodeProductTypes, "Id", "ProductTypesName", products.CodeProductTypesId);
            ViewBag.CodeSeasonsId = new SelectList(db.CodeSeasons, "Id", "SeasonsName", products.CodeSeasonsId);
            ViewBag.ProductSizesId = new SelectList(db.ProductSizes, "Id", "SizesName", products.ProductSizesId);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodeCaresId = new SelectList(db.CodeCares, "Id", "CaresName", products.CodeCaresId);
            ViewBag.CodeColorsId = new SelectList(db.CodeColors, "Id", "ColorsName", products.CodeColorsId);
            ViewBag.CodeFabricsId = new SelectList(db.CodeFabrics, "Id", "FabricsName", products.CodeFabricsId);
            ViewBag.CodeFitsId = new SelectList(db.CodeFits, "Id", "FitsName", products.CodeFitsId);
            ViewBag.CodeProductGroupsId = new SelectList(db.CodeProductGroups, "Id", "ProductGroupsName", products.CodeProductGroupsId);
            ViewBag.CodeProductTypesId = new SelectList(db.CodeProductTypes, "Id", "ProductTypesName", products.CodeProductTypesId);
            ViewBag.CodeSeasonsId = new SelectList(db.CodeSeasons, "Id", "SeasonsName", products.CodeSeasonsId);
            ViewBag.ProductSizesId = new SelectList(db.ProductSizes, "Id", "SizesName", products.ProductSizesId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StyleName,Dpp,Dsp,ProductQuantity,CodeSeasonsId,CodeProductGroupsId,CodeProductTypesId,CodeFabricsId,CodeFitsId,CodeCaresId,CodeColorsId,ProductSizesId")] Products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodeCaresId = new SelectList(db.CodeCares, "Id", "CaresName", products.CodeCaresId);
            ViewBag.CodeColorsId = new SelectList(db.CodeColors, "Id", "ColorsName", products.CodeColorsId);
            ViewBag.CodeFabricsId = new SelectList(db.CodeFabrics, "Id", "FabricsName", products.CodeFabricsId);
            ViewBag.CodeFitsId = new SelectList(db.CodeFits, "Id", "FitsName", products.CodeFitsId);
            ViewBag.CodeProductGroupsId = new SelectList(db.CodeProductGroups, "Id", "ProductGroupsName", products.CodeProductGroupsId);
            ViewBag.CodeProductTypesId = new SelectList(db.CodeProductTypes, "Id", "ProductTypesName", products.CodeProductTypesId);
            ViewBag.CodeSeasonsId = new SelectList(db.CodeSeasons, "Id", "SeasonsName", products.CodeSeasonsId);
            ViewBag.ProductSizesId = new SelectList(db.ProductSizes, "Id", "SizesName", products.ProductSizesId);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
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
