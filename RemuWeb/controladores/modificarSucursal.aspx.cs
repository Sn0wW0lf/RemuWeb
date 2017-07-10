using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarSucursal : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMsucursal"];
            int modificar = Convert.ToInt32(Request["sucursal"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo sucursal";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                sucursales s = (from s1 in rwe.sucursales where s1.id == modificar select s1).First();
                s.sucursal = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Sucursal Modificado";
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