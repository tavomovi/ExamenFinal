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
using ExamenFinal.CapaLogica;

namespace ExamenFinal.Capa_Presentacion
{
    public partial class Agente_Vista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridAgentes();
            }

        }

        protected void LlenarGridAgentes()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {

                string query = "Select ID, Nombre, Email, Telefono from Agentes";
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

            txtAgenteID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtPass.Text = string.Empty;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ClsAgente agente = new ClsAgente();
            agente.Nombre = txtNombre.Text;
            agente.Email = txtEmail.Text;
            agente.Telefono = txtTelefono.Text;
            agente.Pass = txtPass.Text;

            Agente_OP agenteop = new Agente_OP();

            int resultado = agenteop.AgregarAgente(agente);

            if (resultado > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Agente ingresado con éxito');", true);
                LimpiarCampos();
                LlenarGridAgentes();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Error al ingresar Agente');", true);
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ClsAgente agente = new ClsAgente();

            agente.ID = int.Parse(txtAgenteID.Text);
            agente.Nombre = txtNombre.Text;
            agente.Email = txtEmail.Text;
            agente.Telefono = txtTelefono.Text;
            agente.Pass = txtPass.Text;

            Agente_OP agenteop = new Agente_OP();

            int resultado = agenteop.ModificarAgente(agente);

            if (resultado > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Agente ingresado con éxito');", true);
                LimpiarCampos();
                LlenarGridAgentes();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Error al ingresar agente');", true);
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int agenteID = int.Parse(txtAgenteID.Text);
                Agente_OP agenteop = new Agente_OP();
                agenteop.EliminarAgente(agenteID);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Agente eliminado con éxito');", true);
            }
            catch (FormatException)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Por favor, ingrese un ID de agente válido.');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertScript", "alert('Se produjo un error al eliminar el agente: " + ex.Message + "');", true);
            }
            LlenarGridAgentes();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Capa Presentacion/Inicio/Inicio.aspx");
        }
    }
}