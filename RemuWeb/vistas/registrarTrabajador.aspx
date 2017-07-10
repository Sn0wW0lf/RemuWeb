<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registrarTrabajador.aspx.cs" Inherits="RemuWeb.vistas.registrarTrabajador" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bienvenido A RemuWeb</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Registrar Trabajador</h1>
        RUT Trabajador<asp:TextBox ID="txtRutTrabajador" runat="server"></asp:TextBox><br />
        Nombre<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><br />
        Apellido Paterno<asp:TextBox ID="txtApellidoP" runat="server"></asp:TextBox><br />
        Apellido Materno<asp:TextBox ID="txtApellidoM" runat="server"></asp:TextBox><br />
        Fecha Nacimiento<asp:TextBox ID="txtFechaNac" runat="server" TextMode="Date"></asp:TextBox><br />
        Fecha Ingreso<asp:TextBox ID="txtFechaIng" runat="server" TextMode="Date"></asp:TextBox><br />
        Fecha Termino<asp:TextBox ID="txtFechaTer" runat="server" TextMode="Date"></asp:TextBox><br />
        Sexo<select name="sexo"><%RemuWeb.RemuWebEntities rwe = new RemuWeb.RemuWebEntities();
          var sexos = (from s in rwe.sexo select s);
          foreach(var s1 in sexos)
          {%>
                <option value="<% =s1.id %>"><% =s1.sexo1 %></option>
          <%}
           %></select>Agregar Sexo<asp:TextBox ID="txtAsexo" runat="server"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="Registrar Sexo" PostBackUrl="~/controladores/registrarSexo.aspx" />
           Modificar Sexo<asp:TextBox ID="txtMsexo" runat="server"></asp:TextBox><asp:Button ID="Button11" runat="server" Text="Modificar Sexo" PostBackUrl="~/controladores/modificarSexo.aspx" />
           <asp:Button ID="Button10" runat="server" Text="Eliminar Sexo" PostBackUrl="~/controladores/eliminarSexo.aspx" /><br />
        Nacionalidad<select name="nacionalidad"><%
          var nacionalidades = (from n in rwe.nacionalidad select n);
          foreach(var n1 in nacionalidades)
          {%>
                <option value="<% =n1.id %>"><% =n1.nacionalidad1 %></option>
          <%}
           %></select>Agregar Nacionalidad<asp:TextBox ID="txtAnacionalidad" runat="server"></asp:TextBox><asp:Button ID="Button3" runat="server" Text="Registrar Nacionalidad" PostBackUrl="~/controladores/registrarNacionalidad.aspx" />
           Modificar Nacionalidad<asp:TextBox ID="txtMnacionalidad" runat="server"></asp:TextBox><asp:Button ID="Button12" runat="server" Text="Modificar Nacionalidad" PostBackUrl="~/controladores/modificarNacionalidad.aspx" />
           <asp:Button ID="Button13" runat="server" Text="Eliminar Nacionalidad" PostBackUrl="~/controladores/eliminarNacionalidad.aspx" /><br />
        Sueldo<asp:TextBox ID="txtSueldo" runat="server" TextMode="Number"></asp:TextBox><br />
        Cargo<select name="cargo"><%
          var cargos = (from c in rwe.cargos select c);
          foreach(var c1 in cargos)
          {%>
                <option value="<% =c1.id %>"><% =c1.cargo %></option>
          <%}
           %></select>Agregar Cargo<asp:TextBox ID="txtAcargo" runat="server"></asp:TextBox><asp:Button ID="Button4" runat="server" Text="Registrar Cargo" PostBackUrl="~/controladores/registrarCargo.aspx" />
           Modificar Cargo<asp:TextBox ID="txtMcargo" runat="server"></asp:TextBox><asp:Button ID="Button14" runat="server" Text="Modificar Cargo" PostBackUrl="~/controladores/modificarCargo.aspx" />
           <asp:Button ID="Button15" runat="server" Text="Eliminar Cargo" PostBackUrl="~/controladores/eliminarCargo.aspx" /><br />
        Departamento<select name="depto"><%
          var departamento = (from d in rwe.departamentos select d);
          foreach(var d1 in departamento)
          {%>
                <option value="<% =d1.id %>"><% =d1.departamento %></option>
          <%}
           %></select>Agregar Departamento<asp:TextBox ID="txtAdepto" runat="server"></asp:TextBox><asp:Button ID="Button5" runat="server" Text="Registrar Departamento" PostBackUrl="~/controladores/registrarDepartamento.aspx" />
           Modificar Departamento<asp:TextBox ID="txtMdepto" runat="server"></asp:TextBox><asp:Button ID="Button16" runat="server" Text="Modificar Departamento" PostBackUrl="~/controladores/modificarDepartamento.aspx" />
           <asp:Button ID="Button17" runat="server" Text="Eliminar departamento" PostBackUrl="~/controladores/eliminarDepartamento.aspx" /><br />
        Tipo Contrato<select name="tipoC"><%
          var tipoContrato = (from tc in rwe.tipoContrato select tc);
          foreach(var tc1 in tipoContrato)
          {%>
                <option value="<% =tc1.id %>"><% =tc1.tipoContrato1 %></option>
          <%}
           %></select>Agregar Tipo Contrato<asp:TextBox ID="txtAtipoC" runat="server"></asp:TextBox><asp:Button ID="Button6" runat="server" Text="Registrar Tipo Contrato" PostBackUrl="~/controladores/registrarTipoC.aspx" />
           Modificar Tipo Contrato<asp:TextBox ID="txtMtipoC" runat="server"></asp:TextBox><asp:Button ID="Button18" runat="server" Text="Modificar Tipo Contrato" PostBackUrl="~/controladores/modificarTipoC.aspx" />
           <asp:Button ID="Button19" runat="server" Text="Eliminar Tipo Contrato" PostBackUrl="~/controladores/eliminarTipoC.aspx" /><br />
        Modalidad de Pago<select name="modoP"><%
          var modoPago = (from mp in rwe.modalidadesPago select mp);
          foreach(var mp1 in modoPago)
          {%>
                <option value="<% =mp1.id %>"><% =mp1.modalidad %></option>
          <%}
           %></select>Agregar Modalidad Pago<asp:TextBox ID="txtAmodoP" runat="server"></asp:TextBox><asp:Button ID="Button7" runat="server" Text="Registrar Modalidad Pago" PostBackUrl="~/controladores/registrarModoP.aspx" />
           Modificar Modalidad Pago<asp:TextBox ID="txtMmodoP" runat="server"></asp:TextBox><asp:Button ID="Button20" runat="server" Text="Modificar Modalidad Pago" PostBackUrl="~/controladores/modificarModoPago.aspx" />
           <asp:Button ID="Button21" runat="server" Text="Eliminar Modalidad de Pago" PostBackUrl="~/controladores/eliminarModoPago.aspx" /><br />
        Sucursal<select name="sucursal"><%
          var sucursales = (from s in rwe.sucursales select s);
          foreach(var s1 in sucursales)
          {%>
                <option value="<% =s1.id %>"><% =s1.sucursal %></option>
          <%}
           %></select>Agregar Sucursal<asp:TextBox ID="txtAsucursal" runat="server"></asp:TextBox><asp:Button ID="Button8" runat="server" Text="Registrar Sucursal" PostBackUrl="~/controladores/registrarSucursal.aspx" />
           Modificar Sucursal<asp:TextBox ID="txtMsucursal" runat="server"></asp:TextBox><asp:Button ID="Button22" runat="server" Text="Modificar Sucursal" PostBackUrl="~/controladores/modificarSucursal.aspx" />
           <asp:Button ID="Button23" runat="server" Text="Eliminar Sucursal" PostBackUrl="~/controladores/eliminarSucursal.aspx" /><br />
        Estado Trabajador<select name="estadoT"><%
          var estadoT = (from et in rwe.estadoTrabajador select et);
          foreach(var et1 in estadoT)
          {%>
                <option value="<% =et1.id %>"><% =et1.estado %></option>
          <%}
           %></select>Agregar Estado Trabajador<asp:TextBox ID="txtAestado" runat="server"></asp:TextBox><asp:Button ID="Button9" runat="server" Text="Registrar Estado Trabajador" PostBackUrl="~/controladores/registrarEstado.aspx" />
           Modificar Estado Trabajador<asp:TextBox ID="txtMestado" runat="server"></asp:TextBox><asp:Button ID="Button24" runat="server" Text="Modificar Estado Trabajador" PostBackUrl="~/controladores/modificarEstado.aspx" />
           <asp:Button ID="Button25" runat="server" Text="Eliminar Estado Trabajador" PostBackUrl="~/controladores/eliminarEstado.aspx" /><br />
        <br /><br />
        Domicilio del Trabajador<br />
        Dirección<asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox><br />
        Calle<asp:TextBox ID="txtCalle" runat="server"></asp:TextBox><br />
        Número<asp:TextBox ID="txtNumero" runat="server" TextMode="Number"></asp:TextBox><br />
        Ciudad<select name="ciudad"><%
          var ciudades = (from c in rwe.ciudades select c);
          foreach(var c1 in ciudades)
          {%>
                <option value="<% =c1.id %>"><% =c1.ciudad %></option>
          <%}
           %></select>Agregar ciudad<asp:TextBox ID="txtAciudad" runat="server"></asp:TextBox><asp:Button ID="Button26" runat="server" Text="Registrar Ciudad" PostBackUrl="~/controladores/registrarCiudad.aspx" />
           Modificar Ciudad<asp:TextBox ID="txtMciudad" runat="server"></asp:TextBox><asp:Button ID="Button27" runat="server" Text="Modificar Ciudad" PostBackUrl="~/controladores/modificarCiudad.aspx" />
           <asp:Button ID="Button28" runat="server" Text="Eliminar Ciudad" PostBackUrl="~/controladores/eliminarCiudad.aspx" /><br />

           Comuna<select name="comuna"><%
          var comunas = (from c in rwe.comunas select c);
          foreach(var c1 in comunas)
          {%>
                <option value="<% =c1.id %>"><% =c1.comuna %></option>
          <%}
           %></select>Agregar comuna<asp:TextBox ID="txtAcomuna" runat="server"></asp:TextBox><asp:Button ID="Button29" runat="server" Text="Registrar Comuna" PostBackUrl="~/controladores/registrarComuna.aspx" />
           Modificar Comuna<asp:TextBox ID="txtMcomuna" runat="server"></asp:TextBox><asp:Button ID="Button30" runat="server" Text="Modificar Comuna" PostBackUrl="~/controladores/modificarComuna.aspx" />
           <asp:Button ID="Button31" runat="server" Text="Eliminar Ciudad" PostBackUrl="~/controladores/eliminarComuna.aspx" /><br />

        <asp:Button ID="Button1" runat="server" Text="Registrar Trabajador" PostBackUrl="~/controladores/registrarTrabajador.aspx" />
        <br /><br />
        <% Response.Write(Session["mensaje"]);
           Session.Remove("mensaje");
           %>
    </div>
    </form>
</body>
</html>
