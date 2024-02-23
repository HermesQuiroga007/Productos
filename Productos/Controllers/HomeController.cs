using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductosDB;


namespace Productos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            List<ProductosDB.Entities.Productos> productos = new List<ProductosDB.Entities.Productos>();

            Repositorio repo = new Repositorio();

            productos = repo.GetProductos();

            ViewBag.Productos = productos;

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}