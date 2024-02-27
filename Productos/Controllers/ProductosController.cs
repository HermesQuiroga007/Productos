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
        ProductosDB.Repositorio repo = new ProductosDB.Repositorio();
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
            producto.CreadoPor = "Admin";
            //producto.ModificadoPor = "Admin";
            Respuesta result = repo.InsertProducto(producto);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActualizarProducto(ProductosDB.Entities.Productos producto)
        {
            try
            {
                producto.ModificadoPor = "Admin";
                Respuesta result = repo.ActualizarProducto(producto);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Respuesta { Exitoso = false, Mensaje = "Error al actualizar el producto: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult EliminarProducto(int id)
        {
            try
            {
                Respuesta result = repo.EliminarProducto(id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Respuesta { Exitoso = false, Mensaje = "Error al eliminar el producto: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}