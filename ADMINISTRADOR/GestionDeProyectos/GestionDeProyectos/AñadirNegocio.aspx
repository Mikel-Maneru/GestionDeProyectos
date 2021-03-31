<%@ Page Title="Añadir Negocio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AñadirNegocio.aspx.cs" Inherits="GestionDeProyectos.AñadirNegocio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form2">  
            <table class="auto-style2">  
                <tr class="row-form-line" >  
                    <td>ID Negocio: </td>  
                    <td>  
                        <asp:TextBox ID="tbx_BuscarNegocio" runat="server"></asp:TextBox>  
                    </td>  
               </tr>  
                <tr class="row-form">  
                    <td>Descripción: </td>  
                     <td> <textarea ID="txb_DescripcionNegocio" runat="server" class="txb_long"></textarea></td>  
                </tr>  
            </table>  
        </div> 
    <div class="bottom-button3">
                <asp:Button CssClass="add-button" OnClick="btnAdd_InsertNegocio" runat="server" Text="Añadir"></asp:Button>
    </div>
</asp:Content>
