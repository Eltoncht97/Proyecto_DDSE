using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Restaurant.Entidades;

namespace Restaurant.Datos
{
    public class PedidoDAO
    {
        public int Registrar(Pedido pedido)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();
                try
                {
                    // 1) Insertar cabecera del pedido
                    SqlCommand cmd = new SqlCommand("usp_Pedido_Insertar", cn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", pedido.Fecha);
                    cmd.Parameters.AddWithValue("@IdMesa", pedido.IdMesa);
                    cmd.Parameters.AddWithValue("@IdEmpleado", pedido.IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdCliente", (object)pedido.IdCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Situacion", pedido.Situacion);
                    cmd.Parameters.AddWithValue("@Total", pedido.Total);
                    int idPedido = Convert.ToInt32(cmd.ExecuteScalar());

                    // 2) Insertar cada línea de detalle
                    foreach (DetallePedido det in pedido.Detalles)
                    {
                        SqlCommand cmdDet = new SqlCommand("usp_DetallePedido_Insertar", cn, tran);
                        cmdDet.CommandType = CommandType.StoredProcedure;
                        cmdDet.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmdDet.Parameters.AddWithValue("@IdPlato", det.IdPlato);
                        cmdDet.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                        cmdDet.Parameters.AddWithValue("@PrecioUnitario", det.PrecioUnitario);
                        cmdDet.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return idPedido;
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public List<Pedido> Listar()
        {
            List<Pedido> lista = new List<Pedido>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Pedido_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Pedido
                        {
                            IdPedido = Convert.ToInt32(dr["IdPedido"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            Mesa = dr["Mesa"].ToString(),
                            Mozo = dr["Mozo"].ToString(),
                            Cliente = dr["Cliente"].ToString(),
                            Situacion = dr["Situacion"].ToString(),
                            Total = Convert.ToDecimal(dr["Total"])
                        });
                    }
                }
            }
            return lista;
        }

        public DataTable ListarTabla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Pedido_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public List<DetallePedido> ObtenerDetalle(int idPedido)
        {
            List<DetallePedido> lista = new List<DetallePedido>();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Pedido_ObtenerDetalle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new DetallePedido
                        {
                            IdDetalle = Convert.ToInt32(dr["IdDetalle"]),
                            IdPedido = Convert.ToInt32(dr["IdPedido"]),
                            IdPlato = Convert.ToInt32(dr["IdPlato"]),
                            Plato = dr["Plato"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                            EstadoDetalle = dr["EstadoDetalle"] == DBNull.Value
                                ? "Solicitado" : dr["EstadoDetalle"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public DataTable ListarEnPreparacion()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Pedido_ListarEnPreparacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public void CambiarEstadoDetalle(int idDetalle, string estado)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_DetallePedido_CambiarEstado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalle", idDetalle);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CambiarSituacion(int idPedido, string situacion)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Pedido_CambiarSituacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                cmd.Parameters.AddWithValue("@Situacion", situacion);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Pedido ObtenerPorId(int idPedido)
        {
            Pedido pedido = null;
            using (SqlConnection cn = Conexion.Obtener())
            {
                SqlCommand cmd = new SqlCommand("usp_Pedido_ObtenerPorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        pedido = new Pedido
                        {
                            IdPedido = Convert.ToInt32(dr["IdPedido"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"]),
                            IdMesa = Convert.ToInt32(dr["IdMesa"]),
                            IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                            IdCliente = dr["IdCliente"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["IdCliente"]),
                            Situacion = dr["Situacion"].ToString(),
                            Total = Convert.ToDecimal(dr["Total"])
                        };
                    }
                }
            }
            return pedido;
        }

        // Actualiza la cabecera y reemplaza por completo el detalle (transacción).
        public void Actualizar(Pedido pedido)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                cn.Open();
                SqlTransaction tran = cn.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_Pedido_Actualizar", cn, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
                    cmd.Parameters.AddWithValue("@IdMesa", pedido.IdMesa);
                    cmd.Parameters.AddWithValue("@IdEmpleado", pedido.IdEmpleado);
                    cmd.Parameters.AddWithValue("@IdCliente", (object)pedido.IdCliente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Total", pedido.Total);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmdDel = new SqlCommand("usp_DetallePedido_EliminarPorPedido", cn, tran);
                    cmdDel.CommandType = CommandType.StoredProcedure;
                    cmdDel.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
                    cmdDel.ExecuteNonQuery();

                    foreach (DetallePedido det in pedido.Detalles)
                    {
                        SqlCommand cmdDet = new SqlCommand("usp_DetallePedido_Insertar", cn, tran);
                        cmdDet.CommandType = CommandType.StoredProcedure;
                        cmdDet.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
                        cmdDet.Parameters.AddWithValue("@IdPlato", det.IdPlato);
                        cmdDet.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                        cmdDet.Parameters.AddWithValue("@PrecioUnitario", det.PrecioUnitario);
                        cmdDet.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}
