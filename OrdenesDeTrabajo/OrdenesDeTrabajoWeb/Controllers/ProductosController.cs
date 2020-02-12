using OrdenesDeTrabajoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdenesDeTrabajoWeb.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {

            var producto = new ProductoModel();
            producto.Id = 1;
            producto.Descripcion ="Mantenimiento";

            return View(producto);
        }
    }
}