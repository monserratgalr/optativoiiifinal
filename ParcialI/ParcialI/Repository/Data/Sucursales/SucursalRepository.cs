using Npgsql;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.Sucursales
{
    public class SucursalRepository
    {
        private NpgsqlConnection connection;
        public SucursalRepository(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public void AddFact(SucursalModel sucursal)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Sucursal (idSucursal, descripcion, direccion, telefono, " +
                                      "wsp, email, estado) " +
                                      "VALUES (@idSucursal, @descripcion, @direccion, @telefono, @wsp, " +
                                      "@email, @estado)";
                    cmd.Parameters.AddWithValue("idSucursal", sucursal.idSucursal);
                    cmd.Parameters.AddWithValue("descripcion", sucursal.descripcion);
                    cmd.Parameters.AddWithValue("direccion", sucursal.direccion);
                    cmd.Parameters.AddWithValue("telefono", sucursal.telefono);
                    cmd.Parameters.AddWithValue("wsp", sucursal.wsp);
                    cmd.Parameters.AddWithValue("email", sucursal.email);
                    cmd.Parameters.AddWithValue("estado", sucursal.estado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActuSucursal(SucursalModel sucursal)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Factura SET idSucursal = @idSucursal, descripcion = @descripcion, " +
                                      "direccion = @direccion, telefono = @telefono, wsp = @wsp, " +
                                      "email = @email, estado = @estado" +
                                      "sucursal = @sucursal WHERE idSucursal = @idSucursal";
                    cmd.Parameters.AddWithValue("idSucursal", sucursal.idSucursal);
                    cmd.Parameters.AddWithValue("descripcion", sucursal.descripcion);
                    cmd.Parameters.AddWithValue("direccion", sucursal.direccion);
                    cmd.Parameters.AddWithValue("telefono", sucursal.telefono);
                    cmd.Parameters.AddWithValue("wsp", sucursal.wsp);
                    cmd.Parameters.AddWithValue("email", sucursal.email);
                    cmd.Parameters.AddWithValue("estado", sucursal.estado);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar(int idSucursal)
        {
            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Sucursal WHERE idSucursal = @idSucursal";
                    cmd.Parameters.AddWithValue("idSucursal", idSucursal);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SucursalModel> ListarSucursal()
        {
            List<SucursalModel> sucursales = new List<SucursalModel>(); 

            try
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Sucursal";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SucursalModel sucursalModel = new SucursalModel(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetString(5),
                                reader.GetString(6)
                            );
                            sucursales.Add(sucursalModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sucursales;
        }


    }
}
