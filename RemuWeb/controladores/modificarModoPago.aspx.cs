using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarModoPago : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMmodoP"];
            int modificar = Convert.ToInt32(Request["modoP"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo modalidad de pago";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {

                modalidadesPago s = (from s1 in rwe.modalidadesPago where s1.id == modificar select s1).First();
                s.modalidad = Xsexo;

                rwe.SaveChanges();
                Session["mensaje"] = "Modalidad de pago modificada";
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