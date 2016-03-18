using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoPagina1.Models;

namespace DemoPagina1.Controllers
{
    public class SubCategoriaController : Controller
    {
        private paginaweb2Entities db = new paginaweb2Entities();

        // GET: SubCategoria
        public ActionResult Index()
        {
            var subcategoria = db.subcategoria.Include(s => s.categoria);
            return View(subcategoria.ToList());
        }

        // GET: SubCategoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategoria.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        // GET: SubCategoria/Create
        public ActionResult Create()
        {
            ViewBag.codigocategoria = new SelectList(db.categoria, "codigocategoria", "nombrecategoria");
            return View();
        }

        // POST: SubCategoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigosubcategoria,codigocategoria,nombresubcategoria")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.subcategoria.Add(subcategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigocategoria = new SelectList(db.categoria, "codigocategoria", "nombrecategoria", subcategoria.codigocategoria);
            return View(subcategoria);
        }

        // GET: SubCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategoria.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigocategoria = new SelectList(db.categoria, "codigocategoria", "nombrecategoria", subcategoria.codigocategoria);
            return View(subcategoria);
        }

        // POST: SubCategoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigosubcategoria,codigocategoria,nombresubcategoria")] subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigocategoria = new SelectList(db.categoria, "codigocategoria", "nombrecategoria", subcategoria.codigocategoria);
            return View(subcategoria);
        }

        // GET: SubCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoria subcategoria = db.subcategoria.Find(id);
            if (subcategoria == null)
            {
                return HttpNotFound();
            }
            return View(subcategoria);
        }

        // POST: SubCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subcategoria subcategoria = db.subcategoria.Find(id);
            db.subcategoria.Remove(subcategoria);
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
