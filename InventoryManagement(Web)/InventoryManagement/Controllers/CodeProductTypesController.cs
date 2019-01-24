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
    public class CodeProductTypesController : Controller
    {
        InventoryDbContext db = new InventoryDbContext();
        // GET: CodeProductTypes
        public ActionResult Index()
        {
            return View(db.CodeProductTypes.ToList());
        }
        [HttpPost]
        public ActionResult Create(CodeProductTypes codeProductTypes)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.CodeProductTypes.Add(codeProductTypes);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.CodeProductTypes.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var ProductType = db.CodeProductTypes.Where(x => x.Id == Id).FirstOrDefault();
            db.CodeProductTypes.Remove(ProductType);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductType(int id)
        {
            CodeProductTypes data = new CodeProductTypes();
            var getProductType = db.CodeProductTypes.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getProductType.Id;
            data.ProductTypesName = getProductType.ProductTypesName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateProductType(CodeProductTypes model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }


    }
}