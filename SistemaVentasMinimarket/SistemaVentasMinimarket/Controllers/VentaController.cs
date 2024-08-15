using CapaNegocio;
using CapaEntidad;
using System;
using System.Web.Mvc;
using Rotativa;
using System.Collections.Generic;

namespace SistemaVentasMinimarket.Controllers
{
    public class VentaController : Controller
    {
        private readonly CN_Venta objCapaNegocio = new CN_Venta();
        private readonly CN_Producto objProductoNegocio = new CN_Producto();

        // GET: /Venta/RealizarVenta
        public ActionResult RealizarVenta()
        {
            var venta = new Venta
            {
                DetalleVentas = new List<DetalleVenta>()
            };

            ViewBag.Productos = objProductoNegocio.Listar();
            ViewBag.FormasPago = objCapaNegocio.ListarFormasPago();

            return View(venta);
        }



        // POST: /Venta/RealizarVenta
        [HttpPost]
        public ActionResult RealizarVenta(Venta venta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    venta.FechaVenta = DateTime.Now;
                    int idVenta = objCapaNegocio.RegistrarVenta(venta);
                    if (idVenta > 0)
                    {
                        return RedirectToAction("GenerarBoletaPDF", new { id = idVenta });
                    }
                    ModelState.AddModelError("", "Error al registrar la venta.");
                }

                ViewBag.Productos = objProductoNegocio.Listar();
                ViewBag.FormasPago = objCapaNegocio.ListarFormasPago();
                return View(venta);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error inesperado: " + ex.Message);
                return View(venta);
            }
        }


        // GET: /Venta/GenerarBoletaPDF/5
        public ActionResult GenerarBoletaPDF(int id)
        {
            var venta = objCapaNegocio.ObtenerVentaPorID(id);
            return new ViewAsPdf("BoletaPDF", venta)
            {
                FileName = $"Boleta_Venta_{id}.pdf"
            };
        }

        // Método para listar productos
        public ActionResult ListarProductos()
        {
            var productos = objProductoNegocio.Listar();
            return PartialView("_ListarProductos", productos);
        }

       
    }


}
