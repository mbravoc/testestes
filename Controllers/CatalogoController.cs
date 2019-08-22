using Oficial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oficial3.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        // catalogo que mostra as peças listadas
        catalogoOficialEntities db = new catalogoOficialEntities();
        public ActionResult IndexAjaxCatalogo()
        {
            return View(db.PecasInfo.ToList());
        }

        public ActionResult Catalogo(int id)
        {
            //List<Pecas> PecasInfo = db.PecasInfo.Where(x => x.id_Pecas == id).ToList();
            Pecas PecasInfo = db.PecasInfo.Where(x => x.id_Pecas == id).FirstOrDefault();
            return View(db.PecasInfo);
        }
       

       
    }
}