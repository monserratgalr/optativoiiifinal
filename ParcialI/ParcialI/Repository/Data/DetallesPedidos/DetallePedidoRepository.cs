using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.DetallesPedidos
{
    public class DetallePedidoRepository
    {
        private NpgsqlConnection connection;
        public DetallePedidoRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AddDetallePedido(DetallePedidoModel detallepedido)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO DetallePedido (idDetallePedido, idPedido, idProducto, cantProducto, " +
                                      "subTotal) " +
                                      "VALUES (@idDetallePedido, @idPedido, @idProducto, @fechaHora, @subTotal, " +
                                      ")";
                    cmd.Parameters.AddWithValue("idDetallePedido", detallepedido.idDetallePedido);
                    cmd.Parameters.AddWithValue("idPedido", detallepedido.idPedido);
                    cmd.Parameters.AddWithValue("idProducto", detallepedido.idProducto);
                    cmd.Parameters.AddWithValue("cantProducto", detallepedido.cantProducto);
                    cmd.Parameters.AddWithValue("subTotal", detallepedido.subTotal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActuDetallePedido(DetallePedidoModel detallepedido)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE DetallePedido SET idDetallePedido = @idDetallePedido, idPedido = @idPedido, " +
                                      "idProducto = @idProducto, cantProducto = @cantProducto, subTotal = @subTotal, " +
                                      "WHERE idDetallePedido = @idDetallePedido";
                    cmd.Parameters.AddWithValue("idDetallePedido", detallepedido.idDetallePedido);
                    cmd.Parameters.AddWithValue("idPedido", detallepedido.idPedido);
                    cmd.Parameters.AddWithValue("idProducto", detallepedido.idProducto);
                    cmd.Parameters.AddWithValue("cantProducto", detallepedido.cantProducto);
                    cmd.Parameters.AddWithValue("subTotal", detallepedido.subTotal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int idDetallePedido)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM DetallePedido WHERE idDetallePedido = @idDetallePedido";
                    cmd.Parameters.AddWithValue("idDetallePedido", idDetallePedido);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DetallePedidoModel> ListarDetallePedido()
        {
            List<DetallePedidoModel> detallespedidos = new List<DetallePedidoModel>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM DetallePedido";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetallePedidoModel detallePedidoModel = new DetallePedidoModel(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetString(3),
                                reader.GetFloat(4)
                            );
                            detallespedidos.Add(detallePedidoModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return detallespedidos;
        }


    }
}

