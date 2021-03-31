<%@ Page Title="Modificar Centro de Coste" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCentroCoste.aspx.cs" Inherits="GestionDeProyectos.ModificarCentroCoste" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form2">  
            <table class="auto-style2">  
                <tr class="row-form-line" >  
                    <td>Buscar Centro de Coste: </td>  
                    <td>  
                        <asp:TextBox ID="tbx_MBuscarCC" runat="server"></asp:TextBox>  
                    </td>  
               </tr>  
                <tr class="row-form">  
                    <td>Descripción: </td>  
                     <td> <textarea ID="txb_MDescripcionCC" runat="server" class="txb_long"></textarea></td>  
                </tr>  
            </table>  
        </div> 
    <div class="bottom-button2 from-center" style="left:52%">
        <asp:Button runat="server"  style="margin-right:10rem; padding:1.5rem;" CssClass="modify-button" ID="btn_add" OnClick="btnModify_getCC" Text="Buscar" />
        
    </div>
    <div class="bottom-button2 from-center" style="left:72%">
        <asp:Button runat="server"  style="margin-right:10rem; padding:1.5rem;" CssClass="modify-button" ID="btn_modify" OnClick="btnModify_updateCC" Text="Modificar" />
    </div>
    <div class="bottom-button2 from-center" >
        <asp:Button runat="server"  style="margin-right:10rem; padding:1.5rem;" CssClass="modify-button-delete" ID="btn_delete" OnClick="btnModify_deleteCC" OnClientClick="return confirm('Estas seguro de que quieres eliminar este Centro de Coste?')" Text="Eliminar" />     
    </div>
</asp:Content>
