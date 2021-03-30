<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GestionDeProyectos._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <div class="main-content">
        <div class="titles"><a href="Partes.aspx">
            <h4>Partes</h4>
            <div class="about-border"></div>
                  </a>
        </div>
        <div class="titles-2"><a href="Gastos.aspx">
            <h4>Gastos</h4>
            <div class="about-border"></div>
             </a>
        </div>
     
    </div>
     
    <div class="bottom">
        <div class="bottom-content">Consulta Proyectos</div>
        <div class="bottom-footer">
            <label class="select" for="slct"><span class="informe">Informe&ensp;</span><select id="slct" >
        <option value="" disabled="disabled" selected="selected" >Selecciona Algo</option>
        <option value="#">hola</option>
        <option value="#">hola</option>
        <option value="#">hola</option>
        <option value="#">hola</option>
        <option value="#">hola</option>
        <option value="#">hola</option>
        <option value="#">hola</option>
    </select><br>
            <label class="label1">Desde </label> <input type="text"  class="fecha" onfocus="(this.type='date')" value="<%= DateTime.Now.ToString("dd/MM/yyyy") %>"></input>&ensp;
            <label class="label1">Hasta </label> <input type="text" onfocus="(this.type='date')" value="<%= DateTime.Now.ToString("dd/MM/yyyy")  %>"></input>
            <div class="bottom-button from-center">
                <button>Generar</button>
            </div>
        </div>

    </div> 
     <div id="myModal" class="modal" data-keyboard="false" data-backdrop="static">
       <div class="main-content-signIn">        
        <label>Iniciar Sesion:</label><br><asp:TextBox ID="TextBox1" runat="server" CssClass="one"></asp:TextBox><br><br>
        <label>Contraseña:</label><br><asp:TextBox ID="TextBox2" runat="server" CssClass="one" TextMode="Password"></asp:TextBox>
        <div class="bottom-button-iniciar-sesion">
            <asp:Button ID="button1" runat="server" CssClass="button" Text="Adelante" OnClick="btn_login_Click" />
           
        </div>
        </div>
    </div>
         <script>
             function show() {
                 $("#myModal").modal('show');
             };
             function disableWindow() {
                 $('#myModal').delay(500).fadeOut('slow');
                 setTimeout(function () {
                     $("#myModal").modal('hide');
                 }, 1000);

             };
         </script>
</asp:Content>

