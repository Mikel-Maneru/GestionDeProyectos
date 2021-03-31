<%@ Page Title="Modificar Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarEmpleado.aspx.cs" Inherits="GestionDeProyectos.ModificarEmpleado" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form">  
            <table class="auto-style1">  
                <tr class="row-form">  
                    <td>Identificador: </td>  
                    <td>  
                        <asp:TextBox ID="txb_MIdentificadorEmpleado" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                <tr class="row-form">  
                    <td>Nombre: </td>  
                     <td> <asp:TextBox ID="txb_MNombreEmpleado" runat="server"></asp:TextBox></td>  
                </tr>  
                <tr class="row-form">  
                    <td>Apellidos: </td>  
                    <td>  
                        <asp:TextBox class="txb_long" ID="txb_MApellidosEmpleado" runat="server"></asp:TextBox>  
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
                        <asp:TextBox class="txb_long" ID="txb_MEmailEmpleado" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Mano de Obra: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="txb_MManoObraEmpleado" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Rol: </td>  
                    <td>  
                        <asp:DropDownList class="combobox" ID="cxb_MRolEmpleado" runat="server" />
                    </td>  
                </tr>
            </table>  
        </div> 

    <div class="bottom">
        <div class="bottom-footer">
            <br>
            <label class="lbl_find">Buscar Empleado </label>
            <asp:TextBox class="txb" ID="txb_findproyect" runat="server"></asp:TextBox>
            <div class="bottom-button" runat="server" onclick="btnModify_getUser" style="left:53%;">
                <asp:Button runat="server" CssClass="modify-button" ID="btn_add" OnClick="btnModify_getUser" style="padding: 1.5rem;" Text="Buscar" />
            </div>
            <div class="bottom-button" runat="server" onclick="btnModify_updateUser" style="left:69%;">
                <asp:Button runat="server" CssClass="modify-button" ID="btn_modify" OnClick="btnModify_updateUser" style="padding: 1.5rem;" Text="Modificar" />
            </div>
            <div class="bottom-button" runat="server" onclick="btnModify_deleteUser" >
                <asp:Button runat="server" CssClass="modify-button-delete" ID="btn_delete" OnClick="btnModify_deleteUser" Text="Eliminar" OnClientClick="return confirm('Estas seguro de que quieres eliminar este empleado?')" style="padding: 1.5rem;" />
            </div>
        </div>

 

    </div>
</asp:Content>
