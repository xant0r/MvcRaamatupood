using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcRaamatupood.Models;

namespace MvcRaamatupood.Controllers
{
    public class RaamatupoodsController : Controller
    {
        private RaamatupoodDBContext db = new RaamatupoodDBContext();

        public ActionResult Index(string raamatupoodAutor, string searchString)
        {
            var AutorLst = new List<string>();

            var AutorQry = from d in db.Raamatupood
                           orderby d.Autor
                           select d.Autor;

            AutorLst.AddRange(AutorQry.Distinct());
            ViewBag.raamatupoodAutor = new SelectList(AutorLst);

            var raamatupood = from r in db.Raamatupood
                         select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                raamatupood = raamatupood.Where(s => s.Pealkiri.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(raamatupoodAutor))
            {
                raamatupood = raamatupood.Where(x => x.Autor == raamatupoodAutor);
            }

            return View(raamatupood);
        }

        // GET: Raamatupoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raamatupood raamatupood = db.Raamatupood.Find(id);
            if (raamatupood == null)
            {
                return HttpNotFound();
            }
            return View(raamatupood);
        }

        // GET: Raamatupoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raamatupoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Pealkiri,Autor,IlmumisAasta,Kirjastus,Hind")] Raamatupood raamatupood)
        {
            if (ModelState.IsValid)
            {
                db.Raamatupood.Add(raamatupood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raamatupood);
        }

        // GET: Raamatupoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raamatupood raamatupood = db.Raamatupood.Find(id);
            if (raamatupood == null)
            {
                return HttpNotFound();
            }
            return View(raamatupood);
        }

        // POST: Raamatupoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Pealkiri,Autor,IlmumisAasta,Kirjastus,Hind")] Raamatupood raamatupood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raamatupood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raamatupood);
        }

        // GET: Raamatupoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raamatupood raamatupood = db.Raamatupood.Find(id);
            if (raamatupood == null)
            {
                return HttpNotFound();
            }
            return View(raamatupood);
        }

        // POST: Raamatupoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raamatupood raamatupood = db.Raamatupood.Find(id);
            db.Raamatupood.Remove(raamatupood);
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
