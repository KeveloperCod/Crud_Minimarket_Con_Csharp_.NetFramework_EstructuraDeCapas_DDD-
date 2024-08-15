using CapaEntidad;
using System.Collections.Generic;

using CapaDatos;

namespace CapaNegocio
{
    public class CN_Producto
    {
        private CD_Producto objCapaDatos = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCapaDatos.Listar();
        }

        public string Registrar(Producto producto)
        {
            return objCapaDatos.RegistrarProducto(producto);
        }

        public string Actualizar(Producto producto)
        {
            return objCapaDatos.EditarProducto(producto);
        }

        public string Eliminar(int id)
        {
            return objCapaDatos.EliminarProducto(id);
        }
    }
}
