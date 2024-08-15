using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Venta
    {
        public int RegistrarVenta(Venta venta)
        {
            int idVenta = 0;

            using (SqlConnection cone = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_REGISTRAR_VENTA", cone)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
                    cmd.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
                    cmd.Parameters.AddWithValue("@FormaPagoID", venta.FormaPagoID);
                    cmd.Parameters.Add("@VentaID", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cone.Open();
                    cmd.ExecuteNonQuery();
                    idVenta = Convert.ToInt32(cmd.Parameters["@VentaID"].Value);

                    // Registrar detalles de la venta
                    foreach (var detalle in venta.DetalleVentas)
                    {
                        SqlCommand cmdDetalle = new SqlCommand("SP_REGISTRAR_DETALLEVENTA", cone)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmdDetalle.Parameters.AddWithValue("@VentaID", idVenta);
                        cmdDetalle.Parameters.AddWithValue("@ProductoID", detalle.ProductoID);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);

                        cmdDetalle.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar la venta", ex);
                }
            }

            return idVenta;
        }

        public Venta ObtenerVentaPorID(int id)
        {
            Venta venta = null;
            List<DetalleVenta> detalles = new List<DetalleVenta>();

            using (SqlConnection cone = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_OBTENER_VENTA_POR_ID", cone)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@VentaID", id);

                    cone.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            venta = new Venta()
                            {
                                VentaID = Convert.ToInt32(dr["VentaID"]),
                                FechaVenta = Convert.ToDateTime(dr["FechaVenta"]),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                                FormaPagoID = Convert.ToInt32(dr["FormaPagoID"]),
                                DetalleVentas = new List<DetalleVenta>()
                            };
                        }
                    }

                    if (venta != null)
                    {
                        SqlCommand cmdDetalles = new SqlCommand("SP_OBTENER_DETALLES_VENTA_POR_ID", cone)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        cmdDetalles.Parameters.AddWithValue("@VentaID", id);

                        using (SqlDataReader drDetalles = cmdDetalles.ExecuteReader())
                        {
                            while (drDetalles.Read())
                            {
                                detalles.Add(new DetalleVenta()
                                {
                                    DetalleVentaID = Convert.ToInt32(drDetalles["DetalleVentaID"]),
                                    ProductoID = Convert.ToInt32(drDetalles["ProductoID"]),
                                    Cantidad = Convert.ToInt32(drDetalles["Cantidad"]),
                                    PrecioUnitario = Convert.ToDecimal(drDetalles["PrecioUnitario"])
                                });
                            }
                        }
                        venta.DetalleVentas = detalles;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener la venta", ex);
                }
            }

            return venta;
        }

        public List<FormaPago> ListarFormasPago()
        {
            List<FormaPago> lista = new List<FormaPago>();

            using (SqlConnection cone = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_LISTAR_FORMAS_PAGO", cone)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cone.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new FormaPago()
                            {
                                FormaPagoID = Convert.ToInt32(dr["FormaPagoID"]),
                                Descripcion = Convert.ToString(dr["Descripcion"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar formas de pago", ex);
                }
            }

            return lista;
        }
    }
}
