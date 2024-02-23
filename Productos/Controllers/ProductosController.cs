using ProductosDB;
using ProductosDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Productos.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProductos()
        {
            Repositorio repo = new Repositorio();
            List<ProductosDB.Entities.Productos> productos = new List<ProductosDB.Entities.Productos>();

            productos = repo.GetProductos();
            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTipoProducto() //aqui llamamos al metodo get de repositorios
        {
            Repositorio repo = new Repositorio();
            List<TipoProducto> list = repo.GetTipoProducto();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertProducto(ProductosDB.Entities.Productos producto)
        {
            Repositorio repo = new Repositorio();
            Respuesta result = repo.InsertProducto(producto);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}