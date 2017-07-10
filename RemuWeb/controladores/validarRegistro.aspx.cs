using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class validarRegistro : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xusuario = Request["txtUsuario3"];
            string Xcontrasena = Request["txtContrasena2"];
            string Xcontrasena2 = Request["txtContrasena3"];
            string Xrecup = Request["txtRecup"];
            string Xadmin = Request["txtAdmin"];
            string XcontrasenaAdmin = Request["txtContrasenaAdmin"];

            if (Xusuario.Trim().Equals("") || Xcontrasena.Trim().Equals("") || Xcontrasena2.Trim().Equals("") || Xrecup.Trim().Equals("") || Xadmin.Trim().Equals("") || XcontrasenaAdmin.Trim().Equals(""))
            {
                Session["mensaje3"] = "Complete todos los campos";
                Response.Redirect("../vistas/inicio.aspx");
            }
            else
            {
                try
                {
                    trabajadores t = (from t1 in rwe.trabajadores where t1.rutTrabajador == Xusuario select t1).First();
                }
                catch (InvalidOperationException)
                {

                    Session["mensaje3"] = "RUT de trabajador no existente";
                    Response.Redirect("../vistas/inicio.aspx");
                }

                try
                {
                    usuarios u = (from u1 in rwe.usuarios where u1.rutTrabajador == Xusuario select u1).First();
                    if (u != null)
                    {
                        Session["mensaje3"] = "Este RUT ya se encuentra registrado. Intente con otro.";
                        Response.Redirect("../vistas/inicio.aspx");
                    }
                }
                catch (InvalidOperationException)
                {
                    try
                    {
                        usuarios u = (from u1 in rwe.usuarios where u1.rutTrabajador == Xadmin select u1).First();
                        string adm = "u";

                        if(Xcontrasena!=Xcontrasena2)
                        {
                            Session["mensaje3"] = "Las contraseñas ingresadas son distintas";
                            Response.Redirect("../vistas/inicio.aspx");
                        }

                        if (Request["cbxAdmin"] != null)
                        {
                            adm = "a";
                        }

                        if (u.contraseña.Equals(XcontrasenaAdmin) && u.tipoUsuario.Equals("a"))
                        {
                            usuarios us = new usuarios()
                            {
                                rutTrabajador = Xusuario,
                                contraseña = Xcontrasena,
                                recuperacionContrasena = Xrecup,
                                tipoUsuario = adm
                            };
                            rwe.AddObject("usuarios", us);
                            rwe.SaveChanges();
                            Session["mensaje3"] = "Usuario registrado";
                            Response.Redirect("../vistas/inicio.aspx");
                        }
                        if (!u.contraseña.Equals(XcontrasenaAdmin) && u.tipoUsuario.Equals("a"))
                        {
                            Session["mensaje3"] = "Error de contraseña de administrador";
                            Response.Redirect("../vistas/inicio.aspx");
                        }
                        if (!u.tipoUsuario.Equals("a"))
                        {
                            Session["mensaje3"] = "Este usuario no cuenta con privilegios de administrador.";
                            Response.Redirect("../vistas/inicio.aspx");
                        }

                    }
                    catch (InvalidOperationException)
                    {
                        Session["mensaje3"] = "El administrador ingresado no existe";
                        Response.Redirect("../vistas/inicio.aspx");
                    }
                }
            }
        }
    }
}