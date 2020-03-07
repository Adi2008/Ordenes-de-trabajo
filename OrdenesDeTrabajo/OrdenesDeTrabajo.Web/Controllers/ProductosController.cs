using OrdenesDeTrabajo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdenesDeTrabajo.Web.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _productosBL;
        CategoriaBL _categoriaBL;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _categoriaBL = new CategoriaBL();
        }

        // GET: Producto
        public ActionResult Index()
        {
            var productosBL = new ProductosBL();
            var ListadeProductos = productosBL.ObtenerProductos();

            return View(ListadeProductos);
        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.ListaCategorias = new SelectList(categorias, "Id", "Descripcion");

                return View(nuevoProducto);
        }
        [HttpPost]
        public ActionResult Crear(Producto producto)
        {
            _productosBL.GuardarProducto(producto);

            return RedirectToAction("Index");
        }
    }
}