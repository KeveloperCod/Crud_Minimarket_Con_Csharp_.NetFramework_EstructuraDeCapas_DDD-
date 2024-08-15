using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_ReporteProductos
    {
        public List<Producto> ObtenerReporteProductos()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    var sp = "SP_LISTAR_PRODUCTO";
                    SqlCommand cmd = new SqlCommand(sp, cone);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cone.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                ProductoID = Convert.ToInt32(dr["ProductoID"]),
                                Nombre = Convert.ToString(dr["Nombre"]),
                                Descripcion = Convert.ToString(dr["Descripcion"]),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                CategoriaID = Convert.ToInt32(dr["CategoriaID"]),
                                FechaAgregado = Convert.ToDateTime(dr["FechaAgregado"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el reporte de productos", ex);
            }

            return lista;
        }
    }
}
