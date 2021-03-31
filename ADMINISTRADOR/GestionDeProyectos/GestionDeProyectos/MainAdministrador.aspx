<%@ Page Title="Administrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainAdministrador.aspx.cs" Inherits="GestionDeProyectos.MainAdministrador" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
   <div class="div-container-form3">
       <div class="flex-containter"><h1 style="float:left; margin-top:0.9em;">Partes de Trabajo</h1></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Añadir"></input></div>
       </div>
       <hr />

       <div class="flex-containter"><h1 style="float:left; margin-top:0.9em;">Proyectos</h1></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Añadir" onclick="location.href='AñadirProyecto.aspx';"></input></div>
           <div><input type="button" class="main-button" value="Modificar" onclick="location.href='ModificarProyecto.aspx';"></input></div>
       </div>
       <hr />

       <div class="flex-containter"><h1 style="float:left; margin-top:0.9em;">Clientes</h1></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Añadir" onclick="location.href='AñadirCliente.aspx';"></input></div>
           <div><input type="button" class="main-button" value="Modificar" onclick="location.href='ModificarCliente.aspx';"></input></div>
       </div>
       <hr />

       <div class="flex-containter"><h1 style="float:left; margin-top:0.9em;">Centro de Coste</h1></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Añadir" onclick="location.href='AñadirCentroCoste.aspx';"></input></div>
           <div><input type="button" class="main-button" value="Modificar" onclick="location.href='ModificarCentroCoste.aspx';"></input></div>
       </div>
       <hr />

       <div class="flex-containter"><h1 style="float:left; margin-top:0.9em;">Consulta Proyectos</h1></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Informe"></input></div>
       </div>
       <hr />

       <div class="flex-containter"><h1 style="float:left; margin-top:0.9em;">Cierre Partes</h1></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Cierre"></input></div>
       </div>
       <hr />

       <div class="flex-containter"><div><h1 style="float:left; margin-top:0.9em;">Negocio</h1></div></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Añadir" onclick="location.href='AñadirNegocio.aspx';"></input></div>
           <div><input type="button" class="main-button" value="Modificar" onclick="location.href='ModificarNegocio.aspx';"></input></div>
       </div>
       <hr />
       
       <div class="flex-containter"><h1 style="float:left; margin-top:0.9em;">Empleados</h1></div>
       <div class="flex-right">
           <div><input type="button" class="main-button" value="Añadir" onclick="location.href='AñadirEmpleado.aspx';"></input></div>
           <div><input type="button" class="main-button" value="Modificar" onclick="location.href='ModificarEmpleado.aspx';"></input></div>
       </div>
   </div>
</asp:Content>
