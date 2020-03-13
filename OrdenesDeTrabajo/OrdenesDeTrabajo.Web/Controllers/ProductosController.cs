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
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
        }

        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion", producto.CategoriaId);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                if (imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productosBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var categorias = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion");

            return View(producto);
        }

        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);

            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;


        }
    }
}