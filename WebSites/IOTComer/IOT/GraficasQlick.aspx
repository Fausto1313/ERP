<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GraficasQlick.aspx.cs" MasterPageFile="~/IOT/SiteLog.master" Inherits="IOT_GraficasQlick" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Graficas de dispositivos</a>
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
   <br />

    <!--validaciones-->
     <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server">
          <ContentTemplate>
        <div class="row">
           <asp:Label runat="server" AssociatedControlID="Clientes" CssClass="col-md-1 control-label">Cliente</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Clientes" OnSelectedIndexChanged="CargaSitio" AutoPostBack="true"/>
        </div>
         <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label">Sitio</asp:Label>
           <div class="col-md-3">
           <asp:DropDownList runat="server" BorderColor=#0c4566  ID="Sitio"  AutoPostBack="true"/>
        </div>
        </div>
    <br /><br />
 <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
         AutoGenerateColumns="false" AllowPaging="true"
         DataKeyNames="ID" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand">
        <Columns>
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nivel 1" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>

            <asp:BoundField DataField="Link" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Url" SortExpression="Url" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            
            <asp:buttonField  CommandName="btnAgregar" ButtonType="Button"  ControlStyle-CssClass="btn btn-info" Text="Agregar" HeaderText="Agregar URL" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
              </asp:buttonField>

            <asp:buttonField  CommandName="btnActualizar" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Actualizar" HeaderText="Actualizar URL" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>

                 </Columns>
    </asp:GridView>
</ContentTemplate>
          </asp:UpdatePanel>
          </div>

    <!-- INICIA MODAL PARA AGREGAR URL -->
    <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="addModalLabel" style="color:azure">URL</h3>
                </div>               
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">              
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">                               
                                <tr>
                                <label for="inputURL" class="col-md-3 control-label">ID</label>
                                <asp:Label ID="lblID"  runat="server"></asp:Label>
                                <td>URL: 
                                <asp:TextBox ID="txtURL" placeholder="URL" runat="server" BorderColor=#0c4566></asp:TextBox>                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="La URL es obligatoria" ControlToValidate="txtURL" ForeColor="Red" ValidationGroup="groupInsert" >
                                </asp:RequiredFieldValidator>                                     
                                </td>
                                </tr>                                                                
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" OnClick="AgregarURL" Text="Confirmar " CssClass="btn btn-success"  ValidationGroup="groupInsert"/>
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnAddRecord" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
    <!-- TERMINA MODAL PARA AGREGAR URL -->



    <!-- INICIA MODAL PARA EDITAR URL -->
        <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar URL</h3>
                </div>               
                    <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel1" class="form-group"  runat="server">              
                    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table table-bordered table-hover">                               
                                <tr>
                                <td>
                                <label for="ID" class="col-md-3 control-label">ID</label>
                                <asp:Label ID="lblID1"  runat="server"></asp:Label>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <label for="inputURL" class="col-md-3 control-label">URL</label>
                                <asp:Label ID="lblURL"  runat="server"></asp:Label>
                                </td>
                                </tr>
                                <tr>
                                <td>URL: 
                                <asp:TextBox ID="txtURL1" placeholder="URL NUEVA" runat="server" BorderColor=#0c4566></asp:TextBox>                                        
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="La URL es obligatoria" ControlToValidate="txtURL1" ForeColor="Red"  >
                                </asp:RequiredFieldValidator>                                     
                                </td>
                                </tr>                                                                
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="btnUpdRecord" runat="server" OnClick="ActualizarURL" Text="Confirmar" CssClass="btn btn-success"  />
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnUpdRecord" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>
    <!-- TERMINA MODAL PARA EDITAR URL -->

     
</asp:Content>