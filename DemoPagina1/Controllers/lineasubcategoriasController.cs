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
    public class lineasubcategoriasController : Controller
    {
        private paginaweb2Entities db = new paginaweb2Entities();

        // GET: lineasubcategorias
        public ActionResult Index()
        {
            var lineasubcategoria = db.lineasubcategoria.Include(l => l.subcategoria);
            return View(lineasubcategoria.ToList());
        }

        // GET: lineasubcategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineasubcategoria lineasubcategoria = db.lineasubcategoria.Find(id);
            if (lineasubcategoria == null)
            {
                return HttpNotFound();
            }
            return View(lineasubcategoria);
        }

        // GET: lineasubcategorias/Create
        public ActionResult Create()
        {
            ViewBag.codigosubcategoria = new SelectList(db.subcategoria, "codigosubcategoria", "nombresubcategoria");
            return View();
        }

        // POST: lineasubcategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigolineasubcategoria,codigosubcategoria,nombrelineasubcategoria")] lineasubcategoria lineasubcategoria)
        {
            if (ModelState.IsValid)
            {
                db.lineasubcategoria.Add(lineasubcategoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigosubcategoria = new SelectList(db.subcategoria, "codigosubcategoria", "nombresubcategoria", lineasubcategoria.codigosubcategoria);
            return View(lineasubcategoria);
        }

        // GET: lineasubcategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineasubcategoria lineasubcategoria = db.lineasubcategoria.Find(id);
            if (lineasubcategoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigosubcategoria = new SelectList(db.subcategoria, "codigosubcategoria", "nombresubcategoria", lineasubcategoria.codigosubcategoria);
            return View(lineasubcategoria);
        }

        // POST: lineasubcategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigolineasubcategoria,codigosubcategoria,nombrelineasubcategoria")] lineasubcategoria lineasubcategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lineasubcategoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigosubcategoria = new SelectList(db.subcategoria, "codigosubcategoria", "nombresubcategoria", lineasubcategoria.codigosubcategoria);
            return View(lineasubcategoria);
        }

        // GET: lineasubcategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lineasubcategoria lineasubcategoria = db.lineasubcategoria.Find(id);
            if (lineasubcategoria == null)
            {
                return HttpNotFound();
            }
            return View(lineasubcategoria);
        }

        // POST: lineasubcategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lineasubcategoria lineasubcategoria = db.lineasubcategoria.Find(id);
            db.lineasubcategoria.Remove(lineasubcategoria);
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
