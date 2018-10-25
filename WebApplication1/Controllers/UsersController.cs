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
using Service;

namespace WebApplication1.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private MyFinanceContext ctx = new MyFinanceContext();
        UserService Us = new UserService();
        // GET: User
        public ActionResult Index()
        {
            return View(Us.GetAllUsers().ToList());
        }
        [AllowAnonymous]
        public ActionResult Create()
        {



            return View();
        }

        [AllowAnonymous]
        // POST: User/Create
        //httppostedfilebase pour inscrire une image,le nom doit etre le meme que le name in input
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User u, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                //~ pour aller a root directory
                //2 ligne a u dessus pour enregistrer l'image dans le serveur
                String path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                //enregistrer path dans la BD
                u.Image = upload.FileName;
                Us.Add(u);
                return RedirectToAction("Index");
            }


            return View(u);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User u = Us.GetUserById(id);
            if (u == null)
            {
                return HttpNotFound();
            }
            return View(u);
        }

        // GET: User/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User u = Us.GetUserById(id);
            if (u == null)
            {
                return HttpNotFound();
            }
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            User u = Us.GetUserById(id);
            Us.Delete(u);
            return RedirectToAction("Index");
        }

        // GET: User/Update/id
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User u = Us.GetUserById(id);
            if (u == null)
            {
                return HttpNotFound();
            }
            return View(u);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(User u, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                String path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                //enregistrer path dans la BD
                u.Image = upload.FileName;
                Us.Update(u);
                return RedirectToAction("Index");
            }
            return View(u);
        }


        public ActionResult Search()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Search(String SearchName)
        {
            var result = ctx.Users.Where(a => a.FirstName.Contains(SearchName) || a.LastName.Contains(SearchName)).ToList();
            return View(result);
        }

    }
}
