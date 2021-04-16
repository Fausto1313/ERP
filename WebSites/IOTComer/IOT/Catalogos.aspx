<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog2.master" CodeFile="Catalogos.aspx.cs" Inherits="IOT_HomeAdmin2" %>

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
							<asp:HyperLink runat="server" ID="Telegram" Visible="false" NavigateUrl="~/IOT/Telegram.aspx">
								<span class="icon">
                                <i class="fab fa-telegram-plane"></i>
								</span>
								<span><b>Telegram</b></span>							
							</asp:HyperLink>                            
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="UsuariosTelegram"  Visible="false" NavigateUrl="../IOT/TelegramUsers.aspx">
								<span class="icon">
									<i class="far fa-thumbs-up"></i>
								</span>
								<span><b>Usuarios telegram</b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="CanalTelegram"  Visible="false" NavigateUrl="../IOT/CanalTelegram.aspx">
								<span class="icon">
									<i class="fas fa-comments"></i>
								</span>
								<span><b>Canales de Telegram</b></span>
							</asp:HyperLink>
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="CanalTelegramEmpleado"  Visible="false" NavigateUrl="../IOT/CanalTelegramEmpleado.aspx">
								<span class="icon">
									<i class="fas fa-comments"></i>
								</span>
								<span><b>Telegram para Empleados</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server" ID="Usuarios"  Visible="false" NavigateUrl="../IOT/Register.aspx">
								<span class="icon"> 
									<i class="fas fa-user-alt"></i>
								</span>
								<span><b>Usuarios</b></span>
							</asp:HyperLink>
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="CambiarContraseña" href="../Account/Manage.aspx">
								<span class="icon"> 
									<i class="fa fa-user-edit"></i>
								</span>
								<span><b>Cambiar contraseña</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server" ID="Roles"  Visible="false" href="../IOT/Permisos.aspx">
								<span class="icon">
									<i class="fas fa-plus-square"></i>
								</span>
								<span><b>Roles</b></span>
							</asp:HyperLink>
						</li>
						
						<li>
							<asp:HyperLink runat="server" ID="PlanosAdministrador"  Visible="false" href="../IOT/PlanoAd.aspx">
								<span class="icon">
									<i class="fas fa-map"></i>
								</span>
								<span><b>Planos Administrador</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server" ID="ControlBotones"  Visible="false" href="../IOT/ControlMultiBoton.aspx">
								<span class="icon"> 
									<i class="fas fa-tablet-alt"></i>
								</span>
								<span><b>Control Botones</b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="MisDispositivos"  Visible="false" href="../IOT/MisDispositivos.aspx">
								<span class="icon"> 
									<i class="fas fa-barcode"></i>
								</span>
								<span><b>Mis dispositivos</b></span>
							</asp:HyperLink>
						</li>
                       
                        </ul>
                    </nav>
        </div>
    <div class="main clearfix">
				<nav id="menu1" class="nav3">					
					<ul>
                         <li>
							<asp:HyperLink runat="server" ID="ComandosVozAdministrador"  Visible="false" href="../IOT/ComandosAdmin.aspx">
								<span class="icon"> 
									<i class="fas fa-microphone-alt"></i>
								</span>
								<span><b>Comandos de voz Administrador</b></span>
							</asp:HyperLink>
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="ComandosVoz"  Visible="false" href="../IOT/Comandos.aspx">
								<span class="icon"> 
									<i class="fas fa-microphone"></i>
								</span>
								<span><b>Comandos de voz</b></span>
							</asp:HyperLink>
						</li>
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
							<asp:HyperLink runat="server" ID="Monitoreo"  Visible="false" href="../IOT/Monitoreo.aspx">
								<span class="icon"> 
									<i class="fas fa-desktop"></i>
								</span>
								<span><b>Monitoreo de aplicaciones web</b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="TelegramMonitoreo"  Visible="false" href="../IOT/MonitoreoUsuario.aspx">
								<span class="icon"> 
									<i class="fas fa-desktop"></i>
								</span>
								<span><b>Monitoreo de aplicaciones web</b></span>
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
                         <li>
							<asp:HyperLink runat="server" ID="HabilitaDispoUser"  Visible="false" href="../IOT/HabilitaDispoUser.aspx">
								<span class="icon">
									<i class="fas fa-ban"></i>
								</span>
								<span><b>Habilita o deshabilita dispositivos</b></span>
							</asp:HyperLink>
						</li>  
                         <li>
							<asp:HyperLink runat="server" ID="HabilitaCAMUser"  Visible="false" href="../IOT/HabilitaCAMUser.aspx">
								<span class="icon">
									<i class="fas fa-video"></i>
								</span>
								<span><b>Habilita o deshabilita camaras</b></span>
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
                        </ul>
                    </nav>
                    </div>
    <br /><br />
    <div class="main clearfix">
				<nav id="menu4" class="nav1">					
					<ul>
                        <li>
							<asp:HyperLink runat="server" ID="Umbrales"  Visible="false" href="../IOT/UmbralesTemperatura.aspx">
								<span class="icon">
									<i class="fas fa-thermometer-full"></i>
								</span>
								<span><b>Umbrales Temperatura</b></span>
							</asp:HyperLink>
						</li> 
                       <li>
							<asp:HyperLink runat="server" ID="ReglaSensorTemperatura"  Visible="false" href="../IOT/ReglaSensorT.aspx">
								<span class="icon">
									<i class="fas fa-beer"></i>
								</span>
								<span><b>Reglas de temperatura</b></span>
							</asp:HyperLink>
						</li>
                        <li>
							<asp:HyperLink runat="server" ID="HuellaEmpleados"  Visible="false" href="../IOT/HuellaEmpleados.aspx">
								<span class="icon">
									<i class="fas fa-user-lock"></i>
								</span>
								<span><b>Administrar empleados</b></span>
							</asp:HyperLink>
						</li>  
                        <li>
							<asp:HyperLink runat="server" ID="AltaRFID" Visible="false" href="../IOT/AltaRFID.aspx">
								<span class="icon">
									<i class="fas fa-id-card"></i>
								</span>
								<span><b>Alta de RFID</b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="AsignarRFID" Visible="false" href="../IOT/AsignarRFID.aspx">
								<span class="icon">
									<i class="fas fa-id-card-alt"></i>
								</span>
								<span><b>Asignar RFID</b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="BitacoraRFID" Visible="false" href="../IOT/BitacoraRFID.aspx">
								<span class="icon">
									<i class="fas fa-atlas"></i>
								</span>
								<span><b>Bitacora de Acceso</b></span>
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
				<nav id="menu2" class="nav2">					
					<ul>
                        <li>
							<asp:HyperLink runat="server" ID="Clientes"  Visible="false" href="../IOT/Clientes.aspx">
								<span class="icon">
									<i class="fas fa-users"></i>
								</span>
								<span><b>Clientes</b></span>
							</asp:HyperLink>
                            
						</li>
						<li>
							<asp:HyperLink runat="server" ID="UsuarioCliente"  Visible="false" href="../IOT/usuariocliente.aspx">
								<span class="icon">
									<i class="fas fa-folder-open"></i>
								</span>
								<span><b>Usuarios Cliente</b></span>
							</asp:HyperLink>
						</li>  
						<li>
							<asp:HyperLink runat="server" ID="RolCliente"  Visible="false" href="../IOT/PermisoRisc.aspx">
								<span class="icon">
									<i class="fas fa-lock"></i>
								</span>
								<span><b>Rol Cliente</b></span>
							</asp:HyperLink>
                            
						</li>
						<li>
							<asp:HyperLink runat="server" ID="ConfigurarPlanos"  Visible="false" href="../IOT/ControlMulti.aspx">
								<span class="icon"> 
									<i class="fas fa-map"></i>
								</span>
								<span><b>Configurar  Planos</b></span>
							</asp:HyperLink>
						</li>
						 <li>
							<asp:HyperLink runat="server" ID="SubirPlanos"  Visible="false" href="../IOT/SubirImgPlano.aspx">
								<span class="icon">
									<i class="far fa-images"></i>
								</span>
								<span><b>Subir Planos</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server" ID="Sitios"  Visible="false" href="../IOT/Sitios.aspx">
								<span class="icon">
									<i class="fas fa-home"></i>
								</span>
								<span><b>Sitios</b></span>
							</asp:HyperLink>
						</li>
						       <li>
							<asp:HyperLink runat="server" ID="DARS"  Visible="false" href="../IOT/Dars.aspx">
								<span class="icon"> 
									<i class="fas fa-barcode"></i>
								</span>
								<span><b>DARS</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server" ID="Modelos"  Visible="false" href="../IOT/Modelos.aspx">
								<span class="icon">
									<i class="fas fa-tablet-alt"></i>
								</span>
								<span><b>Modelos</b></span>
							</asp:HyperLink>
						</li>       
						<li>
							<asp:HyperLink runat="server" ID="Eventos"  Visible="false" href="../IOT/Eventos.aspx">
								<span class="icon">
									<i class="fas fa-calendar-alt"></i>
								</span>
								<span><b>Eventos</b></span>
							</asp:HyperLink>
						</li>
                         <li>
							<asp:HyperLink runat="server" ID="Fabricantes"  Visible="false" href="../IOT/Fabricantes.aspx">
								<span class="icon">
									<i class="fas fa-industry"></i>
								</span>
								<span><b>Fabricantes</b></span>
							</asp:HyperLink>
						</li>  
					</ul>
				</nav>
			</div>
    <br />
     <div class="main clearfix">
				<nav id="menu3" class="nav2">					
					<ul>
                        <li>
							<asp:HyperLink runat="server" ID="Niveles"  Visible="false" href="../IOT/Nivelees.aspx">
								<span class="icon">
									<i class="fas fa-building"></i>
								</span>
								<span><b>Niveles</b></span>
							</asp:HyperLink>
						</li>
						<li>
							<asp:HyperLink runat="server" ID="ReglasNegocio"  Visible="false" href="../IOT/Drools.aspx">
								<span class="icon">
									<i class="fas fa-pencil-ruler"></i>
								</span>
								<span><b>Reglas de negocio</b></span>
							</asp:HyperLink>
						</li>  
						<li>
							<asp:HyperLink runat="server" ID="AgregarCatalogo"  Visible="false" href="../IOT/AgregarPermi.aspx">
								<span class="icon">
									<i class="fas fa-bars"></i>
								</span>
								<span><b>Agregar cátalogos</b></span>
							</asp:HyperLink>
						</li> 
                        <li>
							<asp:HyperLink runat="server" ID="HabilitarDispo"  Visible="false" href="../IOT/HabilitaDisp.aspx">
								<span class="icon">
									<i class="fas fa-ban"></i>
								</span>
								<span><b>Habilita o deshabilita dispositivos</b></span>
							</asp:HyperLink>
						</li>  
                         <li>
							<asp:HyperLink runat="server" ID="HabilitaCAM"  Visible="false" href="../IOT/HabilitaCAM.aspx">
								<span class="icon">
									<i class="fas fa-video"></i>
								</span>
								<span><b>Habilita o deshabilita camaras</b></span>
							</asp:HyperLink>
						</li>  
                        <li>
							<asp:HyperLink runat="server" ID="BitacorasUsuarios"  Visible="false" href="../IOT/BitacorasUsuarios.aspx">
								<span class="icon">
									<i class="fab fa-readme"></i>
								</span>
								<span><b>Bitacoras</b></span>
							</asp:HyperLink>
						</li>   
                        <li>
							<asp:HyperLink runat="server" ID="Asistente" href="../IOT/AsistenteVoz.aspx">
								<span class="icon">
									<i class="fas fa-bullhorn"></i>
								</span>
								<span><b>Asistente Voz</b></span>
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