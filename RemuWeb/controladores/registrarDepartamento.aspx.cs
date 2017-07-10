using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarDepartamento : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAdepto"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete el campo departamento";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                departamentos s = (from s1 in rwe.departamentos where s1.departamento == Xsexo select s1).First();
                Session["mensaje"] = "Este departamento ya se encuentra registrado.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                departamentos s = new departamentos
                {
                    departamento = Xsexo
                };
                rwe.AddObject("departamentos", s);
                rwe.SaveChanges();
                Session["mensaje"] = "Departamento registrado";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}