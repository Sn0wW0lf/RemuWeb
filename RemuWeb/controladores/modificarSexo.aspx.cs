using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarSexo : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMsexo"];
            int modificar = Convert.ToInt32(Request["sexo"]);

            if(Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo sexo";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                sexo s = (from s1 in rwe.sexo where s1.id == modificar select s1).First();
                s.sexo1 = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Sexo Modificado";
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