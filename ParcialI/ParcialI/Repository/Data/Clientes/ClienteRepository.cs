using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ParcialI.Repository.Data.Clientes
{
    public class ClienteRepository
    {

        NpgsqlConnection connection;

        public ClienteRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public bool agregarCliente(ClienteModel cliente)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Cliente (nombre, apellido, documento, direccion, email, celular, estado) " +
                                      "VALUES (@nombre, @apellido, @documento, @direccion, @email, @celular, @estado)";
                    cmd.Parameters.AddWithValue("nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", cliente.apellido);
                    cmd.Parameters.AddWithValue("documento", cliente.documento);
                    cmd.Parameters.AddWithValue("direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("email", cliente.email);
                    cmd.Parameters.AddWithValue("celular", cliente.celular);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void actualizarCliente(ClienteModel cliente)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Cliente SET nombre = @nombre, apellido = @apellido, " +
                                      "documento = @documento, direccion = @direccion, email = @email, celular = @celular, estado = @estado " +
                                      "WHERE id_cliente = @id_cliente";
                    cmd.Parameters.AddWithValue("nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", cliente.apellido);
                    cmd.Parameters.AddWithValue("documento", cliente.documento);
                    cmd.Parameters.AddWithValue("direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("email", cliente.email);
                    cmd.Parameters.AddWithValue("celular", cliente.celular);
                    cmd.Parameters.AddWithValue("estado", cliente.estado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarCliente(int id_cliente)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Cliente WHERE id_cliente = @id_cliente";
                    cmd.Parameters.AddWithValue("id_cliente", id_cliente);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ClienteModel> List() //listar cliente
        {
            List<ClienteModel> clientes = new List<ClienteModel>();

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Cliente";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            ClienteModel cliente = new ClienteModel(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7),
                                reader.GetString(8)
                            );
                            clientes.Add(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ha ocurrido un error: " + ex.Message);
            }

            return clientes;
        }
    }
}

    


