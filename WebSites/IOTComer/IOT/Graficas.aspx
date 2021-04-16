<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog2.master" CodeFile="Graficas.aspx.cs" Inherits="IOT_Graficas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css"/>
    <link rel="stylesheet" href="../Content/component_barNav.css" type="text/css" media="screen"/>
    <script src="../Scripts/Script_barNav.js"></script>
    <script src="../Scripts/modernizr.custom_barNav.js"></script>
         
    <div class="alert alert-info" role="alert">
        Vínculo con aplicación Qlik
    </div>
     <hr />      
   <div class="main clearfix">
				<nav id="menu" class="nav6">					
					<ul>
						<li>
							<a href="../IOT/Voltaje.aspx">
								<span class="icon">
									<i class="fas fa-chart-line"></i>
								</span>
								<span><b>Voltaje</b></span>
							</a>
                            
						</li>
						<li>
							<a href="../IOT/RH.aspx">
								<span class="icon"> 
									<i class="fas fa-chart-pie"></i>
								</span>
								<span><b>Recursos Humanos</b></span>
							</a>
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
  <br/>
  <div>
        <a class="btn btn-danger" href="Bitacoras.aspx" runat="server" role="button">Volver</a>
    </div>
     
</asp:Content>