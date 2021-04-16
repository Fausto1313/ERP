<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="ReporteExcelRisc.aspx.cs" Inherits="IOT_ReporteExcelRisc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">

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
      <a class="navbar-brand" href="#" style="color:azure">Bitácora de Asistencia</a>
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
<a class="alert-link">Catálogo para el control de reportes del personal.</a>
      
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
    <div class="row" >                                
             <asp:Label runat="server"  CssClass="col-md-1 control-label"><b>Empleado</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Empleado" CssClass="form-control" BorderColor=#0c4566  AutoPostBack="True"/>
            </div>    
        <asp:Label runat="server"  CssClass="col-md-1 control-label"><b>Tipo de Historial</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="tipo" CssClass="form-control" BorderColor=#0c4566 AutoPostBack="true" OnSelectedIndexChanged="tipo_SelectedIndexChanged"/>
            </div>
   </div>
    <br /><br />
    <div class="row">
           <asp:Label runat="server" CssClass="col-md-1 control-label" ID="lblFecha1" Visible="false"><b>Fecha 1</b></asp:Label>
           <div class="col-md-3">
           <asp:TextBox runat="server" ID="Fecha1" Visible="false"></asp:TextBox>
           <asp:ImageButton ID="Calendar" runat="server" Height="20px" ImageUrl="~/iconos/Calendario.png"  OnClick="Calendar_Click" Width="20px" Visible="false" />
           <asp:Calendar runat="server" ID="Calendario" Visible="false" OnSelectionChanged="Calendario_SelectionChanged" Height="200px" Width="220px" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399">
               <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
               <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
               <OtherMonthDayStyle ForeColor="#999999" />
               <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
               <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
               <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
               <WeekendDayStyle BackColor="#CCCCFF" />
               </asp:Calendar>
           </div>
            <asp:Label runat="server" CssClass="col-md-1 control-label" ID="lblFecha2" Visible="false"><b>Fecha 2</b></asp:Label>
           <div class="col-md-3">
           <asp:TextBox runat="server" ID="Fecha2" Visible="false"></asp:TextBox>
           <asp:ImageButton ID="Calendar2" runat="server" Height="20px" ImageUrl="~/iconos/Calendario.png" OnClick="Calendar_Click2" Width="20px" Visible="false"/>
           <asp:Calendar runat="server" ID="Calendario2" Visible="false" OnSelectionChanged="Calendario_SelectionChanged2"  Height="200px" Width="220px" AccessKey="2" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399">
               <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
               <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
               <OtherMonthDayStyle ForeColor="#999999" />
               <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
               <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
               <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
               <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
               <WeekendDayStyle BackColor="#CCCCFF" />
               </asp:Calendar>
           </div>
    </div>
    <br /><br /><br />
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID" CssClass="table table-hover table-striped" OnPageIndexChanging="OnPageIndexChanging">
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID Empleado" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField DataField="Apellidos" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellidos" SortExpression="Apellidos" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Fecha" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" HeaderText="Fecha" SortExpression="Fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estatus" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estatus" SortExpression="Estatus" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            </Columns>
    </asp:GridView>
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
    <div>
        <a class="btn btn-danger" href="Bitacoras.aspx" runat="server" role="button">Volver</a>
    </div>

</asp:Content>
