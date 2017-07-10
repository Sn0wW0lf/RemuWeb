using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class eliminarDepartamento : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            int eliminar = Convert.ToInt32(Request["depto"]);

            try
            {
                departamentos s = (from s1 in rwe.departamentos where s1.id == eliminar select s1).First();
                rwe.DeleteObject(s);
                rwe.SaveChanges();
                Session["mensaje"] = "Departamento Eliminado";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                Session["mensaje"] = "No se puede eliminar este departamento porque esta siendo utilizado.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}