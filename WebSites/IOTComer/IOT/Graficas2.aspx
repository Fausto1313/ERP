<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Graficas2.aspx.cs" Inherits="IOT_Graficas2" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">

<%--     <div class="form-horizontal">
        <div class="row" >            
             <asp:Label runat="server" AssociatedControlID="Cliente" CssClass="col-md-1 control-label"><b>Ciente</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Cliente" CssClass="form-control" BorderColor=#0c4566 OnSelectedIndexChanged="Carga_select" AutoPostBack="true"/>
            </div>
            <asp:Label runat="server" AssociatedControlID="Sitio" CssClass="col-md-1 control-label"><b>Sitio</b></asp:Label>
            <div class="col-md-3"> 
                <asp:DropDownList runat="server" ID="Sitio" CssClass="form-control" BorderColor=#0c4566  AutoPostBack="true"/>
            </div>
            <asp:Label runat="server" AssociatedControlID="Tipo" CssClass="col-md-1 control-label"><b>Bitacora de dispositivos</b></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList runat="server" ID="Tipo" CssClass="form-control" BorderColor=#0c4566 AutoPostBack="true" OnSelectedIndexChanged="Carga_Bind" >
                 <asp:ListItem Value="0">[Seleccionar]</asp:ListItem>
                 <asp:ListItem Value="1">Bitacora Accionadores</asp:ListItem>
                 <asp:ListItem Value="2">Bitacora Sensores</asp:ListItem>
                </asp:DropDownList>    
            </div>
            </div>        
        </div> --%>
    <br />
    <asp:Chart runat="server" ID="ctl00" Width="538px" BackColor="Silver" BackSecondaryColor="White" BackGradientStyle="TopBottom">
    <series><asp:Series Name="Series1" ChartType="Pie" ChartArea="ChartArea1"></asp:Series></series>
    <chartareas><asp:ChartArea Name="ChartArea1" BackSecondaryColor="White" BackColor="Gainsboro" BackGradientStyle="DiagonalLeft"></asp:ChartArea></chartareas>
         <Titles>
            <asp:Title Text="DARS" Name="Title1" />
        </Titles>
         <BorderSkin SkinStyle="Emboss" />
</asp:Chart>
</asp:Content>


