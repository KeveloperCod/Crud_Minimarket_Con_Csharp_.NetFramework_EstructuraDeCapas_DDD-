using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
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
                throw new Exception("Error al listar Producto", ex);
            }

            return lista;
        }

        public string RegistrarProducto(Producto Producto)
        {
            string mensaje = "";
            var sp = "ProductosYCategorias.InsertarProducto";

            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    cone.Open();

                    SqlCommand cmd = new SqlCommand(sp, cone)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", Producto.Precio);
                    cmd.Parameters.AddWithValue("@Stock", Producto.Stock);
                    cmd.Parameters.AddWithValue("@CategoriaID", Producto.CategoriaID);

                    var rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se Inserto {rs} Producto.";
                }
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }
            return mensaje;
        }

        public string EditarProducto(Producto Producto)
        {
            string mensaje = "";
            var sp = "ProductosYCategorias.ActualizarProducto";

            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    cone.Open();

                    SqlCommand cmd = new SqlCommand(sp, cone)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.AddWithValue("@ProductoID", Producto.ProductoID);
                    cmd.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio", Producto.Precio);
                    cmd.Parameters.AddWithValue("@Stock", Producto.Stock);
                    cmd.Parameters.AddWithValue("@CategoriaID", Producto.CategoriaID);

                    var rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se Actualizo {rs} Producto.";
                }
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }

            return mensaje;
        }

        public string EliminarProducto(int id)
        {
            string mensaje = "";
            var sp = "ProductosYCategorias.EliminarProducto";

            try
            {
                using (SqlConnection cone = new SqlConnection(Conexion.cn))
                {
                    cone.Open();

                    SqlCommand cmd = new SqlCommand(sp, cone)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    cmd.Parameters.AddWithValue("@ProductoID", id);

                    var rs = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha eliminado {rs} Producto";
                }
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
            }
            return mensaje;
        }

    }
}

