<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="RemuWeb.vistas.inicio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bienvenido A RemuWeb</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>RemuWeb</h1>
    <h2>Login</h2>
        Usuario<asp:TextBox ID="txtUsuario" placeholder="RUT Trabajador" runat="server"></asp:TextBox>
        Contraseña<asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Logearse" PostBackUrl="~/controladores/validarLogin.aspx" />
        <br />
        <%Response.Write(Session["mensaje"]); Session.Remove("mensaje"); %>
        <br /><br /><br />

        <h2>Registro</h2>
        <h4>Solo los usuarios con privilegios de administrador pueden registrar usuarios.</h4>
        Ingrese los datos del usuario a registrar.
        <br />
        Usuario<asp:TextBox ID="txtUsuario3" placeholder="RUT Trabajador" runat="server"></asp:TextBox>
        Contraseña<asp:TextBox ID="txtContrasena2" runat="server" TextMode="Password"></asp:TextBox>
        Repetir contraseña<asp:TextBox ID="txtContrasena3" runat="server" TextMode="Password"></asp:TextBox>
        Recuperación Contraseña<asp:TextBox ID="txtRecup" placeholder="recordatorio contraseña" runat="server"></asp:TextBox>
        <br /><br /><br />
        Ingrese un usuario administrador y su contraseña.
        <br />
        Administrador<asp:TextBox ID="txtAdmin" placeholder="RUT Trabajador" runat="server"></asp:TextBox>
        Contraseña<asp:TextBox ID="txtContrasenaAdmin" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CheckBox ID="cbxAdmin" runat="server" />Administrador
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" PostBackUrl="~/controladores/validarRegistro.aspx" />
        <br />
        <% Response.Write(Session["mensaje3"]);
           Session.Remove("mensaje3");
           %>
        <br /><br /><br />

        <h2>Recuperar Contraseña</h2>
        Usuario<asp:TextBox ID="txtUsuario2" placeholder="RUT Trabajador" runat="server"></asp:TextBox>
        <asp:Button ID="btnRecup" runat="server" Text="Recuperar" PostBackUrl="~/controladores/recuperarContrasena.aspx" />
        <br />
        <% Response.Write(Session["recuperar"]);
           Response.Write(Session["mensaje2"]);
           Session.Remove("recuperar");
           Session.Remove("mensaje2");
           %>
    </div>
    </form>
</body>
</html>
