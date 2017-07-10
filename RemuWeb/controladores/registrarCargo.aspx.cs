using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarCargo : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAcargo"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo cargo";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                cargos s = (from s1 in rwe.cargos where s1.cargo == Xsexo select s1).First();
                Session["mensaje"] = "Este cargo ya se encuentra registrado.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                cargos s = new cargos
                {
                    cargo = Xsexo
                };
                rwe.AddObject("cargos", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Cargo registrado";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}