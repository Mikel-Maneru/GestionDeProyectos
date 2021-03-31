<%@ Page Title="Añadir Centro de Coste" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AñadirCentroCoste.aspx.cs" Inherits="GestionDeProyectos.AñadirCentroCoste" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form2">  
            <table class="auto-style2">  
                <tr class="row-form-line" >  
                    <td>ID Centro de Coste: </td>  
                    <td>  
                        <asp:TextBox ID="tbx_ABuscarCC" runat="server"></asp:TextBox>  
                    </td>  
               </tr>  
                <tr class="row-form">  
                    <td>Descripción: </td>  
                     <td> <textarea ID="txb_ADescripcionCC" runat="server" class="txb_long"></textarea></td>  
                </tr>  
            </table>  
        </div> 
    <div class="bottom-button3">
                <asp:Button OnClick="btnAdd_InsertCC"  CssClass="add-button" runat="server" Text="Añadir"></asp:Button>
    </div>
</asp:Content>
