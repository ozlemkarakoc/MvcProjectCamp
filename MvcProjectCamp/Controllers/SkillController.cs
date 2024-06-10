using BusinessLayer.Concrete;
using DataAccessLayerr.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill

        SkillManager sm = new SkillManager(new EfSkillDal());

        public ActionResult Index()
        {
            var values = sm.GetList();
            return View(values);
        }
    }
}