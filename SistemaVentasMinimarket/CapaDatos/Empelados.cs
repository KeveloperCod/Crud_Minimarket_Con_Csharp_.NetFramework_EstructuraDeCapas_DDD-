using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;
using System;

namespace CapaDatos
{
    public class Empleados
    {
        public List<Empleado> Listar()
        {
            List<Empleado> lista = new List<Empleado>();

            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    var sp = "usp_get_Empleados";
                    SqlCommand cmd = new SqlCommand(sp, cone);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cone.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DateTime? fechaContratacion = Convert.IsDBNull(dr["FechaContratacion"]) ? (DateTime?)null : Convert.ToDateTime(dr["FechaContratacion"]);

                            lista.Add(new Empleado()
                            {
                                EmpleadoID = Convert.ToInt32(dr["EmpleadoID"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                FechaContratacion = fechaContratacion,
                                NomCargo = dr["NomCargo"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar empleados", ex);
            }

            return lista;
        }


        public string Registrar(Empleado empleado)
        {
            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    var sp = "usp_insert_Empleado";
                    SqlCommand cmd = new SqlCommand(sp, cone);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Email", empleado.Email);
                    cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                    cmd.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion);
                    cmd.Parameters.AddWithValue("@CargoID", empleado.CargoID);

                    cone.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Empleado registrado con éxito";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar empleado", ex);
            }
        }


        public string Actualizar(Empleado empleado)
        {
            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    var sp = "usp_update_Empleado";
                    SqlCommand cmd = new SqlCommand(sp, cone);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpleadoID", empleado.EmpleadoID);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Email", empleado.Email);
                    cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                    cmd.Parameters.AddWithValue("@Direccion", empleado.Direccion);
                    cmd.Parameters.AddWithValue("@FechaContratacion", empleado.FechaContratacion);
                    cmd.Parameters.AddWithValue("@CargoID", empleado.CargoID);

                    cone.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Empleado actualizado con éxito";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar empleado", ex);
            }
        }

        public string Eliminar(int empleadoID)
        {
            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    var sp = "usp_delete_Empleado";
                    SqlCommand cmd = new SqlCommand(sp, cone);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);

                    cone.Open();
                    cmd.ExecuteNonQuery();
                }
                return "Empleado eliminado con éxito";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar empleado", ex);
            }
        }

    }
}
