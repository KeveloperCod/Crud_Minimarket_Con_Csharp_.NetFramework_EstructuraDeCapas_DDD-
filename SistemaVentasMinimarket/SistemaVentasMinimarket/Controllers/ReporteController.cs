using System;
using System.Web.Mvc;
using CapaNegocio;
using Rotativa;

namespace SistemaVentasMinimarket.Controllers
{
    public class ReporteController : Controller
    {
        // Reporte
        private CN_ReporteVentas ReportVenta = new CN_ReporteVentas();

        public ActionResult ReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio == null)
            {
                fechaInicio = DateTime.Now.AddMonths(-1); // Valor predeterminado
            }

            if (fechaFin == null)
            {
                fechaFin = DateTime.Now; // Valor predeterminado
            }

            var lista = ReportVenta.ObtenerReporteVentas((DateTime)fechaInicio, (DateTime)fechaFin);
            return View(lista);
        }

        public ActionResult ExportarVentasPDF(DateTime fechaInicio, DateTime fechaFin)
        {
            var lista = ReportVenta.ObtenerReporteVentas(fechaInicio, fechaFin);
            return new ViewAsPdf("Ventas", lista)
            {
                FileName = $"Reporte_Ventas_{fechaInicio.ToString("yyyyMMdd")}_{fechaFin.ToString("yyyyMMdd")}.pdf"
            };
        }


        /**/
        private CN_ReporteProductos objCapaNegocio = new CN_ReporteProductos();

        public ActionResult ReporteProductos()
        {
            var lista = objCapaNegocio.ObtenerReporteProductos();
            return View(lista);
        }


        public ActionResult ExportarProductosPDF()
        {
            var lista = objCapaNegocio.ObtenerReporteProductos();
            return new ViewAsPdf("Productos", lista)
            {
                FileName = "Reporte_Productos.pdf"
            };
        }
    }
}