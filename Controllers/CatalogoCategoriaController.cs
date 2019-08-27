using Oficial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oficial3.Controllers
{
    public class CatalogoCategoriaController : Controller
    {
        // GET: CatalogoCategoria
        catalogoOficialEntities db = new catalogoOficialEntities();
       
        public ActionResult CatalogoCategoria(int id)
        {
            if (ModelState.IsValid)
            {
                // cadastrar o TODOS no banco
                // esse TODOS vai ter um id

                // if (id == todos(1001)
                if (id == 1001)
                //List<Tipo> TipoInfo = db.Tipo.ToList();
                {
                    List<Tipo> TipoInfo = db.Tipo.ToList();
                }
                else
                {
                    // else
                    List<Tipo> TipoInfo = db.Tipo.Where(x => x.id_Tipo == id).ToList();
                    return View(/*db.Tipo.ToList()*/TipoInfo);
                }
            }// fim if
            return RedirectToAction("CatalogoCategoria", "CatalogoCategoria"/*, new { id = 1002 })*/);

        }
        public ActionResult CatalogoCategoria()
        {
            catalogoOficialEntities db = new catalogoOficialEntities();

            List<Carro> carros = new List<Carro>();

            carros = db.Carro.ToList();
            ViewBag.Carros = carros;
            ViewBag.tipo = new SelectList(db.Tipo, "id_Tipo", "descricao");
            return View();
        }


    }
}
