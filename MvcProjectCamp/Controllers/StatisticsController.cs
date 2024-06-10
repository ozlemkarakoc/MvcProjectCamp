using BusinessLayer.Concrete;
using DataAccessLayerr.Concrete;
using DataAccessLayerr.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        Context c = new Context();
        
        public ActionResult Index()
        {
            ViewBag.totalcategory = cm.GetList().Count();
            ViewBag.totalwriter = wm.GetList().Count();
            ViewBag.Sinema = hm.GetList().Where(x => x.CategoryID == 5).Count();
            ViewBag.writerNameA = wm.GetList().Where(x => x.WriterName.ToLower().Contains("a")).Count();
            ViewBag.maxHeaderCategory = c.Categories.OrderByDescending(c => c.Headings.Count()).Select(x => x.CategoryName).FirstOrDefault();

            ViewBag.differenceTrueFalse = cm.GetList().Where(x => x.CategoryStatus == true).Count() - cm.GetList().Where(x => x.CategoryStatus == false).Count();
            return View();
        }
    }
}