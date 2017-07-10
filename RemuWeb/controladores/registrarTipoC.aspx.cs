using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarTipoC : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAtipoC"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo tipo de contrato";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                tipoContrato tc = (from tc1 in rwe.tipoContrato where tc1.tipoContrato1 == Xsexo select tc1).First();
                Session["mensaje"] = "Este tipo de contrato ya se encuentra registrado.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                tipoContrato tc = new tipoContrato
                {
                    tipoContrato1 = Xsexo
                };
                rwe.AddObject("tipoContrato", tc);
                rwe.SaveChanges();
                Session["mensaje"] = "Tipo de contrato registrado.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}