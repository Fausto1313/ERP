<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

<asp:Content  ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
    <input id="flimage" runat="server" type="file" />
<asp:Button ID="Button1" runat="server" onclick="Button1_Click"   Text="-->" />
<asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
    </asp:Content>