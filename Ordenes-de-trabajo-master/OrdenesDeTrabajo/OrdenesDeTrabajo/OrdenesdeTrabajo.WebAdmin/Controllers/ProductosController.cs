﻿using OrdenesDeTrabajo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdenesdeTrabajo.WebAdmin.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        ProductosBL _productosBL;
        CategoriaBL _categoriaBL;
        private object imagen;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _categoriaBL = new CategoriaBL();
        }
        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();

            return View(listadeProductos);
        }
        
        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            var categoria = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId = 
                new SelectList(categoria, "Id", "Descripcion");
            
            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto, HttpPostedFileBase imagen)
        {
            if(ModelState.IsValid)
            {
                if(producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                if(imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productosBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var nuevoProducto = new Producto();
            var categoria = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categoria, "Id", "Descripcion");

            return View(producto);
        }

        public ActionResult Editar(int id)
        {
           var producto = _productosBL.ObtenerProducto(id);
            var categoria = _categoriaBL.ObtenerCategorias();

            ViewBag.categoriaId = 
                new SelectList(categoria, "Id", "Descripcion", producto.CategoriaId);
        
            return View(producto);
        }

        private dynamic SelectList(object categoria, string v1, string v2, object categoriaId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una categoria");
                    return View(producto);
                }

                _productosBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var nuevoProducto = new Producto();
            var categoria = _categoriaBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categoria, "Id", "Descripcion");

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