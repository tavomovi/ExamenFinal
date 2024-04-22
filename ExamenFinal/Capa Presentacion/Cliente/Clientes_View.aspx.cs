using ExamenFinal.CapaLogica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExamenFinal.CapaDatos;

namespace ExamenFinal.Capa_Presentacion
{
    public partial class Clientes_View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridClientes();
            }
        }

        protected void LlenarGridClientes()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                string query = "Select * from clientes";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gvClientes.DataSource = dt;
                            gvClientes.DataBind();
                        }
                    }
                }
            }
        }

        protected void LimpiarCampos()
        {
            
            txtClienteID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ClsCliente cliente = new ClsCliente();
            cliente.Nombres = txtNombre.Text;
            cliente.Correo = txtEmail.Text;
            cliente.Telefono = txtTelefono.Text;
            Cliente_OP clienteop = new Cliente_OP();

            int resultado = clienteop.AgregarCliente(cliente);

            if (resultado > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Cliente ingresado con éxito');", true);
                LimpiarCampos();
                LlenarGridClientes();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Error al ingresar cliente');", true);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteId = int.Parse(txtClienteID.Text);
                Cliente_OP clienteOp = new Cliente_OP();
                clienteOp.EliminarCliente(clienteId);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Cliente eliminado con éxito');", true);
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Por favor, ingrese un ID de cliente válido.');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Se produjo un error al eliminar el cliente: " + ex.Message + "');", true);
            }
            LlenarGridClientes();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ClsCliente cliente = new ClsCliente();

            cliente.IdCliente = int.Parse(txtClienteID.Text);
            cliente.Nombres = txtNombre.Text;
            cliente.Correo = txtEmail.Text;
            cliente.Telefono = txtTelefono.Text;
            Cliente_OP clienteop = new Cliente_OP();

            int resultado = clienteop.ModificarCliente(cliente);

            if (resultado > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Cliente ingresado con éxito');", true);
                LimpiarCampos();
                LlenarGridClientes();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Error al ingresar cliente');", true);
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capa Presentacion/Inicio/Inicio.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }
    }
}