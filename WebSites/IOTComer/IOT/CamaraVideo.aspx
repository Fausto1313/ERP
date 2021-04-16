<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog2.master" AutoEventWireup="true" CodeFile="CamaraVideo.aspx.cs" Inherits="IOT_CamaraVideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent2" Runat="Server">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css"/>
    <link rel="stylesheet" href="../Content/component_barNav.css" type="text/css" media="screen"/>
    <script src="../Scripts/Script_barNav.js"></script>
    <script src="../Scripts/modernizr.custom_barNav.js"></script>
    <div class="alert alert-info" role="alert">
        Vínculo con aplicaciones para cámara
    </div>
     <hr /> 
    <div  class="main clearfix">
	    <nav id="menu" class="nav6">					
		    <ul>
                <li>
			        <a href="../IOT/VideoVivo.aspx">
				        <span class="icon"> 
					        <i class="fas fa-eye"></i>
						</span>
					    <span><b>En Vivo</b></span>
				    </a>
			    </li>
                <li>
				    <a href="../IOT/VideosAlmacenados.aspx">
					    <span class="icon">
                            <i class="fa fa-video"></i>
						</span>
					    <span><b>Videos Almacenados</b></span>
					</a>
                 </li>
		    </ul>
        </nav>
    </div>
    <div>
        <br />
                  <a class="btn btn-danger" href="CatalogoSeguridad.aspx" runat="server" role="button">Volver</a>
                </div>
    <hr />
</asp:Content>


