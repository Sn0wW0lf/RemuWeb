using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarPlanAfp : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xafp = Request["afp"];
            string Xdescuento = Request["txtDescuento2"];
            string Xapv = Request["txtApv"];
            string Xrut = Request["txtRut2"];
            double descuento = 0;

            try
            {
                if (Xafp.Trim().Equals("") || Xdescuento.Trim().Equals("") || Xapv.Trim().Equals("") || Xrut.Trim().Equals(""))
                {
                    Session["mensaje2"] = "Complete todos los campos";
                    Response.Redirect("../vistas/saludAfp.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Session["mensaje2"] = "Complete todos los campos";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                trabajadores t = (from t1 in rwe.trabajadores where t1.rutTrabajador == Xrut select t1).First();
            }
            catch (InvalidOperationException)
            {
                Session["mensaje2"] = "RUT de trabajador no existente";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                if (Xdescuento.Contains("."))
                {
                    Session["mensaje2"] = "Los valores para descuento solo deben ser números y ser separados con coma (,) ejemplo: 1,2";
                    Response.Redirect("../vistas/saludAfp.aspx");
                }

                descuento = Convert.ToDouble(Xdescuento);
            }
            catch (FormatException)
            {
                Session["mensaje2"] = "Los valores para descuento deben ser separados con coma (,) ejemplo: 1,2";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                planesAfp ps = (from ps1 in rwe.planesAfp where ps1.rutTrabajador == Xrut select ps1).First();
                Session["mensaje2"] = "Este RUT ya registra un plan de AFP. Intente con otro.";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
            catch (InvalidOperationException)
            {
                planesAfp ps = new planesAfp()
                {
                    idAfp = Convert.ToInt32(Xafp),
                    porcientoDescuento = descuento,
                    apv = Convert.ToInt32(Xapv),
                    rutTrabajador = Xrut
                };
                rwe.AddObject("planesAfp", ps);
                rwe.SaveChanges();

                Session["mensaje2"] = "Plan de AFP registrado.";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

        }
    }
}