using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarSexo : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAsexo"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo sexo";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                sexo s = (from s1 in rwe.sexo where s1.sexo1 == Xsexo select s1).First();
                Session["mensaje"] = "Este sexo ya se encuentra registrado.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                sexo s = new sexo
                {
                    sexo1 = Xsexo
                };
                rwe.AddObject("sexo", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Sexo registrado";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}