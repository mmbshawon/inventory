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
    public class CodeFitsController : Controller
    {
        InventoryDbContext db = new InventoryDbContext();
        // GET: CodeFits
        public ActionResult Index()
        {
            return View(db.CodeFits.ToList());
        }
        [HttpPost]
        public ActionResult Create(CodeFits codeFits)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.CodeFits.Add(codeFits);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.CodeFits.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var fit = db.CodeFits.Where(x => x.Id == Id).FirstOrDefault();
            db.CodeFits.Remove(fit);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFit(int id)
        {
            CodeFits data = new CodeFits();
            var getFit = db.CodeFits.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getFit.Id;
            data.FitsName = getFit.FitsName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateFit(CodeFits model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}