<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TablaElectrico.aspx.cs" Inherits="TablaElectrico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="GridView1" Width="940px" HorizontalAlign="Center"
                         AutoGenerateColumns="false" AllowPaging="true"
                        DataKeyNames="id_electrico" 
                        OnPageIndexChanging="PageIndexChanging">
                <Columns>
           <asp:BoundField DataField="id_electrico" HeaderText="ID" SortExpression="id_electrico">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="RISCEI" HeaderText="RISCEI" SortExpression="RISCEI">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="Watts" HeaderText="Watts" SortExpression="Watts">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="Amperaje" HeaderText="Amperaje" SortExpression="Amperaje">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
            <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
           <ItemStyle HorizontalAlign="Center"></ItemStyle>
           </asp:BoundField>
        </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
