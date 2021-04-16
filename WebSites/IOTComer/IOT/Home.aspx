<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog2.master" CodeFile="Home.aspx.cs" Inherits="IOT_Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.1.0/css/all.css" />
    <link rel="stylesheet" href="../Content/component_barNav.css" type="text/css" media="screen"/>
    <script src="../Scripts/Script_barNav.js"></script>
    <script src="../Scripts/modernizr.custom_barNav.js"></script>

   <div class="MiLabel">
     <a href="Home.aspx" runat="server" >
       <img src="../iconos/risc.jpeg" style="max-width:100%;width:50px;height:50px;"/>
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
<!-- MENU PRINCIPAL -->
                <div  class="main clearfix">
				<nav id="menu" class="nav4">					
					<ul>
						<li <%--style="margin-left:152px--%>">
							<a href="../IOT/Bitacoras.aspx">
								<span class="icon">
                                    <i class="fab fa-readme"></i>
								</span>
								<span><b>Bitácora</b></span>
							</a>
                            
						</li>
						<li <%--style="margin-left:146px"--%>>
							<a href="../IOT/CatalogosGeneral.aspx">
								<span class="icon"> 
									<i class="fas fa-book"></i>
								</span>
								<span><b>Catálogos</b></span>
							</a>
						</li>
                        <li  <%--style="margin-left:145px"--%>>
							<asp:HyperLink runat="server" ID="mapas" href="../IOT/ControlMultiCliente.aspx">
								<span class="icon"> 
									<i class="fas fa-map"></i>
								</span>
								<span><b>Planos</b></span>
							</asp:HyperLink>
						</li>
                        <li  <%--style="margin-left:145px"--%>>
							<asp:HyperLink runat="server" ID="mapas2" Visible="false">
								<span class="icon"> 
									<i class="fas fa-map"></i>
								</span>
								<span><b>Planos</b></span>
							</asp:HyperLink>
						</li>
                        <li  <%--style="margin-left:145px"--%>>
							<asp:HyperLink runat="server" ID="Publicidad" href="../IOT/Publicidad.aspx">
								<span class="icon"> 
									<i class="fas fa-handshake"></i>
								</span>
								<span><b>Publicidad</b></span>
							</asp:HyperLink>
						</li>
                    </ul>
                </nav>
                </div>


<!-- FIN MENU -->




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



   </style>
    
</asp:Content>