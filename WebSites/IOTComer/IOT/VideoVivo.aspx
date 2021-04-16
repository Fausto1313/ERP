<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="VideoVivo.aspx.cs" Inherits="IOT_VideoVivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
        <div class="navbar-header">
            <a class="navbar-brand" href="#" style="color:azure">Video en Vivo</a>
        </div>  
    </nav>
    <br />
    <div class="responsive-video">
        <iframe id="frame" runat="server" style="height: 580px; width: 1170px" align="center" frameborder="0" allowfullscreen="true">
            
        </iframe>
    </div> 
    <br />
    <div>
                  <a class="btn btn-danger" href="CamaraVideo.aspx" runat="server" role="button">Volver</a>
                </div>
</asp:Content>
