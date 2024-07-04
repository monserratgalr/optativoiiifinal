using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.DetalleFactura
{
    public class DetallesRepository
    {

            private NpgsqlConnection connection;

            public DetallesRepository(string connectionString)
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }

            public void AddDetalle(DetallesModel detalle)
            {
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Detalle (idDetalle, idFactura, idProducto, cantProducto, " +
                                          "subTotal) " +
                                          "VALUES (@idDetalle, @idFactura, @idProducto, @cantProducto, @subTotal)"; 
                        cmd.Parameters.AddWithValue("idDetalle", detalle.idDetalle);
                        cmd.Parameters.AddWithValue("idFactura", detalle.idFactura);
                        cmd.Parameters.AddWithValue("idProducto", detalle.idProducto);
                        cmd.Parameters.AddWithValue("cantProducto", detalle.cantProducto);
                        cmd.Parameters.AddWithValue("subTotal", detalle.subTotal);     
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void ActuDetalle(DetallesModel detalle)
            {
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Detalle SET idDetalle = @idDetalle, idFactura = @idFactura, " +
                                          "idProducto = @idProducto, cantProducto = @cantProducto, subTotal = @subTotal, " +
                                          "WHERE idDetalle = @idDetalle";
                        cmd.Parameters.AddWithValue("idDetalle", detalle.idDetalle);
                        cmd.Parameters.AddWithValue("idFactura", detalle.idFactura);
                        cmd.Parameters.AddWithValue("idProducto", detalle.idProducto);
                        cmd.Parameters.AddWithValue("cantProducto", detalle.cantProducto);
                        cmd.Parameters.AddWithValue("subTotal", detalle.subTotal);             
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int idDetalle)
            {
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Detalle WHERE idDetalle = @idDetalle";
                        cmd.Parameters.AddWithValue("idDetalle", idDetalle);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public List<DetallesModel> ListarDetalles()
            {
                List<DetallesModel> detalles = new List<DetallesModel>();
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Detalle";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            DetallesModel detalle = new DetallesModel(
                                        reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetInt32(2),
                                        reader.GetString(3),
                                        reader.GetString(4)                        
                                    );
                                detalles.Add(detalle);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return detalles;
            }

        }
    }



