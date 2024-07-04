using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.PedidosCompras
{
    public class PedidoCompraRepository {
        private NpgsqlConnection connection;
        public PedidoCompraRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AddPedidoCompra(PedidoCompraModel pedidocompra)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO PedidoCompra (idPedidoCompra, idProveedor, idSucursal, fechaHora, " +
                                      "total) " +
                                      "VALUES (@idPedidoCompra, @idProveedor, @idSucursal, @fechaHora, @total, " +
                                      ")";
                    cmd.Parameters.AddWithValue("idPedidoCompra", pedidocompra.idPedidoCompra);
                    cmd.Parameters.AddWithValue("idProveedor", pedidocompra.idProveedor);
                    cmd.Parameters.AddWithValue("idSucursal", pedidocompra.idSucursal);
                    cmd.Parameters.AddWithValue("fechaHora", pedidocompra.fechaHora);
                    cmd.Parameters.AddWithValue("total", pedidocompra.total);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActuPedidoCompra(PedidoCompraModel pedidocompra)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE PedidoCompra SET idPedidoCompra = @idPedidoCompra, idProveedor = @idProveedor, " +
                                      "idSucursal = @idSucursal, fechaHora = @fechaHora, total = @total, " +
                                      "WHERE idPedidoCompra = @idPedidoCompra";
                    cmd.Parameters.AddWithValue("idPedidoCompra", pedidocompra.idPedidoCompra);
                    cmd.Parameters.AddWithValue("idProveedor", pedidocompra.idProveedor);
                    cmd.Parameters.AddWithValue("idSucursal", pedidocompra.idSucursal);
                    cmd.Parameters.AddWithValue("fechaHora", pedidocompra.fechaHora);
                    cmd.Parameters.AddWithValue("total", pedidocompra.total);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int idPedidoCompra)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM PedidoCompra WHERE idPedidoCompra = @idPedidoCompra";
                    cmd.Parameters.AddWithValue("idPedidoCompra", idPedidoCompra);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PedidoCompraModel> ListarPedidoCompra()
        {
            List<PedidoCompraModel> pedidoscompras = new List<PedidoCompraModel>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM PedidoCompra";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PedidoCompraModel pedidoCompraModel = new PedidoCompraModel(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetDateTime(3),
                                reader.GetFloat(4)
                            );
                            pedidoscompras.Add(pedidoCompraModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pedidoscompras;
        }


    }
}

