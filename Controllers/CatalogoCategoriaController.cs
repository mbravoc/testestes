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
            List<Tipo> TipoInfo = db.Tipo.Where(x => x.id_Tipo == id).ToList();
            return View(db.Tipo.ToList());
        }
    }
}