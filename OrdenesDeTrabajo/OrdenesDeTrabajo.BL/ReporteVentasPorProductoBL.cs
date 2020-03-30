using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesDeTrabajo.BL
{
    public class ReporteVentasPorProductoBL
    {
        Contexto _contexto;
        public List<ReporteVentasPorProducto> ListadeVentasPorProucto { get; set; }
        public ReporteVentasPorProductoBL()
        {
            _contexto = new Contexto();
            ListadeVentasPorProucto = new List<ReporteVentasPorProducto>();
        }

        public List<ReporteVentasPorProducto> ObtenerVentasPorProducto()
        {
            ListadeVentasPorProucto = _contexto.OrdenDetalle
                .Include("Producto")
                .Where(r => r.Orden.Activo)
                .GroupBy(r => r.Producto.Descripcion)
                .Select(r => new ReporteVentasPorProducto()
                {
                    Producto = r.Key,
                    Cantidad = r.Sum(s => s.Cantidad),
                    Total = r.Sum(s => s.Total)
                }).ToList();

            return ListadeVentasPorProucto;
        }
    }
}
