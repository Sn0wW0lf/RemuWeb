using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class eliminarAfp : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            int eliminar = Convert.ToInt32(Request["afp"]);

            try
            {
                afp s = (from s1 in rwe.afp where s1.id == eliminar select s1).First();
                rwe.DeleteObject(s);
                rwe.SaveChanges();
                Session["mensaje2"] = "AFP Eliminada";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
            catch (InvalidOperationException)
            {
                Session["mensaje"] = "No se puede eliminar esta AFP porque esta siendo utilizada.";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
        }
    }
}