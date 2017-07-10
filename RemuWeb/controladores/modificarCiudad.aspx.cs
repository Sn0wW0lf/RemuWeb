using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarCiudad : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMciudad"];
            int modificar = Convert.ToInt32(Request["ciudad"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo ciudad";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                ciudades s = (from s1 in rwe.ciudades where s1.id == modificar select s1).First();
                s.ciudad = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Ciudad Modificada";
                Response.Redirect("../vistas/registrarTrabajador.aspx");

            }
            catch (InvalidOperationException)
            {
                Session["mensaje"] = "Se ha producido un error. Intentelo nuevamente";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}