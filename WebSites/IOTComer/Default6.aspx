<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default6.aspx.cs" Inherits="Default6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:FileUpload runat="server" ID="FileUpload1" />
    <asp:Button runat="server" ID="carga" OnClick="carga_Click" Text="Cargar archivo" />
    <asp:Label runat="server" ID="Label1"/>
</asp:Content>

