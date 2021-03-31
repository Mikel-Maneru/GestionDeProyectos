<%@ Page Title="Añadir Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AñadirEmpleado.aspx.cs" Inherits="GestionDeProyectos.AñadirEmpleado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form">  
            <table class="auto-style1">  
                <tr class="row-form">  
                    <td>Identificador: </td>  
                    <td>  
                        <asp:TextBox ID="txb_AIdentificadorEmpleado" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                <tr class="row-form">  
                    <td>Nombre: </td>  
                     <td> <asp:TextBox ID="txb_MNombreEmpleado" runat="server"></asp:TextBox></td>  
                </tr>  
                <tr class="row-form">  
                    <td>Apellidos: </td>  
                    <td>  
                        <asp:TextBox class="txb_long" ID="txb_AApellidosEmpleado" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr class="row-form">  
                    <td>Contraseña: </td>  
                    <td>  
                        <asp:TextBox ID="txb_MContraseñaEmpleado" runat="server" type="password"></asp:TextBox>
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Email: </td>  
                    <td>  
                        <asp:TextBox class="txb_long" ID="txb_AEmailEmpleado" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Mano de Obra: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="txb_AManoObraEmpleado" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Rol: </td>  
                    <td>  
                        <asp:DropDownList class="combobox" ID="cxb_ARolEmpleado" runat="server" /> 
                    </td>  
                </tr>
            </table>  
        </div> 

    <div class="bottom-button3">
                <asp:Button CssClass="add-button" OnClick="btnAdd_InsertEmpleado" runat="server" Text="Añadir"></asp:Button>
    </div>
</asp:Content>
