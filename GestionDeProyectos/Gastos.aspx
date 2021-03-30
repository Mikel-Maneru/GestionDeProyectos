<%@ Page Title="Gastos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gastos.aspx.cs" Inherits="GestionDeProyectos.Gastos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
       <div id="gridtableG" runat="server" class="gridtable">
            <asp:GridView ID="GridViewG" runat="server"
             AutoGenerateColumns="false"
             GridLines="None"
             AllowPaging="True"
                CssClass="table"
                 onrowdeleting="gridGastos_RowDeleting"
                >
                   <Columns>
                     <asp:TemplateField>
                       <ItemTemplate>
                           <asp:ImageButton ID="btnUpdate" runat="server" Text="Delete" CommandName="Delete"  OnClientClick="return confirm('Estas seguro de que quieres eliminar este Gasto?')" ImageUrl="~/Imagenes/x.png" CssClass="imgDelete" ToolTip="Delete" AutoPostBack="true" />
                       </ItemTemplate>
                  </asp:TemplateField>
                         <asp:TemplateField HeaderText="Tarea_ID" Visible="false">
                       <ItemTemplate>
                            <asp:Label runat="server" ID="lblgastos_id" Text='<%# Eval("GASTOS_ID") %>' />
                       </ItemTemplate>
                  </asp:TemplateField>
                       
                  <asp:TemplateField HeaderText="PROYECTO_ID" >
                       <ItemTemplate>
                            <asp:Label ID="lblproyecto_id" runat="server" Text='<%# Eval("PROYECTO_ID") %>' />
                       </ItemTemplate>
           
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="COSTE">
                       <ItemTemplate>
                            <asp:Label runat="server" ID="lblcoste" Text='<%# Eval("COSTE") %>' />
                       </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="OBSERVACION" >
                       <ItemTemplate>
                            <asp:Label ID="lblobser" runat="server" Text='<%# Eval("OBSERVACION") %>' />
                       </ItemTemplate>
           
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="KM" >
                       <ItemTemplate>
                            <asp:Label ID="lblkm" runat="server" Text='<%# Eval("KM") %>' />
                       </ItemTemplate>
           
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="CONCEPTO" >
                       <ItemTemplate>
                            <asp:Label ID="lblconcepto" runat="server" Text='<%# Eval("CONCEPTO") %>' />
                       </ItemTemplate>          
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="DIETA" >
                       <ItemTemplate>
                            <asp:Label ID="lbldieta" runat="server" Text='<%# Eval("DIETA") %>' />
                       </ItemTemplate>          
                  </asp:TemplateField>
                         <asp:TemplateField HeaderText="DIA" >
                       <ItemTemplate>
                            <asp:Label ID="lbldia" runat="server" Text='<%# Eval("DIA") %>' />
                       </ItemTemplate>          
                  </asp:TemplateField>
             </Columns>
        </asp:GridView>
          
       </div>
    
       <div class="formularioG">
         
            <div class="parentG">
                <div class="div1G"><h4>Proyectos</h4></div>
                <div class="div2G"><asp:DropDownList  ID="DropDownList_proyetos_gastos" runat="server" CssClass="dropdownlist" AutoPostBack="true"   ></asp:DropDownList></div>
                <div class="div3G"><h4>Coste</h4></div>
                <div class="div4G"><asp:TextBox ID="txt_coste" runat="server" TextMode="Number"></asp:TextBox><%-- <asp:RegularExpressionValidator runat="server" ErrorMessage="Mete un numero decimal" ID="txtregpre" ValidationGroup="Insert"
                       ControlToValidate="txt_coste"              
ValidationExpression="^\d+\.\d{0,2}$"></asp:RegularExpressionValidator>--%> </div>
                <div class="div5G"><h4>Observacion</h4> </div>
                <div class="div6G"><textarea ID="txt_observacion" runat="server"  ></textarea> </div>
                <div class="div7G"><h4>Km</h4></div>
                <div class="div8G"><asp:TextBox ID="txt_km" runat="server" TextMode="Number"  ></asp:TextBox></div>
                <div class="div9G"><h4>Concepto</h4></div>
                <div class="div10G"><asp:TextBox ID="txt_concepto" runat="server"></asp:TextBox></div>               
                <div class="div11G"><h4>Dieta</h4></div>
                <div class="div12G"><asp:CheckBox ID="chb_dieta" CssClass="checkbox" runat="server" /></div>
            </div>
          
         </div>

    <div class="bottom">
        <div class="bottom-button-partes ">
             <asp:Button id="btn_insertG" Text="Insertar" runat="server" CssClass="button-insert" OnClick="btn_insertar_gastos"/>
        </div>
        
        <div class="fechas">
             <asp:Button id="btn_sumG" Text="+1" runat="server" CssClass="buttonsum" OnClick="btn_sum_Click_gastos"/><span>Fecha:</span><br>&ensp;&ensp;&ensp;&ensp;&ensp;<asp:TextBox ID="mydateG" runat="server"></asp:TextBox><br>
             <asp:Button id="btn_minusG" Text="-1" runat="server" CssClass="buttonsum" OnClick="btn_rest_Click_gastos"/>
        </div>
</div>
</asp:Content>
