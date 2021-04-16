<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="SimuladorPresencia.aspx.cs" Inherits="IOT_SimuladorPresencia" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent2">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
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
      <a class="navbar-brand" href="#" style="color:azure">Simulador de presencia</a>
    </div>
    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li><!--Inicio de ]Modal
            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal"> Cliente Nuevo</button>
            fin de modal-->
        </li>  
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group"></div>  
      </div>
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav> 
     <style>
        .icon-success {
    color:red;
     font-size:20px;
}
 .icon-consultar{
    color:darkorange;
     font-size:20px;
}
 .icon-dias {
    color:blue;
     font-size:20px;
}
 .icon-asig {
    color:green;
     font-size:20px;
}
    </style>
     <!--- DESCRIPCION DE CATALOGO--->
    <div class="alert alert-danger" role="alert">
<a class="alert-link">En este catálogo se realizará el alta el nombre del evento atravez del sitio y del horario que se ejecutara .
    <p>
        INSTRUCCION: Para asignar el DAR deberás dar clic en el icono azul
    </p>

</a>
      
        </div>
    <!--- FIN DE DESCRIPCION DE CATALOGO--->
    <br />
<!-- INICIA SIMULADOR DE PRESENCIA -->

    <div class="form-horizontal">
        <div class="row" style="position:absolute">
            
            <asp:Label runat="server"  CssClass="col-md-1 control-label"><b>Nombre</b> </asp:Label>
            <div class="col-md-3">
                <asp:TextBox runat="server" ID="Nombre"  placeholder="Nombre de activacion" CssClass="form-control" BorderColor=#0c4566 />
                <asp:RequiredFieldValidator runat="server"   ControlToValidate="Nombre"
                    CssClass="text-danger" ErrorMessage="El nombre obligatorio." ValidationGroup="groupInsert"/>
            </div>   
             <asp:Label runat="server" AssociatedControlID="Sitios" CssClass="col-md-1 control-label"><b>Sitio</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Sitios"   CssClass="form-control" BorderColor=#0c4566 />
            </div>
             <asp:Label runat="server" CssClass="col-md-1 control-label"><b>Horario</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="hora"  CssClass="form-control" BorderColor=#0c4566>
                <asp:ListItem Value="0">Seleccione un horario</asp:ListItem>
                <asp:ListItem Value="1">Matutino</asp:ListItem>
                <asp:ListItem Value="2">Vespertino</asp:ListItem>
                <asp:ListItem Value="3">Nocturno</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
        </div>
    <br /><br /><br />
        
        
    <br/>
  <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">            
          <ContentTemplate>

         <asp:Button runat="server" BorderColor=#2e7d32 OnClick="CreaTarea_Click" Text="Agregar Tarea" CssClass="btn btn-success" Width="162px"/><br /><br /><br />
   
              <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand"  OnPageIndexChanging="PageIndexChanging">
        <Columns>

            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           
            <asp:BoundField DataField="Nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Tarea" SortExpression="Tarea" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="C_Sitio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Sitio" SortExpression="Sitio" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="Horario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Horario" SortExpression="Horario" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField> 
                             <asp:ButtonField CommandName="Asignar" HeaderText="Asignar DAR" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-hdd icon-dias"></i>' />
             <%--<asp:buttonField  CommandName="Asignar" ButtonType="Button"  ControlStyle-CssClass="btn btn-success" Text="Asignar" HeaderText="Asignar DAR" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
             </asp:buttonField>--%>
                      <asp:ButtonField CommandName="diaRecord" HeaderText="Asignar Dias" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-ok icon-asig"></i>' />
          <%--  <asp:buttonField  CommandName="diaRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-info" Text="Dia" HeaderText="Asignar dias" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
            <asp:ButtonField CommandName="ConsultaDias" HeaderText="Consultar Dias" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-calendar icon-consultar"></i>' />
           <%-- <asp:buttonField  CommandName="ConsultaDias" ButtonType="Button"  ControlStyle-CssClass="btn btn-warning" Text="Consultar" HeaderText="Consultar dias" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
             <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' />
           <%-- <asp:buttonField  CommandName="delRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>--%>
        </Columns>   
    </asp:GridView>
            </ContentTemplate>
     
          <Triggers>
        </Triggers>


      </asp:UpdatePanel>
    </div>
    <div>
        <a class="btn btn-danger" href="CatalogoSeguridad.aspx" runat="server" role="button">Volver</a>
    </div>
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

     <!-- Inicia Modal Para CONSULTAR-->
      <div id="ConsultaModal" class="modal fade"  tabindex="-1"  aria-labelledby="delModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="delModalLabel1" style="color:azure">Permisos</h3>
                </div>
                <asp:UpdatePanel ID="Consulta" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">                  
       <asp:GridView ID="GridView2" runat="server" Width="1024px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped" OnPageIndexChanging="GridView2_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Lunes" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Lunes" SortExpression="Dia">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Martes" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Martes" SortExpression="Dia">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Miercoles" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Miercoles" SortExpression="Dia">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Jueves" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Jueves" SortExpression="Dia">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Viernes" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Viernes" SortExpression="Dia">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Sabado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Sabado" SortExpression="Dia">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Domingo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Domingo" SortExpression="Dia">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>  
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                        <div class="modal-footer">
                            
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>          
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                    </Triggers>
                </asp:UpdatePanel>
                     </div>
                    </div>
            </div>


    <!-- MODAL ADD DIAS -->
        <div id="addDay" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                    <h3 id="addModalLabel1" style="color:azure">Asignar permisos</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="UpdatePanel" class="form-group"  runat="server">
                       <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                                <div class="form-group">
                                    <asp:label ID="ID" class="col-md-3 control-label"  runat="server"><b>ID:</b></asp:label>
                                    <asp:label ID="Label1"  runat="server" class="col-md-1 control-label"></asp:label>                                
                                     </div> 
                             <div class="form-group">                                  
                                     </div>    
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Lunes:</label>
                               <asp:CheckBox ID="chLunes" runat="server" BorderColor=#0c4566  class="col-md-1 control-label"/>
                                    </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Martes</label>
                               <asp:CheckBox ID="chMartes" runat="server" BorderColor=#0c4566  class="col-md-1 control-label"/>
                                     </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Miercoles</label>
                                <asp:CheckBox ID="chMiercoles" runat="server" BorderColor=#0c4566  class="col-md-1 control-label" />
                                     </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Jueves</label>
                                <asp:CheckBox ID="chJueves" runat="server" BorderColor=#0c4566  class="col-md-1 control-label" />
                                    </div>
                                    <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Viernes</label>
                                <asp:CheckBox ID="chViernes" runat="server" BorderColor=#0c4566  class="col-md-1 control-label"/>
                                     </div>
                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Sabado</label>
                                <asp:CheckBox ID="chSabado" runat="server" BorderColor=#0c4566  class="col-md-1 control-label"/>
                                     </div>
                                     <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Domingo</label>
                                <asp:CheckBox ID="chDomingo" runat="server" BorderColor=#0c4566  class="col-md-1 control-label"/>
                                     </div>
                                  </div>             
                            </table>
                        </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="Button2" runat="server"  OnClick="BtnAddRecordClick1" Text="Confirmar " CssClass="btn btn-success"  />
                            <button class="btn btn-default" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                        </div>
                    </div>
                    </div>
            </div>                    
    <!-- FIN MODAL DIAS-->

   

    <!-- Inicia Modal Para CONSULTAR-->
  
 </asp:Content>