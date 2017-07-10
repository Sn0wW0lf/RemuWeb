using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarAfp : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xsexo = Request["txtAafp"];

            if (Xsexo.Trim().Equals(""))
            {
                Session["mensaje2"] = "Complete el campo AFP";
                Response.Redirect("../vistas/saludAfp.aspx");
            }

            try
            {
                afp s = (from s1 in rwe.afp where s1.tipoAfp == Xsexo select s1).First();
                Session["mensaje2"] = "Esta AFP ya se encuentra registrada.";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
            catch (InvalidOperationException)
            {
                afp s = new afp
                {
                    tipoAfp = Xsexo
                };
                rwe.AddObject("afp", s);
                rwe.SaveChanges();
                Session["mensaje2"] = "AFP registrada";
                Response.Redirect("../vistas/saludAfp.aspx");
            }
        }
    }
}