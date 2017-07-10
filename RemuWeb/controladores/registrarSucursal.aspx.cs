using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarSucursal : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAsucursal"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo sucursal";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                sucursales s = (from s1 in rwe.sucursales where s1.sucursal == Xsexo select s1).First();
                Session["mensaje"] = "Esta sucursal ya se encuentra registrada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                sucursales s = new sucursales
                {
                    sucursal = Xsexo
                };
                rwe.AddObject("sucursales", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Sucursal registrada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}