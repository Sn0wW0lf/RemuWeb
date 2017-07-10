<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="saludAfp.aspx.cs" Inherits="RemuWeb.vistas.saludAfp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Registro Salud y AFP</h1>
    <h3>Plan de Salud</h3>
    <br />
    Tipo Salud<select name="salud"><%RemuWeb.RemuWebEntities rwe = new RemuWeb.RemuWebEntities();
          var salud = (from s in rwe.salud select s);
          foreach(var s1 in salud)
          {%>
                <option value="<% =s1.id %>"><% =s1.tipoSalud %></option>
          <%}
           %></select>Agregar Tipo Salud<asp:TextBox ID="txtAsalud" runat="server"></asp:TextBox><asp:Button ID="Button2" runat="server" Text="Registrar Salud" PostBackUrl="~/controladores/registrarSalud.aspx" />
           Modificar Salud<asp:TextBox ID="txtMsalud" runat="server"></asp:TextBox><asp:Button ID="Button11" runat="server" Text="Modificar Salud" PostBackUrl="~/controladores/modificarSalud.aspx" />
           <asp:Button ID="Button10" runat="server" Text="Eliminar Salud" PostBackUrl="~/controladores/eliminarSalud.aspx" /><br />

           Descuento<asp:TextBox ID="txtDescuento" runat="server"></asp:TextBox><br />
           Monto Adicional<asp:TextBox ID="txtAdicional" runat="server"></asp:TextBox><br />
           RUT Trabajador<asp:TextBox ID="txtRut" runat="server"></asp:TextBox><br />

           <asp:Button ID="Button1" runat="server" Text="Registrar Plan de Salud" PostBackUrl="~/controladores/registrarPlanSalud.aspx" />

           <% Response.Write(Session["mensaje"]);
           Session.Remove("mensaje");
           %>

           <br /><br /><br />
           <h3>Plan de AFP</h3>
           Tipo AFP<select name="afp"><%
          var afp = (from s in rwe.afp select s);
          foreach(var s1 in afp)
          {%>
                <option value="<% =s1.id %>"><% =s1.tipoAfp %></option>
          <%}
           %></select>Agregar Tipo AFP<asp:TextBox ID="txtAafp" runat="server"></asp:TextBox><asp:Button ID="Button3" runat="server" Text="Registrar AFP" PostBackUrl="~/controladores/registrarAfp.aspx" />
           Modificar AFP<asp:TextBox ID="txtMafp" runat="server"></asp:TextBox><asp:Button ID="Button4" runat="server" Text="Modificar AFP" PostBackUrl="~/controladores/modificarAfp.aspx" />
           <asp:Button ID="Button5" runat="server" Text="Eliminar AFP" PostBackUrl="~/controladores/eliminarAfp.aspx" /><br />

           Descuento<asp:TextBox ID="txtDescuento2" runat="server"></asp:TextBox><br />
           APV<asp:TextBox ID="txtApv" runat="server" TextMode="Number"></asp:TextBox><br />
           RUT Trabajador<asp:TextBox ID="txtRut2" runat="server"></asp:TextBox><br />

           <asp:Button ID="Button6" runat="server" Text="Registrar Plan de AFP" PostBackUrl="~/controladores/registrarPlanAfp.aspx" />

           <% Response.Write(Session["mensaje2"]);
           Session.Remove("mensaje2");
           %>
    </div>
    </form>
</body>
</html>
