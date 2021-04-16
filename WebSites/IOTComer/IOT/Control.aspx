<%@ Page Title="" Language="C#" MasterPageFile="~/IOT/SiteLog.master" AutoEventWireup="true" CodeFile="Control.aspx.cs" Inherits="IOT_Control" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" Runat="Server">
    <nav class="navbar navbar-inverse" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
  <div class="container-fluid">
    <!-- Brand and toggle get grouped for better mobile display -->
    <div class="navbar-header">
      <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
        <span class="sr-only">Toggle navigation</span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#" style="color:azure">Panel de Control</a>
    </div>

    <!-- Collect the nav links, forms, and other content for toggling -->
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <ul class="nav navbar-nav">
        <li><!--Inicio de ]Modal

            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">
  Cliente Nuevo
</button>

            fin de modal-->
        </li>
        
      </ul>
       <div id="Tabs" role="tabpanel">
<ul class="nav nav-tabs ">
  <!--li class="active"><a href="#tab_a" data-toggle="tab">Tab A</a></!--li>
  <li><a href="#tab_b" data-toggle="tab">Tab B</a></li>
  <li><a href="#tab_c" data-toggle="tab">Tab C</a></li>-->
  <li class="dropdown">
    <a class="dropdown-toggle" data-toggle="dropdown" href="#">Planta Baja<span class="caret"></span></a>
    <ul class="dropdown-menu">
        <li><a href="#tab_d1" data-toggle="tab">Luces</a></li>
	    <li><a href="#tab_d2" data-toggle="tab">ventilador HW</a></li>
        <li><a href="#Entrada" data-toggle="tab">Vestibulo</a></li>
    </ul><!-- end of dropdown menu -->
  </li>

    
</ul><!-- end of nav -->
       
      </div>
        
    </div><!-- /.navbar-collapse -->
  </div><!-- /.container-fluid -->
</nav>
<div class="tab-content">
       <!-- <div class="tab-pane active" id="tab_a">
            <h4>Pane A</h4>
            <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames
                ac turpis egestas.</p>
        </div>
        <div class="tab-pane" id="tab_b">
            <h4>Pane B</h4>
            <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames
                ac turpis egestas.</p>
        </div>
        <div class="tab-pane" id="tab_c">
            <h4>Pane C</h4>
            <p>Pellentesque habitant morbi tristique senectus et netus et malesuada fames
                ac turpis egestas.</p>
        </div>-->
        <div class="tab-pane active" id="tab_d1">
             <h4  style="text-align:center; color:azure" >Sala de Capacitación</h4>                
              <p class="text-center"> Luces LED</p>
                <div style="text-align:center">   
                   <asp:Image ID="LEDON" runat="server" ImageUrl="~/iconos/green.png" Visible="false" />                            
                   <asp:Image ID="LEDOFF" runat="server" ImageUrl="~/iconos/red.png" Visible="false"  /> 
                <div class="btn-group" role="group"  style='padding-left: 3em' >                   
                   <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="on" onclick="Button1_Click" />  
                   <asp:Button ID="Button2" runat="server" CssClass="btn btn-default" Text="Off" onclick="Button2_Click"  />                  
                </div>
                </div>
              <br /><br />
               
        <p class="text-center">Luces Sala Capacitacion</p>
           <div style="text-align:center" >  
                 <asp:Image ID="LUZON" runat="server" ImageUrl="~/iconos/focoOn.png" Visible="false" />
                 <asp:Image ID="LUZOFF" runat="server" ImageUrl="~/iconos/focoOFF.png" Visible="false" />
              <div class="btn-group" role="group" style='padding-left: 3em'>
                  <asp:Button  ID="Button3" runat="server" CssClass="btn btn-success" Text="On" onclick="Button3_Click" />
                  <asp:Button ID="Button4" runat="server" CssClass="btn btn-default" Text="Off" onclick="Button4_Click" />
              </div>           
           </div>
        <br /><br />                
         
        <p class="text-center">Ventilador</p>
            <div style="text-align:center"> 
                 <asp:Image ID="VENTION" runat="server" ImageUrl="~/iconos/ventiON.png" Visible="false" />
            <asp:Image ID="VENTIOFF" runat="server" ImageUrl="~/iconos/ventiOFF.png" Visible="false" />
               <div class="btn-group" role="group" style='padding-left: 3em'>
                  <asp:Button  ID="Button5" runat="server" CssClass="btn btn-success" Text="On" onclick="Button5_Click" />
                  <asp:Button ID="Button6" runat="server" CssClass="btn btn-default" Text="Off" onclick="Button6_Click" />
               </div>           
            </div>
        
        </div>


        <div class="tab-pane" id="tab_d2">
             <p class="text-center"> Encender</p>
    
      <div style="text-align:center">   
                   <asp:Image ID="Image1" runat="server" ImageUrl="~/iconos/green.png" Visible="false" />                            
                   <asp:Image ID="Image2" runat="server" ImageUrl="~/iconos/red.png" Visible="false"  /> 
          <div class="btn-group" role="group"  style='padding-left: 3em' >                   
                   <asp:Button ID="Button10" runat="server" CssClass="btn btn-success "  Text="Encender" onclick="Button11_Click" />  
                                
          </div>
     </div>
      <br /><br />
      <p class="text-center"> Oscilar</p>
    
      <div style="text-align:center">   
                   <asp:Image ID="Image3" runat="server" ImageUrl="~/iconos/green.png" Visible="false" />                            
                   <asp:Image ID="Image4" runat="server" ImageUrl="~/iconos/red.png" Visible="false"  /> 
          <div class="btn-group" role="group"  style='padding-left: 3em' >                   
                   <asp:Button ID="Button12" runat="server" CssClass="btn btn-success" Text="Oscilar" onclick="Button12_Click" />  
                                 
          </div>
     </div>
      <br /><br />
      <p class="text-center"> Tiempo</p>
    
      <div style="text-align:center">   
                   <asp:Image ID="Image5" runat="server" ImageUrl="~/iconos/green.png" Visible="false" />                            
                   <asp:Image ID="Image6" runat="server" ImageUrl="~/iconos/red.png" Visible="false"  /> 
          <div class="btn-group" role="group"  style='padding-left: 3em' >                   
                   <asp:Button ID="Button14" runat="server" CssClass="btn btn-success" Text="Tiempo" onclick="Button13_Click" />  
                                   
          </div>
     </div>
      <br /><br />
      <p class="text-center"> Frio</p>
    
      <div style="text-align:center">   
                   <asp:Image ID="Image7" runat="server" ImageUrl="~/iconos/green.png" Visible="false" />                            
                   <asp:Image ID="Image8" runat="server" ImageUrl="~/iconos/red.png" Visible="false"  /> 
          <div class="btn-group" role="group"  style='padding-left: 3em' >                   
                   <asp:Button ID="Button16" runat="server" CssClass="btn btn-success" Text="Frio" onclick="Button14_Click" />  
                                
          </div>
     </div>
      <br /><br />
      <p class="text-center"> Dormir</p>
    
      <div style="text-align:center">   
                   <asp:Image ID="Image9" runat="server" ImageUrl="~/iconos/green.png" Visible="false" />                            
                   <asp:Image ID="Image10" runat="server" ImageUrl="~/iconos/red.png" Visible="false"  /> 
          <div class="btn-group" role="group"  style='padding-left: 3em' >                   
                   <asp:Button ID="Button18" runat="server" CssClass="btn btn-success" Text="Dormir" onclick="Button15_Click" />  
                                   
          </div>
     </div>
        </div>
            <div class="tab-pane" id="Entrada">
                  <h3  style="text-align:center">Panel de Control</h3> 
            <p class="text-center">Puertas de acceso</p>
                <p class="text-center">Vestibulo</p>
             <div style="text-align:center">    
                
                    

                 
	
                  <asp:LinkButton  ID="Button8" runat="server" Text="<span class='glyphicon glyphicon-home'></span>" CssClass="btn btn-success btn-circle  btn-xl" nclick="Button8_Click" />
                 
                             
                
                 <p class="text-center">Entrada</p>
                   <br />
                   <div class="btn-group" role="group" aria-label="...">
                  
                  <asp:Button ID="Button9" runat="server" CssClass="btn btn-success" Text="Open" onclick="Button9_Click" />
                       
                   </div>
                 <asp:HiddenField ID="TabName" runat="server" />           
             </div> 
                </div>
</div><!-- tab content -->  
    
   <!-- <asp:Button ID="Button7" runat="server" CssClass="btn btn-default" Text="Desbloquear" onclick="Button10_Click"  />   
                <br /><br />    
     <br />
    <asp:Button ID="Button100" runat="server" CssClass="btn btn-default" Text="Encender" onclick="encenderTodos"  />   
    <asp:Button ID="Button111" runat="server" CssClass="btn btn-default" Text="Apagar" onclick="ApagarTodos"  />   
       -->
        
 
   <!-- <style>
  .toggle.ios, .toggle-on.ios, .toggle-off.ios { border-radius: 20px; }
  .toggle.ios .toggle-handle { border-radius: 20px; }
</style>-->
<!--
  <script type="text/javascript">
      $(document).ready(function () {
          $('#demo').btnSwitch({
              // iOS like button
              Theme: 'iOS',

              // on/off text
              OnText: "On",
              OffText: "Off",

              // values of on/off buttons
              OnValue: true,
              OffValue: false,

              // callbacks
              OnCallback: function () { SwitchOnFunction(); },
              OffCallback: function () { SwitchOffFunction(); },

              // hidden input's ID
              HiddenInputId: "hdnValue"
          });

          function SwitchOnFunction() {
              $("#result").text('Switch is on! Value of switch is ' + $("#hdnValue").val());
          }
          function SwitchOffFunction() {
              $("#result").text('Switch is off! Value of switch is ' + $("#hdnValue").val());
          }
      })
    </script>
   
  -->
    <!--    
    <button type="button" id="myButton" data-loading-text="Loading..." class="btn btn-primary" autocomplete="off">
  Loading state
</button>



<script>
    $('#myButton').on('click', function () {
        $(this).button('loading').delay(3000).queue(function () {
            $(this).button('reset');
            $(this).dequeue();
        });
    })
</script>
     -->



    <style>

.dropdown-submenu {
    position: static;
            
}

.dropdown-submenu>.dropdown-menu {
    top: 0;
    left: 100%;
    margin-top: -6px;
    margin-left: -1px;
    -webkit-border-radius: 0 6px 6px 6px;
    -moz-border-radius: 0 6px 6px;
    border-radius: 0 6px 6px 6px;
    
            

}

.dropdown-submenu:hover>.dropdown-menu {
    display: block;
            
}

.dropdown-submenu>a:after {
    display: block;
    content: " ";
    float: right;
    width: 0;
    height: 0;
    border-color: transparent;
    border-style: solid;
    border-width: 5px 0 5px 5px;
    border-left-color: #ccc;
    margin-top: 5px;
    margin-right: -10px;
            

}

.dropdown-submenu:hover>a:after {
    border-left-color: #fff;
            
}

.dropdown-submenu.pull-left {
    float: none;
            
}

.dropdown-submenu.pull-left>.dropdown-menu {
    left: -100%;
    margin-left: 10px;
    -webkit-border-radius: 6px 0 6px 6px;
    -moz-border-radius: 6px 0 6px 6px;
    border-radius: 6px 0 6px 6px;
            
}
     
        
    </style>


<script type="text/javascript">
    $(function () {
        var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
        $('#Tabs a[href="#' + tabName + '"]').tab('show');
        $("#Tabs a").click(function () {
            $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
        });
    });
</script>

 <!--   <h2>xl</h2>
<button type="button" class="btn btn-default btn-circle btn-xl"><i class="glyphicon glyphicon-ok"></i></button>
<button type="button" class="btn btn-primary btn-circle btn-xl"><i class="glyphicon glyphicon-list"></i></button>
<button type="button" class="btn btn-success btn-circle btn-xl"><i class="glyphicon glyphicon-link"></i></button>
<button type="button" class="btn btn-info btn-circle btn-xl"><i class="glyphicon glyphicon-ok"></i></button>
<button type="button" class="btn btn-warning btn-circle btn-xl"><i class="glyphicon glyphicon-remove"></i></button>
<button type="button" class="btn btn-danger btn-circle btn-xl"><i class="glyphicon glyphicon-heart"></i></button>
    -->
    <style>
        body{margin:40px;}



.btn-circle.btn-xl {
    
  width: 70px;
  height: 70px;
  padding: 10px 16px;
  font-size: 34px;
  line-height: 1.33;
  border-radius: 35px;
}

    </style>


    <script type="text/javascript">
        var boton = document.createElement("button");
        boton.type = "button";
        document.body.appendChild(boton);
    </script>

</asp:Content>

