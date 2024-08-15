using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_ReporteProductos
    {
        private CD_ReporteProductos objCapaDatos = new CD_ReporteProductos();

        public List<Producto> ObtenerReporteProductos()
        {
            return objCapaDatos.ObtenerReporteProductos();
        }
    }
}
