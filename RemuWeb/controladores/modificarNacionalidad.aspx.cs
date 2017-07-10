using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarNacionalidad : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMnacionalidad"];
            int modificar = Convert.ToInt32(Request["nacionalidad"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo sexo";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                nacionalidad s = (from s1 in rwe.nacionalidad where s1.id == modificar select s1).First();
                s.nacionalidad1 = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Nacionalidad Modificada";
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