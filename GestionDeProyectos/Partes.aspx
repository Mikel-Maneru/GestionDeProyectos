<%@ Page Title="Partes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Partes.aspx.cs" Inherits="GestionDeProyectos.Partes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <div id="gridtable" runat="server" class="gridtable">
            <asp:GridView ID="GridViewPET" runat="server"
             AutoGenerateColumns="false"
             GridLines="None"
             AllowPaging="True"
                CssClass="table"
                onrowdeleting="gridViewUsers_RowDeleting">
                   <Columns>
                     <asp:TemplateField>
                       <ItemTemplate>
                           <asp:ImageButton ID="btnUpdate" runat="server" Text="Delete"  OnClientClick="return confirm('Estas seguro de que quieres eliminar este Parte?')" CommandName="Delete" ImageUrl="~/Imagenes/x.png" CssClass="imgDelete" ToolTip="Delete" AutoPostBack="true" />
                       </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tarea_ID" Visible="false">
                       <ItemTemplate>
                            <asp:Label runat="server" ID="lbltarea" Text='<%# Eval("TAREA_ID") %>' />
                       </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="PROYECTO_ID">
                       <ItemTemplate>
                            <asp:Label runat="server" ID="lblproyecto" Text='<%# Eval("PROYECTO_ID") %>' />
                       </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="SUBTAREA_ID" >
                       <ItemTemplate>
                            <asp:Label ID="lblsubtarea" runat="server" Text='<%# Eval("SUBTAREA_ID") %>' />
                       </ItemTemplate>
           
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="OBSERVACIONES" >
                       <ItemTemplate>
                            <asp:Label ID="lblobservacion" runat="server" Text='<%# Eval("OBSERVACION") %>' />
                       </ItemTemplate>
           
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="FECHA" >
                       <ItemTemplate>
                            <asp:Label ID="lblfecha" runat="server" Text='<%# Eval("DIA") %>' />
                       </ItemTemplate>          
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="TIEMPO" >
                       <ItemTemplate>
                            <asp:Label ID="lbltiempo" runat="server" Text='<%# Eval("TIEMPO") %>' />
                       </ItemTemplate>          
                  </asp:TemplateField>
             </Columns>
        </asp:GridView>
          
       </div>
     <asp:Label ID="Label1" runat="server" Text="Horas Totales : " CssClass="totalhours"></asp:Label>
       <div class="formulario">
          <div class="parent" id="parent" runat="server">
              <div class="div1"><h4>Proyectos</h4></div>
                <div class="div2"> <asp:DropDownList  ID="DropDownList_proyetos" runat="server" CssClass="dropdownlist" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_proyetos_SelectedIndexChanged"></asp:DropDownList>
                
                </div>
                <div class="div3"><h4>Tareas</h4></div>
                <div class="div4"><asp:DropDownList ID="DropDownList_tareas" runat="server" CssClass="dropdownlist" AutoPostBack="true" ></asp:DropDownList> 
                 
                </div>
                <div class="div5"><h4>Observaciones</h4></div>
                <div class="div6"><h4>Tiempo</h4></div>
                <div class="div7"><textarea ID="TextBox2" runat="server" ></textarea>
                
                </div>
                <div class="div8"><asp:TextBox ID="txt_tiempo" runat="server" CssClass="textarea" TextMode="Number" > </asp:TextBox> 
                    <%--    <asp:RegularExpressionValidator runat="server" ErrorMessage="Mete un numero DECIMAL" ID="txtregpre" ValidationGroup="Insert"
                       ControlToValidate="txt_tiempo"              
ValidationExpression="^\d+\.\d{0,2}$"></asp:RegularExpressionValidator>--%>
                </div>
            </div>
         </div>

    <div class="bottom">
        <div class="bottom-button-partes ">
             <asp:Button id="btn_insert" Text="Insertar" runat="server" OnClick="btn_insertar" CssClass="button-insert" />
        </div>
        
        <div class="fechas">
             <asp:Button id="btn_sum" Text="+1" runat="server" CssClass="buttonsum" OnClick="btn_sum_Click"/><span>Fecha:</span><br>&ensp;&ensp;&ensp;&ensp;&ensp;<asp:TextBox ID="mydate" runat="server"></asp:TextBox><br>
             <asp:Button id="btn_minus" Text="-1" runat="server" CssClass="buttonsum"  OnClick="btn_rest_Click"/>
        </div>
</div>
</asp:Content>
