using Data;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        MyFinanceContext db = new MyFinanceContext();
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Details(int BookId)
        {
            var book = db.Books.Find(BookId);
            if (book == null)
            {
               return HttpNotFound();
            }
            //get the book id
            //session assure le stockage d'une variable le temps connecté
            Session["BookId"] = BookId;

            return View(book);
        }

        public FileResult Download(string ImageName, int? id)
        {
            Book book = db.Books.Find(id);
            ImageName = book.Fichier;

            var filepath = Path.Combine(Server.MapPath("~/Uploads/"), ImageName);
            return File(filepath, MimeMapping.GetMimeMapping(filepath), ImageName);


           // return File("~/Uploads/" + ImageName, System.Net.Mime.MediaTypeNames.Application.Octet);
        }

        
            public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var mail = new MailMessage();
            var logiInfo = new NetworkCredential("nasreddine1410@gmail.com", "nasro21669940");
            mail.From = new MailAddress(contact.Email);
            mail.To.Add(new MailAddress("nasreddine1410@gmail.com"));
            mail.Subject = contact.Subject;
            mail.IsBodyHtml = true;
            string body = "Sender Name: " + contact.Name + "<br>"
                + "Email: " + contact.Email + "<br>"
                + "Title: " + contact.Subject + "<br>"
                + "Email Text: <b>" + contact.Message+"<b>";
            mail.Body = body;

            var smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = logiInfo;
            smtpClient.Send(mail);
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string SearchName)
        {
            var result = db.Books.Where(a => a.Name.Contains(SearchName)
            || a.Category.Name.Contains(SearchName)
            ||a.Description.Contains(SearchName)
            ||a.Category.CategoryDescription.Contains(SearchName)).ToList();
            return View(result);
        }
    }
}