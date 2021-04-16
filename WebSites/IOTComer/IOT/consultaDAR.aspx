<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="consultaDAR.aspx.cs" Inherits="IOT_consultaDAR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    
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
      <a class="navbar-brand" href="#" style="color:azure">Eventos del dispositivo</a>
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
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center" ><!--div Margen-->
     <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false"
                        DataKeyNames="ID" CssClass="table table-hover table-striped">
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="RISCEI" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="RISCEI" SortExpression="RISCEI" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Descripcion" SortExpression="Descripcion" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="evento" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Evento" SortExpression="evento" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" SortExpression="estado" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="fecha" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"  ItemStyle-HorizontalAlign="Center" HeaderText="Fecha" SortExpression="fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
        </Columns>
    </asp:GridView>
          </div>
    <br /><br />
    <div class="row">
    <div class="col-md-3" style="left:300px">
    <asp:LinkButton ID="generaPDF" runat="server" OnClick="generaPDF_Click" CssClass="btn btn-warning" BorderStyle="Solid" Width="100px" Height="40px" AccessKey="p">
    <span aria-hidden="true" class="fas fa-file-pdf" style="font-size:2em"></span> PDF
    </asp:LinkButton>
    </div>
    <div class="col-md-3" style="left:200px">
    <asp:LinkButton runat="server" ID="generaExcel" OnClick="generaExcel_Click" CssClass="btn btn-success" BorderStyle="Solid" Width="100px" Height="40px" AccessKey="e">
    <span aria-hidden="true" class="fas fa-file-excel" style="font-size:2em"></span> Excel
    </asp:LinkButton>
    </div>
    </div>
</asp:Content>

