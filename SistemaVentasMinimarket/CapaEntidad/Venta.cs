using System.Collections.Generic;
using System;

namespace CapaEntidad
{
    public class Venta
    {
        public int VentaID { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public int FormaPagoID { get; set; }
        public List<DetalleVenta> DetalleVentas { get; set; }
        
    }

   /* public class DetalleVenta
    {
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }*/

}
