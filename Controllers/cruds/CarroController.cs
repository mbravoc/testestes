using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oficial3.Models;

namespace Oficial3.Controllers.cruds
{
    public class CarroController : Controller
    {
        private catalogoOficialEntities db = new catalogoOficialEntities();

        // GET: Carro
        public ActionResult IndexCarro()
        {
            return View(db.Carro.ToList());
        }

        // GET: Carro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_carro,nome_Carro")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Carro.Add(carro);
                db.SaveChanges();
                return RedirectToAction("IndexCarro");
            }

            return View(carro);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_carro,nome_Carro")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexCarro");
            }
            return View(carro);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Carro.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro carro = db.Carro.Find(id);
            db.Carro.Remove(carro);
            db.SaveChanges();
            return RedirectToAction("IndexCarro");
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
