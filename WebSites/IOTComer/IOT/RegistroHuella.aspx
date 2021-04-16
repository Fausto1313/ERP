<%@ Page Language="C#"  MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="RegistroHuella.aspx.cs" Inherits="IOT_RegistroHuella" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">

           <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
<nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
   
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Registro de huella</a>
    </div>
   
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li>

        </li>  
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group"></div>  
      </div>
    </div>
  </div>
</nav> 
    <asp:UpdatePanel ID="IUpEmp" runat="server">
          <ContentTemplate>
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
   <asp:GridView runat ="server" ID="IdNombre" CssClass="table table-hover table-striped" Width="720px" HorizontalAlign="Center" AutoGenerateColumns="false">
       <Columns>
           <asp:BoundField DataField="nombre" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Apellidos" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Apellido" SortExpression="Name" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField DataField="ID_Nomina" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nomina" SortExpression="ID_Nomina" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
           </Columns>
   </asp:GridView>
                 
    
    </div>
    
    <br />
    <br />
              </ContentTemplate>
         </asp:UpdatePanel>
       <div class="form-horizontal">
        <div class="row" >            
   
            </div>
      </div>  

         <div><br /><br />
        <div>
    Seleccione un archivo para subir:<br />
        <asp:FileUpload ID="FlpArchivo" CssClass="btn btn-success" runat="server" BorderColor=#2e7d32 ValidationGroup="Subir" />
        <br />
        <asp:Label ID="lblinformacion"  runat="server" Text=""></asp:Label>
        <br /><br />
             
             <asp:Label runat="server" />
                               
        <asp:Button ID="Btnenviar" CssClass="btn btn-danger" runat="server" BorderColor=#2e7d32  Text="Enviar" ValidationGroup="Subir" onclick="Btnenviar_Click" Width="100px" />
        <br /><br />
            <asp:RegularExpressionValidator 
             id="RegularExpressionValidator1" runat="server" 
             ErrorMessage="Solo dat, doc o xls son permitidos." 
             ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.dat|.doc|xls)$" 
             ControlToValidate="FlpArchivo">
        </asp:RegularExpressionValidator>
    </div>
          
    </div>
        <div>
    Seleccione una imagen a subir:<br />
        <asp:FileUpload ID="FileUpload1" CssClass="btn btn-success" runat="server" BorderColor=#2e7d32 ValidationGroup="Subir" />
        <br />
        <asp:Label ID="Label1"  runat="server" Text=""></asp:Label>
        <br /><br />
             
             <asp:Label runat="server" />
                               
        <asp:Button ID="Button2" CssClass="btn btn-danger" runat="server" BorderColor=#2e7d32  Text="Guardar Imagen" ValidationGroup="Subir" onclick="Btnenviar_ClickI" Width="100px" />
        <br /><br />
            <asp:RegularExpressionValidator 
             id="RegularExpressionValidator2" runat="server" 
             ErrorMessage="Solo dat, doc o xls son permitidos." 
             ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpg)$" 
             ControlToValidate="FileUpload1">
        </asp:RegularExpressionValidator>
    </div>
      <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center"><!--div Margen-->
      <asp:UpdatePanel ID="upCrudGrid" runat="server">            
          <ContentTemplate>
               
        <asp:GridView ID="Idmano" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true"
         DataKeyNames="Id" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" OnPageIndexChanging="OnPageIndexChanging" >
        <Columns>
            
            <asp:BoundField DataField= "Id"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Id" SortExpression="Id" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center" CssClass="Hidden"></HeaderStyle>
                </asp:BoundField>
                  
            <asp:BoundField DataField="nombre_archivo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nombre Archivo" SortExpression="Nombre Archivo" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Nomina" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Nomina" SortExpression="No Nomina" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
              <asp:BoundField DataField="ImagenHuella" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ImagenHuella" SortExpression="No Nomina" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
             <asp:buttonField  CommandName="deleteRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>
             <asp:buttonField  CommandName="EnviarRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-primary" Text="Enviar" HeaderText="Enviar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>
             <asp:buttonField  CommandName="HuellaRecord" ButtonType="Button"  ControlStyle-CssClass="btn btn-success" Text="Mostrar Imagen" HeaderText="Enviar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
            </asp:buttonField>
        </Columns>   
    </asp:GridView>
            </ContentTemplate>     
          <Triggers>
        </Triggers>
      </asp:UpdatePanel>
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
                <asp:AsyncPostBackTrigger ControlID="Idmano" EventName="RowCommand" />
                <asp:AsyncPostBackTrigger ControlID="BtnDelete" EventName="Click" />    
                </Triggers>
                </asp:UpdatePanel>
           </div>
           </div>
           </div>
    <!-- FIN MODAL ELIMINAR -->
    
      <div id="EnviaHuellaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
               <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    <h3 id="updModalLabel1" style="color:azure">Enviar archivo</h3>
                </div>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                            <table class="table">
                                 <td>ID: 
                        <asp:Label ID="lblID" runat="server" BorderColor=#0c4566></asp:Label>
                        </td>                               
                                <tr>
                                    <td>NOIP:
                                    <asp:DropDownList runat="server" ID="Noip" BorderColor=#0c4566 />
                                    <asp:Label runat="server" />
                                    </td>
                                </tr>
                          
                            </table>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblResultt" Visible="false" runat="server"></asp:Label>
                            <asp:Button ID="Button1" runat="server" ValidationGroup="addfinger" OnClick="BtnEnvia_Click" Text="Guardar" CssClass="btn btn-success" />
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                   </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
      <!---->
    <div id="MuestraHuellaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="UpdModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-content">
               <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
                    
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">

                      <asp:Image ID="imgImagen" runat="server" ImageUrl="http://addar:8082/huellas/JL.jpg"  class="" AlternateText="Huella" />
                          
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="Label3" Visible="false" runat="server"></asp:Label>
                            <button  class="btn btn-secondary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                        </div>
                    </ContentTemplate>
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                   </Triggers>
                </asp:UpdatePanel>
                    </div>
                    </div>
                    </div>
            </div>
       
     <
    <!---->
     <!-- Inicia Modal Para Nuevo Registro-->
            <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header"  style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
                    <h3 id="addModalLabel" style="color:azure">Nueva Huella</h3>
                </div>
                    <div class="form-group">
                <asp:UpdatePanel ID="upAdd" class="form-group"  runat="server">
                       <ContentTemplate>
                        <div class="modal-body">
                             <div class="form-horizontal" role="form">
                            <table class="table table-bordered table-hover">
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">ID</label>
                                <asp:label ID="lblID1"  runat="server"></asp:label>
                                 
                                     </div>
                                 
                             <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Mano:</label>
                           
                                 <asp:dropdownlist runat="server" id="IdsMano"> 
                                 <asp:listitem text="Derecha" value="1"></asp:listitem>
                                 <asp:listitem text="Izquierda" value="2"></asp:listitem>
   
                                    </asp:dropdownlist>  
                                     </div>
                                <div class="form-group">
                                    <label for="input" class="col-md-3 control-label">Dedo:</label>
                           
                                 <asp:dropdownlist runat="server" id="Dropdownlist1"> 
                                 <asp:listitem text="Pulgar" value="1"></asp:listitem>
                                 <asp:listitem text="Indice" value="2"></asp:listitem>
                                     <asp:listitem text="Dedo Medio" value="3"></asp:listitem>
                                 <asp:listitem text="Anular" value="4"></asp:listitem>
                                 <asp:listitem text="Meñique" value="5"></asp:listitem>
                                    </asp:dropdownlist>  
                                     </div>
                                       
                            
                            </table>
                        </div>
                            </div>
                        <div class="modal-footer">                          
                            <asp:Button ID="BtnAddRecord" runat="server" ValidationGroup="Agregar" OnClick="BtnAddRecordClick" Text="Confirmar " CssClass="btn btn-success" />
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

    </asp:Content>
