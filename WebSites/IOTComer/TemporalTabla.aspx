<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TemporalTabla.aspx.cs" Inherits="TemporalTabla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="ID" CssClass="table table-hover table-striped"
                        OnPageIndexChanging="PageIndexChanging" >
        <Columns>
           <asp:BoundField DataField="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="macID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="macID" SortExpression="macID" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
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
            <asp:BoundField DataField="fecha" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Fecha" SortExpression="fecha" HeaderStyle-ForeColor="White" HeaderStyle-BackColor=#0c4566>
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>

