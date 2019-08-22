using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Oficial3.Models;

namespace Oficial3.Controllers.cruds
{
    public class PecasController : Controller
    {
        private catalogoOficialEntities db = new catalogoOficialEntities();

        // GET: Pecas
        public ActionResult IndexPecas()
        {
            var pecas = db.PecasInfo.Include(p => p.Tipo1);
            return View(pecas.ToList());
        }

        // GET: Pecas/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecas pecas = db.PecasInfo.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            return View(pecas);
        }

        // GET: Pecas/Create
        public ActionResult Create()
        {

            //public async Task<ActionResult> Createe(string tipocarro, string searchString)
            //{
            //    //DbContext db = new DbContext();
            //    //ViewBag.Uf = new SelectList(db.nome, "Id", "Initials");

            //    var _context = new catalogoOficialEntities();
            //    // Use LINQ to get list of genres.
            //    IOrderedEnumerable<Carro> genreQuery = from m in _context.Carro.AsEnumerable()
            //                                           orderby m.nome_Carro
            //                                           select m;
            //    return View(genreQuery.ToList());
            //}
            return View();
        }

        // POST: Pecas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Pecas,nome_Pecas,preco_Pecas,tipo")] Pecas pecas)
        {
            if (ModelState.IsValid)
            {
                db.PecasInfo.Add(pecas);
                db.SaveChanges();
                return RedirectToAction("IndexPecas");
            }

            ViewBag.tipo = new SelectList(db.Tipo, "id_Tipo", "descricao", pecas.tipo);
            return View(pecas); }

        // GET: Pecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecas pecas = db.PecasInfo.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo = new SelectList(db.Tipo, "id_Tipo", "descricao", pecas.tipo);
            return View(pecas);
        }

        // POST: Pecas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Pecas,nome_Pecas,preco_Pecas,tipo")] Pecas pecas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pecas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexPecas");
            }
            ViewBag.tipo = new SelectList(db.Tipo, "id_Tipo", "descricao", pecas.tipo);
            return View(pecas);
        }

        // GET: Pecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecas pecas = db.PecasInfo.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            return View(pecas);
        }

        // POST: Pecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pecas pecas = db.PecasInfo.Find(id);
            db.PecasInfo.Remove(pecas);
            db.SaveChanges();
            return RedirectToAction("IndexPecas");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public JsonResult DetailsJSON(int? id)
        {
            var peca = db.PecasInfo.AsEnumerable().FirstOrDefault(p => p.id_Pecas == id);

            dynamic pJSON = new
            {
                id = peca.id_Pecas,
                nome = peca.nome_Pecas
            };
                                             

            return Json(pJSON, JsonRequestBehavior.AllowGet);
        }
        
            //var carros = from m in _context.Carro.AsEnumerable()
            //             select m;

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    carros = carros.Where(s => s.nome_carro(searchString));
            //}

            //if (!string.IsNullOrEmpty(tipocarro))
            //{
            //    carros = carros.Where(x => x.nome.carro == tipocarro);
            //}

            //var oficial = new Oficial3.Models.Carro
            //{
            //    Carros = new SelectList(await genreQuery.Distinct().ToListAsync()),
            //    nome_Carro = await carros.ToListAsync()
            //};

            
    }
}
