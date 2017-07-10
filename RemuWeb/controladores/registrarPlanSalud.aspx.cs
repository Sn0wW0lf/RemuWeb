using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarPlanSalud : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsalud = Request["salud"];
            string Xdescuento = Request["txtDescuento"];
            string Xadicional = Request["txtAdicional"];
            string Xrut = Request["txtRut"];
            double descuento = 0;
            double adicional = 0;

            try
            {
                if (Xsalud.Trim().Equals("") || Xdescuento.Trim().Equals("") || Xadicional.Trim().Equals("") || Xrut.Trim().Equals(""))
                {
                    Session["mensaje"] = "Complete todos los campos";
                    Response.Redirect("../vistas/saludAfp.aspx");
                }
            }
            catch (NullReferenceException)
            {
                Session["mensaje"] = "Complete todos los campos";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                trabajadores t = (from t1 in rwe.trabajadores where t1.rutTrabajador == Xrut select t1).First();
            }
            catch (InvalidOperationException)
            {
                Session["mensaje"] = "RUT de trabajador no existente";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                if(Xdescuento.Contains(".") || Xadicional.Contains("."))
                {
                    Session["mensaje"] = "Los valores para descuento y monto adicional solo deben ser números y ser separados con coma (,) ejemplo: 1,2 ";
                    Response.Redirect("../vistas/saludAfp.aspx");
                }

                descuento = Convert.ToDouble(Xdescuento);
                adicional = Convert.ToDouble(Xadicional);
            }
            catch (FormatException)
            {
                Session["mensaje"] = "Los valores para descuento y monto adicional deber ser separados con coma (,) ejemplo: 1,2 ";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                planesSalud ps = (from ps1 in rwe.planesSalud where ps1.rutTrabajador == Xrut select ps1).First();
                Session["mensaje"] = "Este RUT ya registra un plan de salud. Intente con otro.";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
            catch (InvalidOperationException)
            {
                planesSalud ps = new planesSalud()
                {
                    idSalud = Convert.ToInt32(Xsalud),
                    porcientoDescuento = descuento,
                    montoAdicional = adicional,
                    rutTrabajador = Xrut
                };
                rwe.AddObject("planesSalud", ps);
                rwe.SaveChanges();

                Session["mensaje"] = "Plan de salud registrado.";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
        }
    }
}