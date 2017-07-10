using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarDepartamento : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMdepto"];
            int modificar = Convert.ToInt32(Request["depto"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo departamento";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                departamentos s = (from s1 in rwe.departamentos where s1.id == modificar select s1).First();
                s.departamento = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Departamento Modificado";
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