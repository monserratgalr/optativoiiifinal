using System;
using System.Collections.Generic;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ParcialI.Repository.Data.Proveedores
{
    public class ProveedorRepository
    {
        private NpgsqlConnection connection;

        public ProveedorRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AddProveedor(ProveedorModel proveedor)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Proveedor (idProveedor, razonSocial, tipoDocumento, numeroDocumento, " +
                                      "direccion, mail, celular, estado) " +
                                      "VALUES (@id_proveedor, @razonSocial, @tipoDocumento, @numeroDocumento, @direccion, " +
                                      "@mail, @celular, @estado)";
                    cmd.Parameters.AddWithValue("id_proveedor", proveedor.idProveedor);
                    cmd.Parameters.AddWithValue("razonSocial", proveedor.razonSocial);
                    cmd.Parameters.AddWithValue("tipoDocumento", proveedor.tipoDocumento);
                    cmd.Parameters.AddWithValue("numeroDocumento", proveedor.numeroDocumento);
                    cmd.Parameters.AddWithValue("direccion", proveedor.direccion);
                    cmd.Parameters.AddWithValue("mail", proveedor.mail);
                    cmd.Parameters.AddWithValue("celular", proveedor.celular);
                    cmd.Parameters.AddWithValue("estado", proveedor.estado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActuProveedor(ProveedorModel proveedor)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Proveedor SET idProveedor = @idProveedor, razonSocial = @razonSocial, " +
                                      "tipoDocumento = @tipoDocumento, numeroDocumento = @numeroDocumento, direccion = @direccion, " +
                                      "mail = @mail, celular = @celular, " +
                                      "estado = @estado WHERE idProveedor = @idProveedor";
                    cmd.Parameters.AddWithValue("id_proveedor", proveedor.idProveedor);
                    cmd.Parameters.AddWithValue("razonSocial", proveedor.razonSocial);
                    cmd.Parameters.AddWithValue("tipoDocumento", proveedor.tipoDocumento);
                    cmd.Parameters.AddWithValue("numeroDocumento", proveedor.numeroDocumento);
                    cmd.Parameters.AddWithValue("direccion", proveedor.direccion);
                    cmd.Parameters.AddWithValue("mail", proveedor.mail);
                    cmd.Parameters.AddWithValue("celular", proveedor.celular);
                    cmd.Parameters.AddWithValue("estado", proveedor.estado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int idProveedor)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Proveedor WHERE idProveedor = @idProveedor";
                    cmd.Parameters.AddWithValue("idProveedor", idProveedor);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProveedorModel> ListarProveedor()
        {
            List<ProveedorModel> proveedores = new List<ProveedorModel>();
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Proveedor";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProveedorModel proveedor = new ProveedorModel(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetString(4),
                                    reader.GetString(5),
                                    reader.GetString(6),
                                    reader.GetString(7)
                                );
                            proveedores.Add(proveedor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return proveedores;
        }

    }
}

