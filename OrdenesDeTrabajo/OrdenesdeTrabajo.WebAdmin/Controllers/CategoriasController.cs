using OrdenesDeTrabajo.BL;
using System.Web.Mvc;

namespace OrdenesdeTrabajo.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
        CategoriaBL _categoriasBL;

        public CategoriasController()
        {
            _categoriasBL = new CategoriaBL();
        }
        // GET: Categorias
        public ActionResult Index()
        {
            var listadeCategorias = _categoriasBL.ObtenerCategorias();

            return View(listadeCategorias);
        }

        public ActionResult Crear()
        {
            var nuevaCategoria = new Categoria();

            return View(nuevaCategoria);
        }

        [HttpPost]
        public ActionResult Crear(Categoria producto)
        {
            _categoriasBL.GuardarCategorias(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var producto = _categoriasBL.ObtenerCategorias(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Categoria producto)
        {
            _categoriasBL.GuardarCategorias(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var producto = _categoriasBL.ObtenerCategorias(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _categoriasBL.ObtenerCategorias(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Categoria producto)
        {
            _categoriasBL.EliminarCategoria(producto.Id);

            return RedirectToAction("Index");
        }

    }
}