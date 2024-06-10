using BusinessLayer.Concrete;
using DataAccessLayerr.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization

        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> role = (from x in adm.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.AdminRole,
                                             Value = x.AdminRole
                                         }).ToList();
            ViewBag.role = role;
            var adminvalue = adm.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            p.AdminStatus = true;
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var values = adm.GetByID(id);
            if (values.AdminStatus == true)
            {
                values.AdminStatus = false;
            }
            else if (values.AdminStatus == false)
            {
                values.AdminStatus = true;
            }

            adm.AdminUpdate(values);

            return RedirectToAction("Index");

        }
    }
}