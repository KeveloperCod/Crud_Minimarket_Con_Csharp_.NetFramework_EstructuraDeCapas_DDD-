using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;


namespace SistemaVentasMinimarket.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Empleados()
        {
            return View();
        }


        //*******************************LISTAR EMPLEADO*************************************************//
        [HttpGet]
        public JsonResult ListarEmpleados()
        {
            try
            {
                CN_Empleado cnEmpleado = new CN_Empleado();
                List<Empleado> lista = cnEmpleado.Listar();
                return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                
                return Json(new { data = new List<Empleado>(), error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //*******************************REGISTRAR EMPLEADO*************************************************//

        [HttpGet]
        public ActionResult RegistrarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarEmpleado(Empleado empleado)
        {
            try
            {
                CN_Empleado cnEmpleado = new CN_Empleado();
                string resultado = cnEmpleado.Registrar(empleado);
                return Json(new { success = true, message = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
        //*******************************ACTUALIZAR EMPLEADO*************************************************//
        [HttpGet]
        public ActionResult ActualizarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                CN_Empleado cnEmpleado = new CN_Empleado();
                string resultado = cnEmpleado.Actualizar(empleado);
                return Json(new { success = true, message = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        //*******************************ELIMINAR EMPLEADO*************************************************//

        [HttpPost]
        public JsonResult EliminarEmpleado(int empleadoID)
        {
            try
            {
                CN_Empleado cnEmpleado = new CN_Empleado();
                string resultado = cnEmpleado.Eliminar(empleadoID);
                return Json(new { success = true, message = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }



        /******************************************/
        public ActionResult Clientes()
        {
            return View();
        }

        /*********************PRODUCTO*********************/
        public ActionResult Productos()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarProducto()
        {
            CN_Producto cn_producto = new CN_Producto();
            List<Producto> lista = cn_producto.Listar();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegistrarProductos()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegistrarProductos(Producto producto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (producto.ProductoID == 0)
            {
                resultado = new CN_Producto().Registrar(producto);
            }
            else
            {
                resultado = new CN_Producto().Actualizar(producto);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
