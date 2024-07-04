using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using ParcialI.Repository.Data.DetalleFactura;
using ParcialI.Repository.Data.Productos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ParcialI.Repository.Data.Facturas
{
    public class FacturaRepository
    {
        private NpgsqlConnection connection;

        public FacturaRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AddFact(FacturaModel factura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Factura (idCliente, nroFactura, fechaHora, total, " +
                                      "iva5, iva10, ivaTotal, letras, sucursal) " +
                                      "VALUES (@idCliente, @nroFactura, @fechaHora, @total, @iva5, " +
                                      "@iva10, @ivaTotal, @letras, @sucursal)";
                    cmd.Parameters.AddWithValue("idCliente", factura.idCliente);
                    cmd.Parameters.AddWithValue("nroFactura", factura.nroFactura);
                    cmd.Parameters.AddWithValue("fechaHora", factura.fechaHora);
                    cmd.Parameters.AddWithValue("total", factura.total);
                    cmd.Parameters.AddWithValue("iva5", factura.iva5);
                    cmd.Parameters.AddWithValue("iva10", factura.iva10);
                    cmd.Parameters.AddWithValue("ivaTotal", factura.ivaTotal);
                    cmd.Parameters.AddWithValue("letras", factura.letras);
                    cmd.Parameters.AddWithValue("sucursal", factura.sucursal);
                    cmd.ExecuteNonQuery();
                }

                foreach (var detalle in factura.Detalles)
                {
                    connection.Execute("INSERT INTO DetalleFactura (idFactura, idProducto, cantProducto, subTotal) " +
                        "VALUES (@idFactura, @idProducto, @cantProducto, @subTotal)", new
                        {
                            idFactura = factura.idFactura,
                            idProducto = detalle.IdProducto,
                            cantProducto = detalle.CantProducto,
                            subTotal = detalle.SubTotal
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActuFactura(FacturaModel factura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Factura SET idCliente = @idCliente, nroFactura = @nroFactura, " +
                                      "fechaHora = @fechaHora, total = @total, iva5 = @iva5, " +
                                      "iva10 = @iva10, ivaTotal = @ivaTotal, letras = @letras, " +
                                      "sucursal = @sucursal WHERE idFactura = @idFactura";
                    cmd.Parameters.AddWithValue("idCliente", factura.idCliente);
                    cmd.Parameters.AddWithValue("nroFactura", factura.nroFactura);
                    cmd.Parameters.AddWithValue("fechaHora", factura.fechaHora);
                    cmd.Parameters.AddWithValue("total", factura.total);
                    cmd.Parameters.AddWithValue("iva5", factura.iva5);
                    cmd.Parameters.AddWithValue("iva10", factura.iva10);
                    cmd.Parameters.AddWithValue("ivaTotal", factura.ivaTotal);
                    cmd.Parameters.AddWithValue("letras", factura.letras);
                    cmd.Parameters.AddWithValue("sucursal", factura.sucursal);
                    cmd.Parameters.AddWithValue("idFactura", factura.idFactura);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int idFactura)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Factura WHERE idFactura = @idFactura";
                    cmd.Parameters.AddWithValue("idFactura", idFactura);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<FacturaModel> ListarFactura()
        {
            List<FacturaModel> facturas = new List<FacturaModel>();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Factura";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FacturaModel factura = new FacturaModel(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetDateTime(3),
                                reader.GetFloat(4),
                                reader.GetFloat(5),
                                reader.GetFloat(6),
                                reader.GetFloat(7),
                                reader.GetString(8),
                                reader.GetString(9)
                            );
                            facturas.Add(factura);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return facturas;
        }
    }

}