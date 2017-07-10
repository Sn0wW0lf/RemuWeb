using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarComuna : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAcomuna"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo comuna";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                comunas s = (from s1 in rwe.comunas where s1.comuna == Xsexo select s1).First();
                Session["mensaje"] = "Esta comuna ya se encuentra registrada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                comunas s = new comunas
                {
                    comuna = Xsexo
                };
                rwe.AddObject("comunas", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Comuna registrada";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}