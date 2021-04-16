<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/IOT/SiteLog.master" CodeFile="MisDispositivos.aspx.cs" Inherits="IOT_MisDispositivos" %>

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
      <a class="navbar-brand" href="#" style="color:azure">Mis dispositivos</a>
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
    <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este cátalogo se podrá consultar la información de los dispositivos agregados en el catálogo DARS a tráves del combo de sitios.</a>
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
<br />
    <div class="row">
        <div class ="col-md-6">
            <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" OnSelectedIndexChanged="Sitio_SelectedIndexChanged" AutoPostBack="true" />
        </div>
    </div>
  <style>
        .icon-success {
    color:blue;
     font-size:20px;
}
 
    </style>
   
   <br />
    <!--validaciones-->
   <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center" ><!--div Margen-->
          
      <asp:UpdatePanel ID="upCrudGrid" runat="server" CssClass="body" >
          <ContentTemplate>

                 <%-- Busqueda:&nbsp;<asp:TextBox ID="txtSearch" runat="server" OnTextChanged="Search" AutoPostBack="true"></asp:TextBox>
              <br>
     --%>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true" 
                        DataKeyNames="RISCEI" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="PageIndexChanging"  >
        <Columns>
            <asp:BoundField DataField="RISCEI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="RISCEI" SortExpression="RISCEI" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Modelo" SortExpression="Modelo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                      <asp:ButtonField CommandName="updRecord" HeaderText="Actualizar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-pencil icon-success"></i>' />
            <%--<asp:buttonField  CommandName="updRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" Text="Actualizar" HeaderText="Actualizar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField> --%>
        </Columns>
    </asp:GridView>
     
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
       <div>
            <a class="btn btn-danger" href="CatalogoComandos.aspx" runat="server" role="button">Volver</a>
            </div>
    </div>

     <!-- Edit Modal Starts here -->
            <div id="updModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h3 id="updModalLabel" style="color:azure">Actualizar Registro</h3>
                </div>
                <asp:UpdatePanel ID="upUpd" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <table class="table">
                                <tr>
                                    <td>RISCEI : 
                            <asp:Label ID="txtRISCEI" runat="server" BorderColor=#0c4566></asp:Label>
                                    </td>
                                  
                                </tr>
                              
                                <tr>
                                    <td>Descripcion:
                            <asp:TextBox ID="txtDescripcion" runat="server" BorderColor=#0c4566></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationExpression="string" ErrorMessage="El campo descripción es obligatorio" ControlToValidate="txtDescripcion" ForeColor="Red" >
                                           </asp:RequiredFieldValidator>    
                                           <asp:RegularExpressionValidator runat="server" id="RegularExpressionValidator2" Display="Dynamic" controltovalidate="txtDescripcion" ValidationExpression="^[a-zA-Z0-9 -_]*$" errormessage="Ingrese solo letras y numeros!" />
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                            
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="btnSave" runat="server" OnClick="BtnSave_Click" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
    <!-- Edit Modal Ends here -->
</asp:Content>

