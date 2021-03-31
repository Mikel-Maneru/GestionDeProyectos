<%@ Page Title="Modificar Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCliente.aspx.cs" Inherits="GestionDeProyectos.ModificarCliente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form">  
            <table class="auto-style1">  
                <tr class="row-form">  
                    <td>Identificador: </td>  
                    <td>  
                        <asp:TextBox ID="tbx_MIdentificadorCliente" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                <tr class="row-form">  
                    <td>CIF: </td>  
                     <td> <asp:TextBox ID="tbx_MCIFCliente" runat="server"  class="txb"></asp:TextBox></td>  
                </tr>  
                <tr class="row-form">  
                    <td>Nombre: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_MNombreCliente" runat="server"></asp:TextBox>  
                    </td>  
                </tr> 
                <tr class="row-form">  
                    <td>Dirección: </td>  
                    <td>  
                        <textarea  class="txb_long" ID="tbx_MDireccionCliente" runat="server"></textarea>
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Teléfono: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_MTelefonoCliente" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Email: </td>  
                    <td>  
                        <asp:TextBox class="txb_long" ID="tbx_MEmailCliente" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Fax: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_MFaxCliente" runat="server"></asp:TextBox>  
                    </td>   
                </tr>
            </table>  
        </div> 

    <div class="bottom">
        <div class="bottom-footer">
            <br>
            <label class="lbl_find">Buscar Cliente </label>
            <asp:TextBox class="txb" ID="txb_findproyect" runat="server"></asp:TextBox>
            <div class="bottom-button" runat="server" onclick="btnModify_getCliente" style="left:53%;">
                <asp:Button runat="server" CssClass="modify-button" ID="btn_add" OnClick="btnModify_getCliente" style="padding: 1.5rem;" Text="Buscar" />
            </div>
            <div class="bottom-button" runat="server" onclick="btnModify_updateCliente" style="left:69%;">
                <asp:Button runat="server" CssClass="modify-button" ID="btn_modify" OnClick="btnModify_updateCliente" style="padding: 1.5rem;" Text="Modificar" />
            </div>
            <div class="bottom-button" runat="server" onclick="btnModify_deleteCliente" >
                <asp:Button runat="server" CssClass="modify-button-delete" ID="btn_delete" OnClick="btnModify_deleteCliente" Text="Eliminar" OnClientClick="return confirm('Estas seguro de que quieres eliminar este cliente?')" style="padding: 1.5rem;" />
            </div>
        </div>

 

    </div>
</asp:Content>
