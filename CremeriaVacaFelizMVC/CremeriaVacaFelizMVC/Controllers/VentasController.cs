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
    public class VentasController : Controller
    {
        private CremeriaModel db = new CremeriaModel();

        // GET: Ventas
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.Cliente).Include(v => v.Empleado).Include(v => v.Producto).Include(v => v.TipoPago1);
            return View(ventas.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.CatCliente = new SelectList(db.Clientes, "Id", "Nombre");
            ViewBag.CatEmpleado = new SelectList(db.Empleados, "Id", "Nombre");
            ViewBag.CatProducto = new SelectList(db.Productos, "Id", "Nombre");
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "Id", "strValor");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroVenta,CatProducto,CatCliente,CatEmpleado,TipoPago,Cantidad,PrecioUnitario,SubTotal,Total")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatCliente = new SelectList(db.Clientes, "Id", "Nombre", venta.CatCliente);
            ViewBag.CatEmpleado = new SelectList(db.Empleados, "Id", "Nombre", venta.CatEmpleado);
            ViewBag.CatProducto = new SelectList(db.Productos, "Id", "Nombre", venta.CatProducto);
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "Id", "strValor", venta.TipoPago);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatCliente = new SelectList(db.Clientes, "Id", "Nombre", venta.CatCliente);
            ViewBag.CatEmpleado = new SelectList(db.Empleados, "Id", "Nombre", venta.CatEmpleado);
            ViewBag.CatProducto = new SelectList(db.Productos, "Id", "Nombre", venta.CatProducto);
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "Id", "strValor", venta.TipoPago);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroVenta,CatProducto,CatCliente,CatEmpleado,TipoPago,Cantidad,PrecioUnitario,SubTotal,Total")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatCliente = new SelectList(db.Clientes, "Id", "Nombre", venta.CatCliente);
            ViewBag.CatEmpleado = new SelectList(db.Empleados, "Id", "Nombre", venta.CatEmpleado);
            ViewBag.CatProducto = new SelectList(db.Productos, "Id", "Nombre", venta.CatProducto);
            ViewBag.TipoPago = new SelectList(db.TipoPagoes, "Id", "strValor", venta.TipoPago);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Ventas.Find(id);
            db.Ventas.Remove(venta);
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
