using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using ExamenFinal.CapaDatos;
using System.Configuration;

namespace ExamenFinal.CapaLogica
{
    public class Agente_OP
    {
        private readonly SqlConnection sqlConnection;

        public Agente_OP()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }

        public int AgregarAgente(ClsAgente agente)
        {
            int resultado = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("GestionarAgentes", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "agregar");
                    command.Parameters.AddWithValue("@agente_nombre", agente.Nombre);
                    command.Parameters.AddWithValue("@agente_email", agente.Email);
                    command.Parameters.AddWithValue("@agente_telefono", agente.Telefono);
                    command.Parameters.AddWithValue("@agente_pass", agente.Pass);

                    sqlConnection.Open();
                    resultado = command.ExecuteNonQuery();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el Agente: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int ModificarAgente(ClsAgente agente)
        {
            int resultado = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("GestionarAgentes", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "modificar");
                    command.Parameters.AddWithValue("@agente_id", agente.ID);
                    command.Parameters.AddWithValue("@agente_nombre", agente.Nombre);
                    command.Parameters.AddWithValue("@agente_email", agente.Email);
                    command.Parameters.AddWithValue("@agente_telefono", agente.Telefono);
                    command.Parameters.AddWithValue("@agente_pass", agente.Pass);

                    sqlConnection.Open();
                    resultado = command.ExecuteNonQuery();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el agente: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void EliminarAgente(int idAgente)  
        {
            try
            {
                using (SqlCommand command = new SqlCommand("GestionarAgentes", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accion", "borrar");
                    command.Parameters.AddWithValue("@agente_id", idAgente);

                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Agente: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }





    }

}
