using BusinessLayer.Concrete;
using DataAccessLayerr.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent

        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {
            var contentValues = cm.GetListByWriter();
            return View(contentValues);
        }
    }
}