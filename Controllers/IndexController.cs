using Oficial3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oficial3.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
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