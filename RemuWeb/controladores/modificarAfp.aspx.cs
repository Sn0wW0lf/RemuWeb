using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class modificarAfp : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtMafp"];
            int modificar = Convert.ToInt32(Request["afp"]);

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje2"] = "Complete el campo AFP";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {

                afp s = (from s1 in rwe.afp where s1.id == modificar select s1).First();
                s.tipoAfp = Xsexo;

                rwe.SaveChanges();
                Session["mensaje2"] = "AFP Modificada";
                Response.Redirect("../vistas/saludAfp.aspx");

            }
            catch (InvalidOperationException)
            {
                Session["mensaje2"] = "Se ha producido un error. Intentelo nuevamente";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
        }
    }
}