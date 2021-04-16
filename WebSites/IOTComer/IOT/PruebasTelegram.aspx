<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="PruebasTelegram.aspx.cs" Inherits="IOT_PruebasTelegram" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    
    <asp:Label runat="server" Text="Mensaje de Telegram" />
    <asp:TextBox runat="server" ID="Telegram" />
    <asp:Button runat="server" ID="Accion" CssClass="btn btn-class-danger" OnClick="Accion_Click" Text="Mandar Telegram" />

</asp:Content>

