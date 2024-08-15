using System.Collections.Generic;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Empleado
    {
        private Empleados objCapaDatos = new Empleados();

        public List<Empleado> Listar()
        {
            return objCapaDatos.Listar();
        }

        public string Registrar(Empleado empleado)
        {
            return objCapaDatos.Registrar(empleado);
        }

        public string Actualizar(Empleado empleado)
        {
            return objCapaDatos.Actualizar(empleado);
        }

        public string Eliminar(int empleadoID)
        {
            return objCapaDatos.Eliminar(empleadoID);
        }
    }
}
