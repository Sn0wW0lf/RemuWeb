using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarSalud : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAsalud"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo salud";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                salud s = (from s1 in rwe.salud where s1.tipoSalud == Xsexo select s1).First();
                Session["mensaje"] = "Esta salud ya se encuentra registrada.";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
            catch (InvalidOperationException)
            {
                salud s = new salud
                {
                    tipoSalud = Xsexo
                };
                rwe.AddObject("salud", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Salud registrada";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
        }
    }
}