<%@ Page Title="Modificar Proyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProyecto.aspx.cs" Inherits="GestionDeProyectos.ModificarProyecto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="div-container-form">
        <table class="auto-style1">
            <tr class="row-form">
                <td>Identificador: </td>
                <td>
                    <asp:TextBox class="txb" ID="tbx_MProyectoIdentificador" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr class="row-form">
                <td>Cliente: </td>
                <td>
                     <asp:DropDownList class="combobox" ID="cbx_MProyectoCliente" runat="server" /></td>
            </tr>
            <tr class="row-form">
                <td>Negocio: </td>
                <td>
                     <asp:DropDownList class="combobox" ID="cbx_MProyectoNegocio" runat="server" />
                </td>
            </tr>
            <tr class="row-form">
                <td>Centro de Coste: </td>
                <td>
                     <asp:DropDownList class="combobox" ID="cbx_MProyectoCC" runat="server" />
                </td>
            </tr>
            <tr class="row-form">
                <td>Nombre: </td>
                <td>
                    <asp:TextBox class="txb_long" ID="tbx_MProyectoNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="row-form">
                <td>Descripción: </td>
                <td>
                    <textarea class="txb_long" id="tbx_MProyectoDescripcion" runat="server"></textarea>
                </td>
            </tr>
            <tr class="row-form">
                <td>Tipo: </td>
                <td>
                     <asp:DropDownList class="combobox" ID="cbx_MProyectoTipo" runat="server" />
                </td>
            </tr>
            <tr class="row-form">
                <td>Plazo: </td>
                <td>
                    <asp:TextBox class="txb" ID="tbx_MProyectoPlazo" runat="server" onFocus="this.type = 'date'"></asp:TextBox>
                </td>
            </tr>
            <tr class="row-form">
                <td>Estado: </td>
                <td>  
                       <asp:DropDownList class="combobox" ID="cbx_MProyectoEstado" runat="server"> 
                           <asp:ListItem Value="-- Estado --" Text="-- Estado --" Selected="True"></asp:ListItem>
                           <asp:ListItem Value="Sin comenzar" Text="Sin comenzar"></asp:ListItem>
                           <asp:ListItem Value="En curso" Text="En proceso"></asp:ListItem>
                           <asp:ListItem Value="Finalizado" Text="Finalizado"></asp:ListItem>
                       </asp:DropDownList>
                    </td>  
            </tr>
            <tr class="row-form">
                <td>Modalidad: </td>
                <td>
                    <asp:TextBox class="txb" ID="tbx_MProyectoModalidad" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="additional-div">
        <a id="empleados" class="additional-button" href="#">Empleados</a>
        <a id="subtarea" class="additional-button" style="float: right" href="#">Subtareas</a>
        <hr />
        <div id="tabla-empleados">
            <h5 style="float: left">ID Empleado</h5>
            <h5 style="float: right">Horas</h5>
            <div class="additional-info">
                <table class="auto-style1">

                    <% foreach (var empleado in pe)
                        { %>
                    <tr>
                        <td><%= empleado.EMPLEADO_ID %></td>
                        <td class="right" style="margin-left:14rem;">
                           <%= empleado.HORAS.ToString() %>
                        </td>
                    </tr>
                    <% } %>
                </table>
            </div>
        </div>

        <div id="tabla-subtareas">
            <h5 style="float: left">ID Subtarea</h5>
            <h5 style="float: right">Descripcion</h5>
            <div class="additional-info">

                <table>

                    <% foreach (var subtarea in st)
                        { %>

                     <tr>
                        <td><%= subtarea.SUBTAREA_ID %> </td>
                        <td><%= subtarea.DESCRIPCION %> </td>
                    </tr>
                    <% } %>
                </table>
            </div>

        </div>
    </div>

    <div class="bottom">
        <div class="bottom-footer">
            <br>
            <label class="lbl_find">Buscar Proyecto </label>
            <asp:TextBox class="txb" ID="txb_findproyect" runat="server"></asp:TextBox>
            <div class="bottom-button" runat="server" onclick="btnModify_getProject" style="left:53%;">
                <asp:Button runat="server" CssClass="modify-button" ID="Button2" OnClick="btnModify_getProject" style="padding: 1.5rem;" Text="Buscar" />
            </div>
            <div class="bottom-button" runat="server" onclick="btnModify_updateProject" style="left:69%;">
                <asp:Button runat="server" CssClass="modify-button" ID="btn_add" OnClick="btnModify_updateProject" style="padding: 1.5rem;" Text="Modificar" />
            </div>
            <div class="bottom-button" runat="server" onclick="btnModify_deleteProject" >
                <asp:Button runat="server" CssClass="modify-button-delete" ID="btn_delete" OnClick="btnModify_deleteProject" Text="Eliminar" OnClientClick="return confirm('Estas seguro de que quieres eliminar este proyecto?')" style="padding: 1.5rem;" />
            </div>
        </div>
    </div>
</asp:Content>
