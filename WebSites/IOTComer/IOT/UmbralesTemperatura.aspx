<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="UmbralesTemperatura.aspx.cs" Inherits="IOT_UmbralesTemperatura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">

<br /> 
   <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Umbrales de Temperatura</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li><!--Inicio de ]Modal

            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">
  Cliente Nuevo
</button>
            fin de modal-->
        </li>
        
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group">
         
        </div>
       
      </div>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav> 
     <style>
        .icon-success {
    color:red;
     font-size:20px;
}
   .icon-cambiar {
    color:blue;
     font-size:20px;
}
    </style>
     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">Este catálogo se podrá realizar el alta de algún sensor y configurar el umbral al que llegara para el envio de mensajes vía telegram.
       <p>
          INSTRUCCION: Para mostrar la información en la tabla deberás seleccionar el filtro del Sitio
       </p></a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
   <br />
    <!--validaciones-->
     <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->        
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
        <div class="row">
           <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label">Sitio</asp:Label>
           <div class="col-md-1">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Sitio" AutoPostBack="true" OnSelectedIndexChanged="Sitio_SelectedIndexChanged"/>
        </div>
        </div>
    <br /><br />
     <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
       <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center" DataKeyNames="ID"
                         AutoGenerateColumns="false" AllowPaging="true"
                         CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="ID"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="RISCEI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Dispositivo" SortExpression="RISCEI" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="UmbralMenor" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Umbral menor" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="UmbralMayor" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Umbral mayor" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField> 
             <asp:BoundField DataField="CanalTelegram" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Canal de telegram" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField> 
                    <asp:ButtonField CommandName="actualizar" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-cambiar"></i>' />
          <%--  <asp:buttonField  CommandName="actualizar" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Actualizar" HeaderText="Cambiar Umbral" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
                    <asp:ButtonField CommandName="deleteRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
           <%-- <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
        </Columns>
    </asp:GridView>   
            </ContentTemplate>
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
           <asp:Button ID="btnAdd" runat="server" OnClick="BtnAddClick" ValidationGroup="agregar" Text="Agregar Regla" CssClass="btn btn-success" BorderStyle="Solid" Width="162px"/>

         </div>              
              </ContentTemplate>
          </asp:UpdatePanel>

<br />
<br />
<br />
 
        <a class="btn btn-danger" href="CatalogoTemperatura.aspx" runat="server" role="button" style="position:absolute; left:20px;">Volver</a>
   
    </div>
    <!---->

     <!-- Inicia Modal Para Nuevo Registro-->
           <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel2" style="color:azure">Actualizar Registro Cliente</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table">
                                <tr>
                                <td>Sitio: 
                            <asp:Label ID="sit" runat="server"></asp:Label>
                                    </td>                                 
                                </tr>                             
                                <tr>
                                    <td>RISCEI:
                                    <asp:DropDownList runat="server" ID="dar" BorderColor=#0c4566 />
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>Umbral menor:
                                     <asp:TextBox ID="txtMenor"  placeholder="Umbral menor" runat="server" BorderColor=#0c4566></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Umbral menor es obligatorio" ControlToValidate="txtMenor" ForeColor="Red" ValidationGroup="groupInsert">
                                     </asp:RequiredFieldValidator> 
                                     <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator1" Display="Dynamic" controltovalidate="txtMenor" ValidationExpression="^[0-9.]*$" errormessage="Ingrese solo cantidades"/>                                          
                                    </td>
                                </tr>    
                                <tr>
                                    <td>Umbral mayor:
                                    <asp:TextBox ID="txtMayor"  placeholder="Umbral mayor" runat="server" BorderColor=#0c4566></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo Umbral mayor es obligatorio" ControlToValidate="txtMayor" ForeColor="Red" ValidationGroup="groupInsert">
                                     </asp:RequiredFieldValidator> 
                                     <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtMayor" ValidationExpression="^[0-9.]*$" errormessage="Ingrese solo cantidades"/>                   
                                    </td>
                                </tr> 
                                  <tr>
                                    <td>Canal de telegram:
                                        <asp:DropDownList runat="server" ID="canalTelegram" BorderColor=#0c4566 />
                                    </td>
                                </tr>   
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResultt" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="Button1" runat="server" ValidationGroup="Agregar" OnClick="BtnSave_ClickS" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-outline-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
    <!---->
    <!-- Edit Modal Starts here -->
    <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
           <div class="modal-content">
             <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
               <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                       <div class="modal-body">
                         <table class="table">
                                  <div class="form-group">
                                  <label for="input" class="col-md-3 control-label">ID:</label>
                                  <asp:label ID="lblID"  runat="server"></asp:label>                                
                                  </div> 
                                  <div class="form-group">
                                  <label for="input" class="col-md-3 control-label">RISCEI:</label>
                                  <asp:label ID="lblRiscei"  runat="server"></asp:label>                                
                                  </div> 
                                  <div class="form-group">
                                  <label for="input" class="col-md-3 control-label">Descripcion:</label>
                                  <asp:label ID="lblDesc"  runat="server"></asp:label>                                
                                  </div>   
                          <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Umbral menor:</label>
                          <asp:TextBox ID="txtMenor1" placeholder="Umbral menor" runat="server" BorderColor=#0c4566></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo umbral menor es obligatorio" ControlToValidate="txtMenor1" ForeColor="Red" ValidationGroup="Actualizar">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator4" Display="Dynamic" controltovalidate="txtMenor1" ValidationExpression="^[0-9.]*$" errormessage="Ingrese solo numeros" ValidationGroup="Actualizar"/>
                          </div>

                           <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Umbral mayor</label>
                          <asp:TextBox ID="txtMayor1" placeholder="Umbral mayor" runat="server" BorderColor=#0c4566></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo umbral menor es obligatorio" ControlToValidate="txtMayor1" ForeColor="Red" ValidationGroup="Actualizar">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator5" Display="Dynamic" controltovalidate="txtMayor1" ValidationExpression="^[0-9.]*$" errormessage="Ingrese solo numeros" ValidationGroup="Actualizar"/>
                          </div>
                             
                           <div class="form-group">
                          <label for="input" class="col-md-3 control-label">Canal Telegram</label>
                                <asp:DropDownList runat="server" ID="canalTelegram1" BorderColor=#0c4566/>
                          </div>
                       </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnUPD" runat="server" OnClick="BtnUpdate" ValidationGroup="Actualizar" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="btnUPD" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
     <!----->

    <!-- MODAL DE ELIMINAR -->
    <div id="eliminaModal" class="modal fade"  tabindex="-1"  aria-labelledby="eliminaModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                    <h3 id="eliminaModalLabel" style="color:azure">Eliminar Registro</h3>
                </div>
                <asp:UpdatePanel ID="DELETE" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            Desea Eliminar este registro?
                            <asp:HiddenField ID="hfID" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="BtnDelete" runat="server"  ValidationGroup="Eliminar" Text="Confirmar" CssClass="btn btn-danger" OnClick="BtnDelete_Click"  />
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cancel</button>
                        </div>
                       
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>

    <!-- FIN MODAL ELIMINAR -->

















</asp:Content>