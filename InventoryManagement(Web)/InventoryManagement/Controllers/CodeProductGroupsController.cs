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
    public class CodeProductGroupsController : Controller
    {
        InventoryDbContext db = new InventoryDbContext();
        // GET: CodeProductGroups
        public ActionResult Index()
        {
            return View(db.CodeProductGroups.ToList());
        }
        [HttpPost]
        public ActionResult Create(CodeProductGroups codeProductGroups)
        {
            string message = "Saved Successfully";
            bool status = true;
            db.CodeProductGroups.Add(codeProductGroups);
            db.SaveChanges();
            return Json(new { status = status, message = message, id = db.CodeProductGroups.Max(x => x.Id) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            var productGroup = db.CodeProductGroups.Where(x => x.Id == Id).FirstOrDefault();
            db.CodeProductGroups.Remove(productGroup);
            db.SaveChanges();
            string message = "Reocord has been deleted successfully.";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductGroup(int id)
        {
            CodeProductGroups data = new CodeProductGroups();
            var getProductGroup = db.CodeProductGroups.Where(x => x.Id == id).FirstOrDefault();
            data.Id = getProductGroup.Id;
            data.ProductGroupsName = getProductGroup.ProductGroupsName;
            return Json(new { success = true, data = data }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateProductGroup(CodeProductGroups model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            string message = "Recored has been updated seccesfully";
            bool status = true;
            return Json(new { status = status, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}