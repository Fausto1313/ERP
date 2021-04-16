<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLogMapas.master" AutoEventWireup="true" CodeFile="ControlMulti.aspx.cs" Inherits="IOT_ControlMulti" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" Runat="Server">
      <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/solid.css" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/regular.css"/>
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/brands.css" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/fontawesome.css" /> 
        <link href="../Content/Encimar_Combo_a_Imagen.css" rel="stylesheet" media="screen"/>
        <script type="text/javascript" src="../Scripts/jquery-1.5.js"></script>
        <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jqueryui/1.8.7/jquery-ui.js"></script>

  <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat; position:absolute; left:150px; top:75px; width:1096px;">
  <div class="container-fluid" >
      
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand"  style="color:azure">Panel de Control</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li>
        </li>       
        </ul>
        <div id="Tabs" role="tabpanel">
        <ul class="nav nav-tabs ">
        <li>
        <div style="position:static">
                <asp:Label runat="server"  Text="Cliente" CssClass="MiLabel"/> 
                <asp:DropDownList ID="Clientes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ClienteSelecionado"></asp:DropDownList>
                <asp:Label runat="server"  Text="Sitios" CssClass="MiLabel"/> 
                <asp:DropDownList ID="Sitios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SitioSeleccionado"></asp:DropDownList>
                <asp:Label runat="server"  Text="Nivel" CssClass="MiLabel"/> 
                <asp:DropDownList  runat="server" ID="Nivel1" AutoPostBack="True" OnSelectedIndexChanged="NivelSeleccionado"></asp:DropDownList>
                <asp:Label runat="server" />
                <asp:LinkButton ID="btnRandom" runat="server" OnClick="Buscar" CssClass="btn btn-primary">
                <span aria-hidden="true" class="glyphicon glyphicon-search"></span>  Buscar
                </asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Guardar" CssClass="btn btn-success">
                <span aria-hidden="true" class="far fa-save"></span>  Guardar
                </asp:LinkButton>
                <a class="btn btn-danger" href="Configuraciones.aspx" runat="server">Volver</a>   
        </div>                         
        </li>
</ul><!-- end of nav -->      
      </div>       
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
    <br /><br /><br /><br />
      <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>            
              <div class="image_wrapper" id="img1">
                   <img  class="image" src="data:image/jpg;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem, "imagen"))%>"/> 
                </div>
            </ItemTemplate>
     </asp:Repeater>
    <div class="titulo">
        <h3>Dispositivos a Configurar</h3>
    </div>
      
     <style type="text/css">
        
         .titulo{
            width: 130px; 
            height: 100px; 
            background:#061D35;
            position:absolute; 
            text-align:center;
            color:#eee;
         
            left:10px; 
            top:75px;
        }
         .menu{
            width: 130px; 
            height: 600px; 
            background:#061D35;
            position:absolute; 
            text-align:center;
            color:#eee;
         
            left:10px; 
            top:176px;
        }
       .menu .caja{
           width:100%;
           margin-left:0px;
           margin-top:4px;
           padding:10px;
         }
       
       .menu ul {
          list-style: none;
       }
       .menu  li{
           display: block;
       }

          .MiLabel
        {
        text-align:center;
        color: #fff;
        font-family: Arial; 
        font-size:15px; 
        font-weight:normal;
    
        }
    </style>
</asp:Content>