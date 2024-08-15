using CapaEntidad;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace CapaDatos
{
    public class CD_ReporteVentas
    {
        public List<Venta> ObtenerReporteVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Venta> lista = new List<Venta>();

            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    var sp = "SP_OBTENER_REPORTE_VENTAS";
                    SqlCommand cmd = new SqlCommand(sp, cone);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    cone.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Venta()
                            {
                                VentaID = Convert.ToInt32(dr["VentaID"]),
                                FechaVenta = Convert.ToDateTime(dr["FechaVenta"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                //agregar mas filas 
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el reporte de ventas", ex);
            }

            return lista;
        }
    }
}
