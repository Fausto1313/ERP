<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="Instalados.aspx.cs" Inherits="IOT_Instalados" %>
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
      <a class="navbar-brand" href="#" style="color:azure">Catalogo DAR</a>
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
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="RISCEI" CssClass="table table-hover table-striped" >
        <Columns>
            <asp:BoundField DataField="RISCEI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="RISCEI" SortExpression="RISCEI">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="RazonSocial" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Cliente" SortExpression="ID_Cliente">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Modelo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Modelo" SortExpression="Modelo">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
              
        </Columns>
  
    </asp:GridView>
      
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
    </div>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
                <div class="row">
                  <asp:Label runat="server" AssociatedControlID="Nivel1" CssClass="col-md-2 control-label">Niveles</asp:Label>
                  <div class="col-md-3">
                      <asp:DropDownList runat="server" ID="Sitio" AutoPostBack="true" OnSelectedIndexChanged="Sitio_SelectedIndexChanged"/>
                     <asp:DropDownList runat="server" ID="Nivel1" AutoPostBack="true" OnSelectedIndexChanged="Nivel1_SelectedIndexChanged"/>
                      <asp:DropDownList runat="server" ID="Nivel2" AutoPostBack="true" OnSelectedIndexChanged="Nivel2_SelectedIndexChanged"/>
                      <asp:DropDownList runat="server" ID="Nivel3" AutoPostBack="true" OnSelectedIndexChanged="Nivel3_SelectedIndexChanged"/>
                      <asp:DropDownList runat="server" ID="Nivel4" AutoPostBack="true" OnSelectedIndexChanged="Nivel4_SelectedIndexChanged"/>
                      <asp:DropDownList runat="server" ID="Nivel5" AutoPostBack="true" />
                </div>
              </div>
              <br/>
        <div class="row">
            <div class="col-md-offset-3 col-md-10">
                <asp:Button runat="server"  Text="Consultar" OnClick="Consulta" CssClass="btn btn-default" />
            </div>
               </div>
        </div>
    </div>
            </div>
                   </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>
          
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
          <ContentTemplate>
    <asp:GridView ID="GridView2" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                         CssClass="table table-hover table-striped" >
        <Columns>
        
             <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            
      
              
        </Columns>
  
    </asp:GridView>
      
            </ContentTemplate>
          <Triggers>

        </Triggers>
      </asp:UpdatePanel>

    </asp:Content>