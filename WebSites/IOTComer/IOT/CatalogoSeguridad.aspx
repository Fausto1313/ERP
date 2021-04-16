﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatalogoSeguridad.aspx.cs" MasterPageFile="~/IOT/SiteLog2.master" Inherits="IOT_CatalogoSeguridad" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" />
    <link rel="stylesheet" href="../Content/component_barNav.css" type="text/css" media="screen"/>
    <script src="../Scripts/Script_barNav.js"></script>
    <script src="../Scripts/modernizr.custom_barNav.js"></script>

 <div class="MiLabel">
     <a href="Home.aspx" runat="server" >
       <img src="../iconos/risc.jpeg" style="max-width:100%;width:50px;height:50px;">
      </a>    
   <asp:Label ID="cli" runat="server" CssClass="MiLabel" >
   </asp:Label>        
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
    <%--<div class="icon_wrapper" id="ico1">--%>
    <a href="Home.aspx" runat="server" >
    <img  class="icon" width="50" height="50" style="padding-top:inherit" src="data:image/png;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem, "icono"))%>"/> 
    </a>
    <%--</div>--%>
    </ItemTemplate>
    </asp:Repeater>
    </div>
     <hr />         
<!-- CATALOGOS -->
    <div class="main clearfix">
				<nav id="menu" class="nav1">					
					<ul>
						<li>
							<asp:HyperLink runat="server" ID="ProgramacionTareas"  Visible="false" href="../IOT/Automatizado.aspx">
								<span class="icon"> 
									<i class="fas fa-book-open"></i>
								</span>
								<span><b>Programación de Tareas</b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="ActivacionSistema"  Visible="false" href="../IOT/Activado.aspx">
								<span class="icon"> 
									<i class="fas fa-key"></i>
								</span>
								<span><b>Activación de Sistema</b></span>
							</asp:HyperLink>
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="SimuladorPresencia"  Visible="false" href="../IOT/SimuladorPresencia.aspx">
								<span class="icon"> 
									<i class="fas fa-user-clock"></i>
								</span>
								<span><b>Simulador de presencia</b></span>
							</asp:HyperLink>
						</li>
                          <li>
							<asp:HyperLink runat="server" ID="Video"  Visible="false" href="../IOT/CamaraVideo.aspx">
								<span class="icon">
									<i class="fa fa-camera"></i>
								</span>
								<span><b>Camara</b></span>
							</asp:HyperLink>
						</li>
                        </ul>
                    </nav>
         <div>
        <a class="btn btn-danger" href="CatalogosGeneral.aspx" runat="server" role="button">Volver</a>
    </div>
        </div>
   
       
   
<!-- FIN CATALOGOS -->
   <style>
       .Capacitacion
       {
color:#0D3685;
font-family: Arial; 
font-size:150%; 
font-weight:normal;
width:70%;
       }
       .Risc
       {
color:#0D3685;
font-family: Arial; 
font-size:200%; 
font-weight:normal;
width:100%;
       }
       .MiLabel
{
text-align:center;
color: #0D3685;
font-family: Arial; 
font-size:150%; 
font-weight:normal;
width:100%;
}
       .carousel-inner img {
    width: 100%;
    max-height: 460px;

}

.carousel-inner{
 height: auto;

}
.modal-header
 {
    text-align:center;
  color:#eee;
     padding:9px 15px;
     border-bottom:1px solid #eee;
     background-color: #428bca;
 }
 .modal-header .close{margin-top:2px}
 .modal-header h3{margin:0;line-height:30px}
       .modal-body 
{
     text-align:justify;
    
    background-color: #FFFFFF;
}

.modal-content
{
    border-radius: 6px;
    -webkit-border-radius: 6px;
    -moz-border-radius: 6px;
    background-color:#FFFFFF ;
    border-color:dodgerblue;
    
  
}

.modal-footer
{
    border-bottom-left-radius: 6px;
    border-bottom-right-radius: 6px;
    -webkit-border-bottom-left-radius: 6px;
    -webkit-border-bottom-right-radius: 6px;
    -moz-border-radius-bottomleft: 6px;
    -moz-border-radius-bottomright: 6px;
    -moz-border-image:round;
}
   </style>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>