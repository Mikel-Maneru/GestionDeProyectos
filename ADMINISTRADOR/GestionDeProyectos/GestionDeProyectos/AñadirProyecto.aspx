<%@ Page Title="Añadir Proyecto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AñadirProyecto.aspx.cs" Inherits="GestionDeProyectos.AñadirProyecto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server"> 
        <div class="div-container-form">  
            <table class="auto-style1">  
                <tr class="row-form">  
                    <td>Identificador: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_AProyectoIdentificador" runat="server"></asp:TextBox>  
                    </td>  
  
               </tr>  
                <tr class="row-form">  
                    <td>Cliente: </td>  
                     <td>
                         <asp:DropDownList class="combobox" ID="cbx_AProyectoCliente" runat="server" />
                     </td>  
                </tr>  
                <tr class="row-form">  
                    <td>Negocio: </td>  
                    <td>  
                        <asp:DropDownList class="combobox" ID="cbx_AProyectoNegocio" runat="server" />
                    </td>  
                </tr> 
                <tr class="row-form">  
                    <td>Centro de Coste: </td>  
                    <td>  
                        <asp:DropDownList class="combobox" ID="cbx_AProyectoCC" runat="server" />
                    </td>   
                </tr>
                <tr class="row-form">  
                    <td>Nombre: </td>  
                    <td>  
                        <asp:TextBox class="txb_long" ID="tbx_AProyectoNombre" runat="server"></asp:TextBox>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Descripción: </td>  
                    <td>  
                        <textarea class="txb_long" ID="tbx_AProyectoDescripcion" runat="server"></textarea>  
                    </td>  
                </tr>
                <tr class="row-form">  
                    <td>Tipo: </td>  
                    <td>  
                        <asp:DropDownList class="combobox" ID="cbx_AProyectoTipo" runat="server"/>  
                    </td>    
                </tr> 
                <tr class="row-form">  
                    <td>Plazo: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_AProyectoPlazo" runat="server" onFocus="this.type = 'date'"></asp:TextBox>  
                    </td>   
                </tr>    
                <tr class="row-form">  
                    <td>Estado: </td>  
                    <td>  
                       <asp:DropDownList class="combobox" ID="cbx_AProyectoEstado" runat="server"> 
                           <asp:ListItem Value="null" Text="-- Seleccione el Estado --" Selected="True"></asp:ListItem>
                           <asp:ListItem Value="Sin comenzar" Text="Sin comenzar"></asp:ListItem>
                           <asp:ListItem Value="En curso" Text="En proceso"></asp:ListItem>
                           <asp:ListItem Value="Finalizado" Text="Finalizado"></asp:ListItem>
                       </asp:DropDownList>
                    </td>   
                </tr>       
                <tr class="row-form">  
                    <td>Modalidad: </td>  
                    <td>  
                        <asp:TextBox class="txb" ID="tbx_AProyectoModalidad" runat="server"></asp:TextBox>  
                    </td>   
                </tr>
            </table> 
        </div> 
    <div class="additional-div">
        <a id="empleados" class="additional-button" href="#">Empleados</a>
        <a id="subtarea" class="additional-button" style="float:right" href="#">Subtareas</a>
        <hr />
        <div id="tabla-empleados" >
            <h5 style="float:left">ID Empleado</h5>
            <div class="additional-info" style ="margin-bottom:10px;">
                <asp:GridView ID="gridViewUsers" runat="server"
                     AutoGenerateColumns="false"
                     GridLines="None"
                     AllowPaging="True"
                     CssClass="table"
                     ShowHeader="False"
                     onrowdeleting="gridViewUsers_RowDeleting">
                     <Columns>
                          <asp:TemplateField>
                               <ItemTemplate>
                                    <asp:Label ID="lbl_AProyectoEmpleados" runat="server"  Text='<%# Eval("EMPLEADO_ID") + " - " + Eval("NOMBRE") + " " + Eval("APELLIDOS")%>' />
                               </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                               <ItemTemplate>
                                    <asp:ImageButton ID="btnUpdate" runat="server" Text="Delete" CommandName="Delete" ImageUrl="~/Imagenes/x.png" CssClass="imgDelete" ToolTip="Delete" AutoPostBack="true" />
                               </ItemTemplate>
                          </asp:TemplateField>
                     </Columns>
                </asp:GridView>
            </div>
            <asp:DropDownList style=" width:18em;" class="combobox" ID="cbx_AProyectoEmpleados" runat="server"/>
            <asp:Button ID="btn_addEmpleado" style=" width:5em; float:right;" runat="server" text="Añadir" OnClick="btnAdd_InsertEmpleado"/>
         </div>

        <div id="tabla-subtareas">
            <h5 style="float:left">ID Subtarea</h5>
            <h5 style="float:right">Descripcion</h5>

            <div class="additional-info" style ="margin-bottom:10px;">
                <asp:GridView ID="gridViewSubtarea" runat="server"
                     AutoGenerateColumns="false"
                     GridLines="None"
                     AllowPaging="True"
                     CssClass="table"
                     ShowHeader="False"
                     onrowdeleting="gridViewSubtarea_RowDeleting">
                     <Columns>
                          <asp:TemplateField>
                               <ItemTemplate>
                                    <asp:Label ID="lbl_AProyectoSubtarea" runat="server"  Text='<%# Eval("SUBTAREA_ID") %>' />
                               </ItemTemplate>
                          </asp:TemplateField>
                         <asp:TemplateField>
                               <ItemTemplate>
                                    <asp:Label ID="lbl_AProyectoSubtareaDescripcion" runat="server"  Text='<%# Eval("DESCRIPCION") %>' />
                               </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                               <ItemTemplate>
                                    <asp:ImageButton ID="btnUpdate" runat="server" Text="Delete" CommandName="Delete" ImageUrl="~/Imagenes/x.png" CssClass="imgDelete" ToolTip="Delete" AutoPostBack="true" />
                               </ItemTemplate>
                          </asp:TemplateField>
                     </Columns>
                </asp:GridView>
            </div>
            <asp:TextBox style=" width:5em; float:left; margin-right: 1em;" class="combobox" ID="txb_subtareaID" runat="server" />
            <textarea style=" width:12em; max-height:4em;" class="combobox" ID="txb_subtareaDesc" runat="server"/>
            <asp:Button ID="Button1" style=" width:5em; float:right;" runat="server" text="Añadir" OnClick="btnAdd_InsertSubtarea"/>
           <%-- <div class="additional-info">
                 <table>
                <tr class="row-form">  
                    <td><asp:TextBox class="txb_s" ID="TextBox20" runat="server"></asp:TextBox> </td>  
                    <td>  
                        <textarea class="txb" ID="TextBox10" runat="server"></textarea>
                    </td>  
               </tr>
            </table>
            </div>--%>
            
        </div>
    </div>

    <div class="bottom-button3">
                <asp:Button CssClass="add-button" OnClick="btnAdd_InsertProyecto" runat="server" Text="Añadir"></asp:Button>
    </div>

</asp:Content>
