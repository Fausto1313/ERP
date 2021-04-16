<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FORMULARIO.aspx.cs" Inherits="FORMULARIO" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
      <a class="navbar-brand" href="#" style="color:azure">Activador</a>
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
    <!---formulario--->
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <!---script--->
    <script>
  $( function() {
    $( "#datepicker" ).datepicker();
  }

  );
  </script>
      <script>
          $(function () {
              $("#date").datepicker();
          });
  </script>
    <asp:UpdatePanel ID="upUpd" runat="server" >
    <ContentTemplate>
                        <div class="modal-body">
                            <table class="table">
                                <tr>
                                    <td>ID : 
                                <asp:TextBox ID="txtActivador" placeholder="ID" runat="server"></asp:TextBox>
                                        <asp:Label runat="server" />
                                    </td>
                                </tr>

                             <tr>
                                 <td>Nombre:

                                <asp:TextBox ID="txtNombre"  placeholder="Agrege el Nombre" runat="server"></asp:TextBox>
                                     </td>         
                               </tr>
                                 <tr>
                                    <td>Fecha de Inicio: 
                              <asp:Calendar ID="inicio" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#808080" />
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <WeekendDayStyle BackColor="#FFFFCC" />
                                </asp:Calendar>
                                    </td>
                                  
                                </tr>
                                 <tr>
                                    <td>Fecha de Fin : 
                                 <asp:Calendar ID="fin" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                        <NextPrevStyle VerticalAlign="Bottom" />
                                        <OtherMonthDayStyle ForeColor="#808080" />
                                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                        <SelectorStyle BackColor="#CCCCCC" />
                                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <WeekendDayStyle BackColor="#FFFFCC" />
                                    </asp:Calendar>     
                                    </td>
                                  
                                </tr>
                               <tr>
                                    <td>Habilitar:
                         <asp:DropDownList ID="Habilitar" ViewStateMode="Disabled" DataTextField="Estatus" runat="server" >
                             <asp:ListItem>Selecciona:</asp:ListItem>   
                               <asp:ListItem>Inactivo</asp:ListItem>   
                                   <asp:ListItem>Activo</asp:ListItem>  
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                          
                            </table>
                        </div>

       </ContentTemplate>
              </asp:UpdatePanel>

         <asp:Button ID="Button" runat="server" Text="Guardar" OnClick="Button_Click" />
 </asp:Content>
