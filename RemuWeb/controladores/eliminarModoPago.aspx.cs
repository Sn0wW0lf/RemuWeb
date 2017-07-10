using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class eliminarModoPago : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            int eliminar = Convert.ToInt32(Request["modoP"]);

            try
            {
                modalidadesPago s = (from s1 in rwe.modalidadesPago where s1.id == eliminar select s1).First();
                rwe.DeleteObject(s);
                rwe.SaveChanges();
                Session["mensaje"] = "Modalida de pago Eliminada";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                Session["mensaje"] = "No se puede eliminar esta modalidad de pago porque esta siendo utilizada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}