<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog2.master" CodeFile="Bitacoras.aspx.cs" Inherits="IOT_Bitacoras" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css"/>
    <link rel="stylesheet" href="../Content/component_barNav.css" type="text/css" media="screen"/>
    <script src="../Scripts/Script_barNav.js"></script>
    <script src="../Scripts/modernizr.custom_barNav.js"></script>
         
 
   <div class="MiLabel">
     <a href="Home.aspx" runat="server" >
       <img src="../iconos/risc.jpeg" style="max-width:100%;width:50px;height:50px;">
      </a>    
   <asp:Label ID="cli" runat="server" CssClass="MiLabel"  Text="">
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
     
    <div class="main clearfix">
				<nav id="menu" class="nav5">					
					<ul>
						<li>
							<asp:HyperLink runat="server" ID="Dispositivos" Visible="false" href="../IOT/Acciones.aspx">
								<span class="icon">
									<i class="fas fa-clipboard-list"></i>
								</span>
								<span><b>Dispositivos</b></span>
							</asp:HyperLink>
                            
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="Sensores" Visible="false" href="../IOT/AccionesHS.aspx">
								<span class="icon">
									<i class="fas fa-plus-square"></i>
								</span>
								<span><b>Sensores</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server" ID="Ambiente" Visible="false" href="../IOT/Ambiente.aspx">
								<span class="icon"> 
									<i class="fas fa-user-alt"></i>
								</span>
								<span><b>Ambiente</b></span>
							</asp:HyperLink>
						</li>
						
						<li>
							<asp:HyperLink runat="server" ID="HuellaDactilar" Visible="false" href="../IOT/huellaDactilar.aspx">
								<span class="icon">
									<i class="far fa-thumbs-up"></i>
								</span>
								<span><b>Huella dactilar</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server"  visible="false" ID="ConteoPersonas" href="../IOT/ConteoPersonas.aspx">
								<span class="icon">
									<i class="fas fa-building"></i>
								</span>
								<span><b>Conteo de personas</b></span>
							</asp:HyperLink>
						</li>

						<li>
							<asp:HyperLink runat="server" ID="Electrico" Visible="false" href="../IOT/Electrico.aspx">
								<span class="icon">
									<i class="fa fa-battery-full"></i>
								</span>
								<span><b>Eléctrico</b></span>
							</asp:HyperLink>
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="ReporteRISC" Visible="false" href="../IOT/ReporteExcelRisc.aspx">
								<span class="icon">
									<i class="fas fa-database"></i>
								</span>
								<span><b>Reporte RISC</b></span>
							</asp:HyperLink>
						</li>
                        
						<li>
							<asp:HyperLink runat="server" ID="MapaRastreo" Visible="false" href="../IOT/MapaRastreo.aspx">
								<span class="icon">
									<i class="fas fa-map-marker-alt"></i>
								</span>
								<span><b>Rastreo Satelital</b></span>
							</asp:HyperLink>
						</li>
					</ul>
				</nav>

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