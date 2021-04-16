<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatalogosGeneral.aspx.cs" MasterPageFile="~/IOT/SiteLog2.master" Inherits="IOT_CatalogosGeneral" %>

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
							<asp:HyperLink runat="server" ID="CatalogoTelegram"  Visible="false" href="../IOT/CatalogosAdmin.aspx">
								<span class="icon">
                                   <i class="fab fa-telegram"></i>
								</span>
								<span><b>Catalogos Telegram</b></span>							
							</asp:HyperLink>                            
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="CatalogosUser"  Visible="false" href="../IOT/CatalogosUser.aspx">
								<span class="icon">
                                    <i class="fas fa-user-cog"></i>
								</span>
								<span><b>Catalogos Usuario y Roles </b></span>
							</asp:HyperLink>
						</li>
					  <li>
							<asp:HyperLink runat="server" ID="CatalogoDispos"  Visible="false" href="../IOT/CatalogoDispos.aspx">
								<span class="icon">
                                    <i class="fas fa-map"></i>
								</span>
								<span><b>Control de Dispositivos </b></span>
							</asp:HyperLink>
						</li>
                     <li>
							<asp:HyperLink runat="server" ID="CatalogoComan"  Visible="false" href="../IOT/CatalogoComandos.aspx">
								<span class="icon">
                      <i class="fas fa-microphone"></i>
								</span>
								<span><b>Consulta Dispo y Comandos </b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="CatalogoSeg"  Visible="false" href="../IOT/CatalogoSeguridad.aspx">
								<span class="icon">
                   <i class="fas fa-shield-alt"></i>
								</span>
								<span><b>Seguridad </b></span>
							</asp:HyperLink>
						</li>
                          <li>
							<asp:HyperLink runat="server" ID="Paginas"  href="../IOT/AdministracionPagina.aspx">
								<span class="icon">
									<i class="fas fa-solar-panel"></i>
								</span>
								<span><b>Administración de Páginas</b></span>
							</asp:HyperLink>
						</li> 
                         <li>
							<asp:HyperLink runat="server" ID="Temperatura"  href="../IOT/CatalogoTemperatura.aspx">
								<span class="icon">
									<i class="fas fa-fire-alt"></i>
								</span>
								<span><b>Temperatura Umbral</b></span>
							</asp:HyperLink>
						</li> 
                           <li>
							<asp:HyperLink runat="server" ID="AdminEmpleados"  href="../IOT/CatalogoAdminEm.aspx">
								<span class="icon">
									<i class="far fa-address-card"></i>
								</span>
								<span><b>Administración Empleados</b></span>
							</asp:HyperLink>
						</li> 
                        <li>
							<asp:HyperLink runat="server" ID="Restaurant" Visible="false" href="../IOT/CatalogosRestaurant.aspx">
								<span class="icon">
									<i class="fas fa-utensils"></i>
								</span>
								<span><b>Restaurantes</b></span>
							</asp:HyperLink>
						</li>
                        </ul>
                    </nav>
        </div>
   
        <div class="main clearfix">
				<nav id="menu1" class="nav3">					
					<ul>
                         <li>
							<asp:HyperLink runat="server" ID="CatalogoAdminisUs"  Visible="false" href="../IOT/CatalogoUsuariosAdr.aspx">
								<span class="icon"> 
									<i class="fas fa-user-alt"></i>
								</span>
								<span><b>Roles y Usuarios Administrador</b></span>
							</asp:HyperLink>
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="ConfigPlan"  Visible="false" href="../IOT/Configuraciones.aspx">
								<span class="icon"> 
									<i class="fas fa-map"></i>
								</span>
								<span><b>Configuraciónes Administrador</b></span>
							</asp:HyperLink>
						</li>
                     <li>
							<asp:HyperLink runat="server" ID="CatDis"  Visible="false" href="../IOT/CatalogoDi.aspx">
								<span class="icon"> 
								<i class="fas fa-box"></i>
								</span>
								<span><b>Dispositivos</b></span>
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