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
    public class CodeCaresController : Controller
    {
        InventoryDbContext db = new InventoryDbContext();
        // GET: CodeCares
        public ActionResult Index()
        {
            return View(db.CodeCares.ToList());
        }

        [HttpPost]
        public ActionResult Create(CodeCares codeCares)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.CodeCares.Add(codeCares);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.CodeCares.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var cares = db.CodeCares.Where(x => x.Id == Id).FirstOrDefault();
            db.CodeCares.Remove(cares);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCare(int id)
        {
            CodeCares data = new CodeCares();
            var getCare = db.CodeCares.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getCare.Id;
            data.CaresName = getCare.CaresName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateCare(CodeCares model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}