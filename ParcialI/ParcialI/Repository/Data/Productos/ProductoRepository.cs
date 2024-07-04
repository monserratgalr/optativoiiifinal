using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.Productos
{
    public class ProductoRepository
    {

            private NpgsqlConnection connection;

            public ProductoRepository(string connectionString)
            {
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }

            public void AddProducto(ProductoModel producto)
            {
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO Producto (idProducto, descripcion, cantMinima, cantStock, " +
                                          "precioCompra, precioVenta, categoria, marca, estado) " +
                                          "VALUES (@id_producto, @descripcion, @cantMinima, @cantStock, @precioCompra, " +
                                          "@precioVenta, @categoria, @marca, @estado)";
                        cmd.Parameters.AddWithValue("id_producto", producto.idProducto);
                        cmd.Parameters.AddWithValue("descripcion", producto.descripcion);
                        cmd.Parameters.AddWithValue("cantMinima", producto.cantMinima);
                        cmd.Parameters.AddWithValue("precioCompra", producto.precioCompra);
                        cmd.Parameters.AddWithValue("precioVenta", producto.precioVenta);
                        cmd.Parameters.AddWithValue("categoria", producto.categoria);
                        cmd.Parameters.AddWithValue("marca", producto.marca);
                        cmd.Parameters.AddWithValue("estado", producto.estado);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void ActuProducto(ProductoModel producto)
            {
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Producto SET idProducto = @idProducto, descripcion = @descripcion, " +
                                          "cantMinima = @cantMinima, cantStock = @cantStock, precioCompra = @precioCompra, " +
                                          "precioVenta = @precioVenta, categoria = @categoria, marca = @marca, " +
                                          "estado = @estado WHERE idProducto = @idProducto";
                        cmd.Parameters.AddWithValue("id_producto", producto.idProducto);
                        cmd.Parameters.AddWithValue("descripcion", producto.descripcion);
                        cmd.Parameters.AddWithValue("cantMinima", producto.cantMinima);
                        cmd.Parameters.AddWithValue("cantStock", producto.cantStock);
                        cmd.Parameters.AddWithValue("precioCompra", producto.precioCompra);
                        cmd.Parameters.AddWithValue("precioVenta", producto.precioVenta);
                        cmd.Parameters.AddWithValue("categoria", producto.categoria);
                        cmd.Parameters.AddWithValue("marca", producto.marca);
                        cmd.Parameters.AddWithValue("estado", producto.estado);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void Eliminar(int idProducto)
            {
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "DELETE FROM Producto WHERE idProducto = @idProducto";
                        cmd.Parameters.AddWithValue("idProducto", idProducto);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public List<ProductoModel> ListarProducto()
            {
                List<ProductoModel> productos = new List<ProductoModel>();
                try
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Producto";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            ProductoModel producto = new ProductoModel(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5),
                                    reader.GetString(6),
                                    reader.GetString(7),
                                    reader.GetString(8)
                                );
                                productos.Add(producto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return productos;
            }

        }
    }

