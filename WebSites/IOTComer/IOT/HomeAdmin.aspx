<%@ Page Title="Página Principal" Language="C#"  AutoEventWireup="true" MasterPageFile="~/IOT/SiteLog.master" CodeFile="HomeAdmin.aspx.cs" Inherits="_Default" EnableSessionState="True"  %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent2" runat="server">
         <div class="MiLabel">
   <asp:Label ID="Label1" runat="server" 
CssClass="MiLabel"  Text="Reintegración en Servicios de Computo"></asp:Label>
    </div>
              
      <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
        <li data-target="#myCarousel" data-slide-to="3"></li>

    </ol>

    <!-- Wrapper for slides -->
     <div class="carousel-inner">
        <div class="item active">
         
             <a href="/IOT/ControlMulti.aspx"> <img src="/recursos/SalaC.Jpg" alt="Chicago" ></a>
            <div class="carousel-caption">
                 
                <div>
                
              </div>
            </div>
        </div>
  
        <div class="item">
          <a  href="/IOT/Activado.aspx"> <img src="/recursos/io1.jpg" alt="Los Angeles"  ></a>
            <div class="carousel-caption">
                
                <div>

                </div>
            </div>
        </div>
        <div class="item">
            <a > <img src="/recursos/fin2.Jpg" alt="Chicago" ></a>
        </div>
         <div class="item">
            <a  > <img src="/recursos/fin.Jpg" alt="Chicago" ></a>
        </div>
    </div>
          
    <!-- Controls -->
    <a class="left carousel-control" href="#myCarousel" data-slide="prev" >
        <span class="glyphicon glyphicon-chevron-left"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right"></span>
        <span class="sr-only">Next</span>
    </a>
</div>
<hr />
 <!--
  <style>

      .item {
      display: block;
      
      height: auto;
        width:100%;
}
      img {
   width:100%;
    
}

  </style>-->
 
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
  
<div class="container marketing">

   <!-- Three columns of text below the carousel -->
      <div class="row">
        <div class="col-xs-3 col-sm-4 col-lg-4">
         
          <!--p><a class="btn btn-default" href="#" role="button">View details &raquo;</a></p>-->
            <!--modall-->
             
                <!-- Trigger the modal with a button -->
    
                      <img src="/recursos/arduino1.jpg" class="modal-content img-responsive" width="300" height="400px" data-toggle="modal" data-target="#myModal">
                  <!-- Modal -->
                   <div class="modal fade" id="myModal" role="dialog">
                     <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                    <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Arduino Uno</h4>
                    </div>
                    <div class="modal-body">
                    <p>Arduino es una plataforma de electrónica abierta para la creación de prototipos basada en software y hardware flexibles y fáciles de usar. Se creó para artistas, diseñadores, aficionados y cualquiera interesado en crear entornos u objetos interactivos. La ventaja de los proyectos con código abierto es que hay mucha información y libre de uso.</p>
                     </div>
                    <div class="modal-footer">
                   <button type="button" class="btn btn-primary" data-dismiss="modal">Entendido</button>
                </div>
             </div>      
              </div>
             </div>
           
            <!--modall-->
        </div><!-- /.col-lg-4 -->
        <div class="col-xs-3 col-sm-4 col-lg-4">
          
            <!--modall-->
             
                <!-- Trigger the modal with a button -->
                   <img src="/recursos/arduino-yun.png" class="modal-content img-responsive" width="300" height="400" data-toggle="modal" data-target="#myModal2" />
                  <!-- Modal -->
                   <div class="modal fade" id="myModal2" role="dialog">
                     <div class="modal-dialog">
    
                    <!-- Modal content-->
                    <div class="modal-content">
                    <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Arduino Yun</h4>
                    </div>
                    <div class="modal-body">
                    <p>El Arduino YUN llega para potenciar todas aquellas tareas que demandan conectividad a Internet. Ya sea que se requiera enviar datos de un sensor a un servicio en la nube, hacer streaming de audio vía IP, controlar un robot con el celular, etc.</p>
                     </div>
                    <div class="modal-footer">
                   <button type="button" class="btn btn-primary" data-dismiss="modal">Entendido</button>
                </div>
             </div>      
              </div>
             </div>
           
            <!--modall-->
        </div><!-- /.col-lg-4 -->
        <div class="col-xs-3 col-sm-4 col-lg-4">
         
           <!--modall-->
             
                <!-- Trigger the modal with a button -->
                  <img src="/recursos/IOTD.png"  class="modal-content img-responsive" width="300" height="400" data-toggle="modal" data-target="#myModal3"/>
                  <!-- Modal -->
                   <div class="modal fade" id="myModal3" role="dialog">
                     <div class="modal-dialog">
    
                    <!-- Modal content-->
                    <div class="modal-content">
                    <div class="modal-header" style="background-image: url('/recursos/std_themelet1_style2_bg.png'); background-repeat:repeat">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Internet Of Things</h4>
                    </div>
                    <div class="modal-body" >
                    <p >El internet de las cosas (IoT, por sus siglas en inglés) es un sistema de dispositivos de computación interrelacionados, máquinas mecánicas y digitales, objetos, animales o personas que tienen identificadores únicos y la capacidad de transferir datos a través de una red, sin requerir de interacciones humano a humano o humano a computadora.</p>
                     </div>
                    <div class="modal-footer">
                   <button type="button" class="btn btn-primary" data-dismiss="modal">Entendido</button>
                </div>
             </div>      
              </div>
             </div>
           
            <!--modall-->
        </div><!-- /.col-lg-4 -->
      </div><!-- /.row -->


     </div>

   

</asp:Content>
