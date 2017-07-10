using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemuWeb.controladores
{
    public partial class registrarTrabajador : System.Web.UI.Page
    {
        RemuWebEntities rwe = new RemuWebEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Xrut = Request["txtRutTrabajador"];
            string Xnombre = Request["txtNombre"];
            string XapellidoP = Request["txtApellidoP"];
            string XapellidoM = Request["txtApellidoM"];
            string XfechaNac = Request["txtFechaNac"];
            string XfechaIng = Request["txtFechaIng"];
            string XfechaTer = Request["txtFechaTer"];
            string Xsexo = Request["sexo"];
            string Xnacionalidad = Request["nacionalidad"];
            string Xsueldo = Request["txtSueldo"];
            string Xcargo = Request["cargo"];
            string Xdepto = Request["depto"];
            string XtipoC = Request["tipoC"];
            string XmodoP = Request["modoP"];
            string Xsucursal = Request["sucursal"];
            string Xestado = Request["estadoT"];
            string Xdireccion = Request["txtDireccion"];
            string Xcalle = Request["txtCalle"];
            string Xnumero = Request["txtNumero"];
            string Xciudad = Request["ciudad"];
            string Xcomuna = Request["comuna"];


            if (Xrut.Trim().Equals("") || Xnombre.Trim().Equals("") || XapellidoP.Trim().Equals("") || XapellidoM.Trim().Equals("") || XfechaNac.Trim().Equals("") ||
                XfechaIng.Trim().Equals("") || XfechaTer.Trim().Equals("") || Xsueldo.Trim().Equals("") || Xsucursal.Trim().Equals("") || Xdireccion.Trim().Equals("")
                 || Xcalle.Trim().Equals("") || Xnumero.Trim().Equals(""))
            {
                Session["mensaje"] = "Complete todos los campos";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }

            try
            {
                trabajadores t = (from t1 in rwe.trabajadores where t1.rutTrabajador == Xrut select t1).First();
                Session["mensaje"] = "Este RUT ya se encuentra registrado. Intente con otro.";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
            catch (InvalidOperationException)
            {
                trabajadores t = new trabajadores()
                {
                    rutTrabajador = Xrut,
                    nombre = Xnombre,
                    apellidoP = XapellidoP,
                    apellidoM = XapellidoM,
                    fechaNacimiento = XfechaNac,
                    fechaIngreso = XfechaIng,
                    fechaTermino = XfechaTer,
                    idSexo = Convert.ToInt32(Xsexo),
                    idNacionalidad = Convert.ToInt32(Xnacionalidad),
                    Sueldo = Convert.ToInt32(Xsueldo),
                    idCargo = Convert.ToInt32(Xcargo),
                    idDepartamento = Convert.ToInt32(Xdepto),
                    idTipoContrato = Convert.ToInt32(XtipoC),
                    idModoPago = Convert.ToInt32(XmodoP),
                    idSucursal = Convert.ToInt32(Xsucursal),
                    idEstadoTrabajador = Convert.ToInt32(Xestado)
                };
                rwe.AddObject("trabajadores", t);
                //rwe.SaveChanges();

                domicilios d = new domicilios()
                {
                    rutTrabajador = Xrut,
                    Direccion = Xdireccion,
                    calle = Xcalle,
                    numero = Convert.ToInt32(Xnumero),
                    idCiudad = Convert.ToInt32(Xciudad),
                    idComuna = Convert.ToInt32(Xcomuna),
                };
                rwe.AddObject("domicilios", d);
                rwe.SaveChanges();

                Session["mensaje"] = "Trabajador registrado";
                Response.Redirect("../vistas/registrarTrabajador.aspx");
            }
        }
    }
}