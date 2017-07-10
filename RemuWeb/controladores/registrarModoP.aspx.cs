using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarModoP : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAmodoP"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo modalida de pago";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                modalidadesPago s = (from s1 in rwe.modalidadesPago where s1.modalidad == Xsexo select s1).First();
                Session["mensaje"] = "Esta modalidad de pago ya se encuentra registrada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                modalidadesPago s = new modalidadesPago
                {
                    modalidad = Xsexo
                };
                rwe.AddObject("modalidadesPago", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Modalidad de pago registrada.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}