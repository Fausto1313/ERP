﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="graf.aspx.cs" Inherits="IOT_graf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Chart ID="Graficas" runat="server">
            <Series>
                <asp:Series Name="Series"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        </div>
    </form>
</body>
</html>