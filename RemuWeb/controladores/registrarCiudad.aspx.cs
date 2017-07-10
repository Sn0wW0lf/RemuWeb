using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarCiudad : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAciudad"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo ciudad";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                ciudades s = (from s1 in rwe.ciudades where s1.ciudad == Xsexo select s1).First();
                Session["mensaje"] = "Esta ciudad ya se encuentra registrada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                ciudades s = new ciudades
                {
                    ciudad = Xsexo
                };
                rwe.AddObject("ciudades", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Ciudad registrado";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}