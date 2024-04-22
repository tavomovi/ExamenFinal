using ExamenFinal.CapaDatos;
using ExamenFinal.CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamenFinal.Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            ClsAgente agente = new ClsAgente()
            {
                Email = txtUsername.Text,
                Pass = txtPassword.Text
            };
            int resultadoValidacion = Login_OP.ValidarLogin(agente);

            //Redirigir si el inicio de sesión es exitoso, mostrar una alerta de error si no lo es
            if (resultadoValidacion > 0)
            {
                Response.Redirect("~/Capa Presentacion/Inicio/Inicio.aspx");
            }
            else
            {
                string script = "alert('Correo o contraseña incorrectos');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
            }
        }


    }
}
