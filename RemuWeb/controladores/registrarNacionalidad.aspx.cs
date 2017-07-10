using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarNacionalidad : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAnacionalidad"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo nacionalidad";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                nacionalidad s = (from s1 in rwe.nacionalidad where s1.nacionalidad1 == Xsexo select s1).First();
                Session["mensaje"] = "Esta nacionalidad ya se encuentra registrada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                nacionalidad s = new nacionalidad
                {
                    nacionalidad1 = Xsexo
                };
                rwe.AddObject("nacionalidad", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Nacionalidad registrada";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}