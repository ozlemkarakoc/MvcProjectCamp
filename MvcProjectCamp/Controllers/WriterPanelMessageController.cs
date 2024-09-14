using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayerr.Concrete;
using DataAccessLayerr.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {

        MessageManager mm = new MessageManager(new EfMessageDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var writermailinfo = wm.GetList().Where(x => x.WriterMail == p).Select(x => x.WriterMail).FirstOrDefault();
            var values = mm.GetListInbox(writermailinfo).OrderByDescending(x => x.MessageID).Where(x => x.ReceiverMail == writermailinfo).ToList();
            //var messagelist = mm.GetListInbox(p);
            return View(values);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public PartialViewResult MessageListMenu()
        {
            //string p = (string)Session["WriterMail"];
            //var writermailinfo = wm.GetList().Where(x => x.WriterMail == p).Select(x => x.WriterMail).FirstOrDefault();
            //ViewBag.inboxnumber = mm.GetListInbox().Where(x => x.ReceiverMail == writermailinfo).Count(x => x.IsRead == false);
            //return PartialView();


            string p = (string)Session["WriterMail"];
            if (p == null)
            {

                ViewBag.inboxnumber = 0;
                return PartialView();
            }

            var writermailinfo = wm.GetList().FirstOrDefault(x => x.WriterMail == p)?.WriterMail;
            if (writermailinfo == null)
            {

                ViewBag.inboxnumber = 0;
                return PartialView();
            }


            var messages = mm.GetListInbox(writermailinfo);
            int unreadMessagesCount = messages.Count(x => !x.IsRead);

            System.Diagnostics.Debug.WriteLine($"WriterMail: {writermailinfo}");
            System.Diagnostics.Debug.WriteLine($"Total Messages Count: {messages.Count}");
            foreach (var message in messages)
            {
                System.Diagnostics.Debug.WriteLine($"Message ID: {message.MessageID}, IsRead: {message.IsRead}, ReceiverMail: {message.ReceiverMail}");
            }
            System.Diagnostics.Debug.WriteLine($"Unread Messages Count: {unreadMessagesCount}");

            ViewBag.inboxnumber = unreadMessagesCount;
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString().ToString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
    }
}