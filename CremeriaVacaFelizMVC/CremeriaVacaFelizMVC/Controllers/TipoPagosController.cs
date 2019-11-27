using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CremeriaVacaFelizMVC.Models;

namespace CremeriaVacaFelizMVC.Controllers
{
    public class TipoPagosController : Controller
    {
        private CremeriaModel db = new CremeriaModel();

        // GET: TipoPagos
        public ActionResult Index()
        {
            return View(db.TipoPagoes.ToList());
        }

        // GET: TipoPagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // GET: TipoPagos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,strValor,Descripcion")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                db.TipoPagoes.Add(tipoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPago);
        }

        // GET: TipoPagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: TipoPagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,strValor,Descripcion")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPago);
        }

        // GET: TipoPagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            if (tipoPago == null)
            {
                return HttpNotFound();
            }
            return View(tipoPago);
        }

        // POST: TipoPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPago tipoPago = db.TipoPagoes.Find(id);
            db.TipoPagoes.Remove(tipoPago);
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
