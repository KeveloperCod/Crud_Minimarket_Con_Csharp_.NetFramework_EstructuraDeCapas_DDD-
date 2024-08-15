using System;

namespace CapaEntidad
{
    public class Producto
    {
        public int ProductoID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int CategoriaID { get; set; }

        public DateTime FechaAgregado { get; set; }
    }
}
