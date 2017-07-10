using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarCargo : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMcargo"];
            int modificar = Convert.ToInt32(Request["cargo"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo cargo";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                cargos s = (from s1 in rwe.cargos where s1.id == modificar select s1).First();
                s.cargo = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Cargo Modificado";
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