using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Venta
    {
        private CD_Venta objCapaDatos = new CD_Venta();

        public int RegistrarVenta(Venta venta)
        {
            return objCapaDatos.RegistrarVenta(venta);
        }

        public Venta ObtenerVentaPorID(int id)
        {
            return objCapaDatos.ObtenerVentaPorID(id);
        }

        public List<FormaPago> ListarFormasPago()
        {
            return objCapaDatos.ListarFormasPago();
        }
    }
}
