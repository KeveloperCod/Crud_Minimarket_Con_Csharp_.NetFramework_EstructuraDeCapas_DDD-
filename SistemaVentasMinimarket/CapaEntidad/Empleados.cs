using System;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        [Display(Name = "Fecha de contratación")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo requerido")]
        [DataType(DataType.Date)]
        public DateTime? FechaContratacion { get; set; } 
        public string NomCargo { get; set; }
        public int CargoID { get; set; }
    }
   
}
