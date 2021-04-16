<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/IOT/SiteLog.master" CodeFile="grafica.aspx.cs" Inherits="IOT_grafica" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
 
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent2" Runat="Server">
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Graficas de Prueba</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li></li>    
      </ul>
       <div class="navbar-form navbar-left">
        <div class="form-group">       
        </div>     
        </div>
    </div>
  </div>
</nav> 
        <br />

    <asp:Chart ID="Graficas" runat="server" Width="538px" BackColor="Silver" BackSecondaryColor="White" BackGradientStyle="TopBottom">
        <Series>
            <asp:Series Name="Series1" ChartArea="ChartArea">
                
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea" BackSecondaryColor="White" BackColor="Gainsboro" BackGradientStyle="DiagonalLeft">
            </asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Text="Prueba de Grafica" />
        </Titles>
        <BorderSkin SkinStyle="Emboss" />
    </asp:Chart>
 
   
 </asp:Content>