<%@ Page Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="pruebamenu.aspx.cs" Inherits="pruebamenu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">

<title>Menu Desplegable</title>
		<style type="text/css">
			
			* {
				margin:0px;
				padding:0px;
			}
			
			#header {
				margin:auto;
				width:500px;
				font-family:Arial, Helvetica, sans-serif;
			}
			
			ul, ol {
				list-style:none;
			}
			
			.nav > li {
				float:left;
			}
			
			.nav li a {
				background-color:#74A4D6;
				color:#fff;	
				text-decoration:none;
				padding:10px 12px;
				display:block;
			}
			
			.nav li a:hover {
				background-color:#434343;
			}
			
			.nav li ul {
				display:none;
				position:absolute;
				min-width:140px;
			}
			
			.nav li:hover > ul {
				display:block;
			}
			
			.nav li ul li {
				position:relative;
			}
			
			.nav li ul li ul {
				right:-140px;
				top:0px;
			}
			
          		html, body{
  height: 100%;
  background-color: #FFFFFF;
}

#uno{ border:1px solid black;
	width:49.5%;
	display:inline-block;
	margin:auto;
	height:49.5%;
	background-color:blue;
	}
#dos{ border:1px solid black;
	width:49.5%;
	display:inline-block;
	height:49.5%;
	background-color:green;
	}
#tres{ border:1px solid black;
	width:100%;
	display:inline-block;
	height:49.5%;
	background-color:white;
	}

	
	
		</style>
	</head>
	<body>
		<div id="header">
			<ul class="nav">
              
					<li><a href="">Administracion de Empleados</a>
						<ul>
							<li><a href="">Empleados</a></li>
							<li><a	 href="">Usuarios RFID</a></li>
							<li><a href="">Permisos RFID</a></li>
							<li><a href="">Bitacora RFID</a>
								
							</li>
						</ul>
					</li>
					<li><a href="">Dispositivos</a>
						<ul>
							<li><a href="">Dars </a></li>
							<li><a href="">Modelos</a></li>
							<li><a href="">Eventos</a></li>
							<li><a href="">Fabricantes</a></li>
                          <li><a href="">Bitacoras</a></li>
                          <li><a href="">Asistente de Voz</a></li>
						</ul>
					</li>
					<li><a href="">Telegram</a>
                  <ul>
							<li><a href="">Cliente-Usuario </a> </li>
							<li><a href="">Usuarios</a></li>
							<li><a href="">Canales</a></li>
							<li><a href="">Empleados</a></li>
                          <li><a href=""></a></li>
                          <li><a href=""></a></li>
						</ul>
                  </li>
                  
				</ul>
			
		</div>
	
  <div class='recuadro' id="uno">
		
		<iframe id="inlineFrameExample1"
    title="Inline Frame Example"
    width="660"
    height="300"
    src="http://risc.com.mx/">
			</iframe>
	
  </div>
	<div class='recuadro' id="dos" >
		<iframe id="inlineFrameExample2"
    title="Inline Frame Example"
    width="660"
    height="300"
    src="https://www.openstreetmap.org/export/embed.html?bbox=-0.004017949104309083%2C51.47612752641776%2C0.00030577182769775396%2C51.478569861898606&layer=mapnik">
			</iframe></div>
	<br>
	<div class='recuadro' id="tres">
		<iframe id="inlineFrameExample3"
    title="Inline Frame Example"
    width="660"
    height="300"
    src="https://www.openstreetmap.org/export/embed.html?bbox=-0.004017949104309083%2C51.47612752641776%2C0.00030577182769775396%2C51.478569861898606&layer=mapnik">
			</iframe></div>
	
  
 
	</body>


</asp:Content>