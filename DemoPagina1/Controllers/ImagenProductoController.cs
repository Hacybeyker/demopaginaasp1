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
    public class ImagenProductoController : Controller
    {
        private paginaweb2Entities db = new paginaweb2Entities();

        // GET: ImagenProducto
        public ActionResult Index()
        {
            var imagenproducto = db.imagenproducto.Include(i => i.producto);
            return View(imagenproducto.ToList());
        }

        // GET: ImagenProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagenproducto imagenproducto = db.imagenproducto.Find(id);
            if (imagenproducto == null)
            {
                return HttpNotFound();
            }
            return View(imagenproducto);
        }

        // GET: ImagenProducto/Create
        public ActionResult Create()
        {
            ViewBag.codigoproducto = new SelectList(db.producto, "codigoproducto", "nombreproducto");
            return View();
        }

        // POST: ImagenProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoimagenproducto,codigoproducto,direccionimagenproducto,nombreimagenproducto")] imagenproducto imagenproducto)
        {
            if (ModelState.IsValid)
            {
                db.imagenproducto.Add(imagenproducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoproducto = new SelectList(db.producto, "codigoproducto", "nombreproducto", imagenproducto.codigoproducto);
            return View(imagenproducto);
        }

        // GET: ImagenProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagenproducto imagenproducto = db.imagenproducto.Find(id);
            if (imagenproducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoproducto = new SelectList(db.producto, "codigoproducto", "nombreproducto", imagenproducto.codigoproducto);
            return View(imagenproducto);
        }

        // POST: ImagenProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoimagenproducto,codigoproducto,direccionimagenproducto,nombreimagenproducto")] imagenproducto imagenproducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagenproducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoproducto = new SelectList(db.producto, "codigoproducto", "nombreproducto", imagenproducto.codigoproducto);
            return View(imagenproducto);
        }

        // GET: ImagenProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imagenproducto imagenproducto = db.imagenproducto.Find(id);
            if (imagenproducto == null)
            {
                return HttpNotFound();
            }
            return View(imagenproducto);
        }

        // POST: ImagenProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            imagenproducto imagenproducto = db.imagenproducto.Find(id);
            db.imagenproducto.Remove(imagenproducto);
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
