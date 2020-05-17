using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeTrabajo.BL
{
   public class CategoriaBL
    {
        Contexto _contexto;
        public List<Categoria> ListadeCotegorias { get; set; }

        public CategoriaBL()
        {
            _contexto = new Contexto();
            ListadeCotegorias = new List<Categoria>();
        }

        public List<Categoria> ObtenerCategorias()
        {
            ListadeCotegorias = _contexto.Categorias.ToList();
            return ListadeCotegorias;
        }

        public void GuardarCategorias(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Categorias.Find(categoria.Id);
                categoriaExistente.Descripcion = categoria.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Categoria ObtenerCategorias(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            return categoria;
        }

        public void EliminarCategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }

        public static object ObtenerCategoria()
        {
            throw new NotImplementedException();
        }
    }
}
