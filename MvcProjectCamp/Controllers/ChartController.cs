using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);

            List<CategoryClass> BlogList()
            {
                List<CategoryClass> cat = new List<CategoryClass>();
                cat.Add(new CategoryClass()
                {
                    CategoryName = "Yazılım",
                    CategoryCount = 8
                });

                cat.Add(new CategoryClass()
                {
                    CategoryName = "Seyahat",
                    CategoryCount = 4
                });
                cat.Add(new CategoryClass()
                {
                    CategoryName = "Teknoloji",
                    CategoryCount = 7
                });

                cat.Add(new CategoryClass()
                {
                    CategoryName = "Spor",
                    CategoryCount = 1
                });
                return cat;
            }

        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult WriterContentChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);

            List<WriterContentClass> BlogList()
            {
                List<WriterContentClass> cat = new List<WriterContentClass>();
                cat.Add(new WriterContentClass()
                {
                    WriterName = "Ahmet Yıldız",
                    WriterContentCount = 8
                });

                cat.Add(new WriterContentClass()
                {
                    WriterName = "Emel Öztürk",
                    WriterContentCount = 4
                });
                cat.Add(new WriterContentClass()
                {
                    WriterName = "Gizem Yıldız",
                    WriterContentCount = 7
                });

                cat.Add(new WriterContentClass()
                {
                    WriterName = "Eda Erdem",
                    WriterContentCount = 10
                });
                return cat;
            }

        }
    }
}