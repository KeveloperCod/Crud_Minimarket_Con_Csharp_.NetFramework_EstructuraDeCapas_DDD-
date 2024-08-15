using CapaEntidad;
using System.Collections.Generic;
using System;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ReporteVentas
    {
        private CD_ReporteVentas objCapaDatos = new CD_ReporteVentas();

        public List<Venta> ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            return objCapaDatos.ObtenerReporteVentas(fechaInicio, fechaFin);
        }
    }
}
