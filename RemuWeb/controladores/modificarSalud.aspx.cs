using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarSalud : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMsalud"];
            int modificar = Convert.ToInt32(Request["salud"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo salud";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {

                salud s = (from s1 in rwe.salud where s1.id == modificar select s1).First();
                s.tipoSalud = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Salud Modificada";
                Response.Redirect("../vistas/saludAfp.aspx");

            }
            catch (InvalidOperationException)
            {
                Session["mensaje"] = "Se ha producido un error. Intentelo nuevamente";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
        }
    }
}