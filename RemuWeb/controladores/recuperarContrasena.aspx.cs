using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class recuperarContraseña : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xusuario = Request["txtUsuario2"];

            if (Xusuario.Trim().Equals(""))
            {
                Session["mensaje2"] = "Complete el campo usuario";
                Response.Redirect("../vistas/inicio.aspx");
            }
            else
            {
                try
                {
                    usuarios u = (from u1 in rwe.usuarios where u1.rutTrabajador == Xusuario select u1).First();
                    if (u != null)
                    {
                        Session["recuperar"] = "<br>Su indicio de recuperación de contraseña es: <h1>" + u.recuperacionContrasena + "</h1>Si no logra recuperar su contraseña, comuníquese con un administrador del sistema.";
                        Response.Redirect("../vistas/inicio.aspx");
                    }
                }
                catch (InvalidOperationException)
                {

                    Session["mensaje2"] = "El usuario no existe";
                    Response.Redirect("../vistas/inicio.aspx");
                }
            }
        }
    }
}