using ExamenFinal.CapaDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenFinal.CapaLogica
{
    public class Cliente_OP
    {
        private readonly SqlConnection sqlConnection;

        public Cliente_OP()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        public int AgregarCliente(ClsCliente cliente)
        {
            int resultado = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("GestionarClientes", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "agregar");
                    command.Parameters.AddWithValue("@cliente_nombre", cliente.Nombres);
                    command.Parameters.AddWithValue("@cliente_email", cliente.Correo);
                    command.Parameters.AddWithValue("@cliente_telefono", cliente.Telefono);

                    sqlConnection.Open();
                    resultado = command.ExecuteNonQuery();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int ModificarCliente(ClsCliente cliente)
        {
            int resultado = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("GestionarClientes", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "modificar");
                    command.Parameters.AddWithValue("@cliente_id", cliente.IdCliente);
                    command.Parameters.AddWithValue("@cliente_nombre", cliente.Nombres);
                    command.Parameters.AddWithValue("@cliente_email", cliente.Correo);
                    command.Parameters.AddWithValue("@cliente_telefono", cliente.Telefono);

                    sqlConnection.Open();
                    resultado = command.ExecuteNonQuery();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el cliente: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void EliminarCliente(int idCliente)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("GestionarClientes", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "borrar");
                    command.Parameters.AddWithValue("@cliente_id", idCliente);

                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }





    }
   
}