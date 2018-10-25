using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        private MyFinanceContext db = new MyFinanceContext();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Category);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Books/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Image,CategoryId")] Book book, HttpPostedFileBase upload, HttpPostedFileBase vid)
        {
            if (ModelState.IsValid)
            {
                String path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                String path2 = Path.Combine(Server.MapPath("~/Uploads"), vid.FileName);
                vid.SaveAs(path2);
                upload.SaveAs(path);
                //enregistrer path dans la BD
                book.Fichier = vid.FileName;
                book.Image = upload.FileName;
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Image,CategoryId")] Book book, HttpPostedFileBase upload, HttpPostedFileBase vid)
        {
            if (ModelState.IsValid)
            {
                String path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                String path2 = Path.Combine(Server.MapPath("~/Uploads"), vid.FileName);
                vid.SaveAs(path2);
                upload.SaveAs(path);
                //enregistrer path dans la BD
                book.Fichier = vid.FileName;
                book.Image = upload.FileName;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
