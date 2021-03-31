<%@ Page Title="Modificar Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AñadirCliente.aspx.cs" Inherits="GestionDeProyectos.AñadirCliente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form">  
            <table class="auto-style1">  
                <tr class="row-form">  
                    <td>Identificador: </td>  
                    <td>  
                        <asp:TextBox ID="tbx_AIdentificadorCliente" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                <tr class="row-form">  
                    <td>CIF: </td>  
                     <td> <asp:TextBox ID="tbx_ACIFCliente" runat="server"  class="txb"></asp:TextBox></td>  
                </tr>  
                <tr class="row-form">  
                    <td>Nombre: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_ANombreCliente" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr class="row-form">  
                    <td>Dirección: </td>  
                    <td>  
                        <textarea  class="txb_long" ID="tbx_ADireccionCliente" runat="server"></textarea>
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Teléfono: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_ATelefonoCliente" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Email: </td>  
                    <td>  
                        <asp:TextBox class="txb_long" ID="tbx_AEmailCliente" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Fax: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_AFaxCliente" runat="server"></asp:TextBox>  
                    </td>   
                </tr>
            </table>  
        </div> 

    <div class="bottom-button3">
                <asp:Button CssClass="add-button" OnClick="btnAdd_InsertClient" ID="add_button" runat="server" Text="Añadir"></asp:Button>
    </div>
</asp:Content>
