<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<%--<INPUT type=file id=File1 name=File1 runat="server" />
<br>
<input type="submit" id="Submit1" value="Upload" runat="server" onclick="Submit1_ServerClick" />--%>
    <asp:Button runat="server" ID="BotonPrueba" OnClick="BotonPrueba_Click" CssClass="btn btn-danger" Text="Presioname" />
    <asp:Label runat="server" ID="TextoPrueba" />
    <asp:Button runat="server" ID="prueba2" OnClick="prueba2_Click" />
</asp:Content>

