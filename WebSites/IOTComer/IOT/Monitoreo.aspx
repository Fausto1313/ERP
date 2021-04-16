<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" debug="True" CodeFile="Monitoreo.aspx.cs" Inherits="IOT_Monitoreo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    &nbsp;<br />
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
        <div class="navbar-header">
            <a class="navbar-brand" href="#" style="color:azure">Direcciones</a>
        </div>  
    </nav>
    <div class="row" >
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="col-md-4">
             <asp:Label runat="server" CssClass="control-label"><b> Url </b></asp:Label>
             <asp:TextBox runat="server" ID="Url"  placeholder="Url" CssClass="form-control" BorderColor=#0c4566 autocomplete="off"/>
             <asp:RequiredFieldValidator runat="server"   ControlToValidate="Url" CssClass="text-danger" ErrorMessage="El campo Url es obligatorio." ValidationGroup="groupInsert"/> 
        </div>      
        <br />
        <asp:Button runat="server" BorderColor=#2e7d32 OnClick="Agregar" Text="Registrar" CssClass="btn btn-success" alig="center" BorderStyle="Solid" Width="155px" ValidationGroup="groupInsert"/>    
    </div>
    <style>
        .icon-success {
    color:red;
     font-size:20px;
}
 .icon-telegram {
    color:forestgreen;
     font-size:20px;
}
    </style>
    <br />
    <br />
    <asp:UpdatePanel ID="upCrudGrid" runat="server">
         <ContentTemplate>
             <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="URL" CssClass="table table-hover table-striped" OnRowCommand="OnRowCommand" >
        <Columns> 
            <asp:BoundField DataField="URL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="URL" SortExpression="URL" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                 <asp:ButtonField CommandName="Asignar" HeaderText="Asignar Telegram" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-send icon-telegram"></i>' /> 
                 
<%--            <asp:buttonField  CommandName="Asignar" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" Text="Asignar Telegram" HeaderText="Asignar Telegram" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:buttonField>--%>
                <asp:ButtonField CommandName="Eliminar" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' /> 
          <%--  <asp:buttonField  CommandName="Eliminar" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
         </ContentTemplate>
    </asp:UpdatePanel>
    <div style="width: 90%; margin-right: 5%; margin-left: 5%; text-align: center">
        <asp:Button runat="server"  BorderColor=#2e7d32 OnClick ="Ping" Text="Monitorear" CssClass="btn btn-info" alig="center" BorderStyle="Solid" Width="155px" />
    </div>
    &nbsp;<br />
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
        <div class="navbar-header">
            <a class="navbar-brand" href="#" style="color:azure">Monitoreo</a>
        </div>  
    </nav>

   <asp:GridView ID="GridView2" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-hover table-striped"  >
        <Columns> 
            <asp:BoundField DataField="URL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="URL" SortExpression="URL" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Estado" SortExpression="Estado" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
   </asp:GridView> 

    <div>
        <a class="btn btn-danger" href="Catalogos.aspx" runat="server" role="button">Volver</a>
    </div>

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
 
    
</asp:Content>

