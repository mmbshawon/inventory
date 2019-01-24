using InvemtoryManagement.DatabaseContext;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class ProductSizesController : Controller
    {
       InventoryDbContext db = new InventoryDbContext();
        // GET: ProductSizes
        public ActionResult Index()
        {
            return View(db.ProductSizes.ToList());
        }

        [HttpPost]
        public ActionResult Create(ProductSizes productSizes)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.ProductSizes.Add(productSizes);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.ProductSizes.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var size = db.ProductSizes.Where(x => x.Id == Id).FirstOrDefault();
            db.ProductSizes.Remove(size);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSize(int id)
        {
            ProductSizes data = new ProductSizes();
            var getSize = db.ProductSizes.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getSize.Id;
            data.SizesName = getSize.SizesName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateSize(ProductSizes model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}