using OrdenesDeTrabajo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrdenesDeTrabajo.Web.Controllers
{
    public class OrdenDetalleController : Controller
    {
        OrdenesBL _ordenBL;

        public OrdenDetalleController()
        {
            _ordenBL = new OrdenesBL();
        }
        // GET: OrdenesDetalle
        public ActionResult Index(int Id)
        {
            var orden = _ordenBL.ObtenerOrden(Id);

            return View(orden);
        }
    }
}