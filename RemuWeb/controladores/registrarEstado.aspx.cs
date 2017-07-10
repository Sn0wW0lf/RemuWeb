using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarEstado : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAestado"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo estado trabajador";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                estadoTrabajador s = (from s1 in rwe.estadoTrabajador where s1.estado == Xsexo select s1).First();
                Session["mensaje"] = "Este estado de trabajador ya se encuentra registrado.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                estadoTrabajador s = new estadoTrabajador
                {
                    estado = Xsexo
                };
                rwe.AddObject("estadoTrabajador", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Estado trabajador registrado";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}