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
        // GET: Producto
        public ActionResult Index()
        {
            var productosBL = new ProductosBL();
            var ListadeProductos = productosBL.ObtenerProductos();

            return View(ListadeProductos);
        }
    }
}