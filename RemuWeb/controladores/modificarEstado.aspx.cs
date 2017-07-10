using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarEstado : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMestado"];
            int modificar = Convert.ToInt32(Request["estadoT"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo estado trabajador";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                estadoTrabajador s = (from s1 in rwe.estadoTrabajador where s1.id == modificar select s1).First();
                s.estado = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Estado trabajador Modificado";
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