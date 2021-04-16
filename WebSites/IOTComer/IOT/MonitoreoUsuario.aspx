<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="MonitoreoUsuario.aspx.cs" Inherits="IOT_MonitoreoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    &nbsp;<br />
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
        <div class="navbar-header">
            <a class="navbar-brand" href="#" style="color:azure">Usuarios Telegram</a>
        </div>  
    </nav>
    <style>
            .icon-success {
    color:red;
     font-size:20px;
}
    </style>
    <br />
    <div>
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="Id" CssClass="table table-hover table-striped">
        <Columns> 
            <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="URL" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="URL" SortExpression="URL" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    </div>
    <br />
    <div class="row" >
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="col-md-6">
            <div class="col-md-4">
                <asp:Label runat="server"><b> Usuario Telegram:</b></asp:Label>
            </div>
            <asp:DropDownList runat="server" CssClass="form-control" BorderColor=#0c4566  ID="telegramp"/>
        </div>   
            <asp:Button runat="server" OnClick="Asignar" BorderColor=#2e7d32 Text="Registrar" CssClass="btn btn-success" alig="center" BorderStyle="Solid" Width="155px"/> 
    </div>
    <br />
    <asp:UpdatePanel ID="upCrudGrid" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView2" DataKeyNames="Telegram" runat="server" Width="940px" HorizontalAlign="Center" AutoGenerateColumns="false" AllowPaging="true" OnRowCommand="OnRowCommand" CssClass="table table-hover table-striped" >
        
             <Columns> 
            <asp:BoundField DataField="Telegram" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Id Chat" SortExpression="Id Chat" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="usuario" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Usuario Telegram" SortExpression="Telegram" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
                     <asp:ButtonField CommandName="delRecord" HeaderText="Eliminar" ShowHeader="True" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566
    Text='<i class="glyphicon glyphicon-remove icon-success"></i>' /> 
          <%--  <asp:buttonField  CommandName="delRecord" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" Text="Eliminar" HeaderText="Eliminar" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:buttonField>--%>
        </Columns>
    </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <a class="btn btn-danger" href="Monitoreo.aspx" runat="server" role="button">Volver</a>
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


