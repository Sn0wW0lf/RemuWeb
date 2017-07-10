using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarComuna : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMcomuna"];
            int modificar = Convert.ToInt32(Request["comuna"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo comuna";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                comunas s = (from s1 in rwe.comunas where s1.id == modificar select s1).First();
                s.comuna = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Comuna Modificado";
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