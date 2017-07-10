using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class validarLogin : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xusuario = Request["txtUsuario"];
            string Xcontrasena = Request["txtContrasena"];

            if (Xusuario.Trim().Equals("") || Xcontrasena.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete todos los campos";
                Response.Redirect("../vistas/inicio.aspx");
            }
            else
            {
                try
                {
                    usuarios u = (from u1 in rwe.usuarios where u1.rutTrabajador == Xusuario && u1.contraseña == Xcontrasena select u1).First();
                    if (u != null)
                    {
                        Response.Redirect("../vistas/menuPrincipal.aspx");
                    }
                }
                catch (InvalidOperationException)
                {

                    Session["mensaje"] = "Usuario o contraseña incorrectos";
                    Response.Redirect("../vistas/inicio.aspx");
                }
            }
        }
    }
}