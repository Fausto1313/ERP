<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Promocional.aspx.cs" Inherits="Promocional" %>


<!<html lang="en">
<head>
    <title>Internet de las Cosas</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/recursos/risc.ico" rel="shortcut icon" type="image/x-icon" />


</head>
<body>
    <div class="container body-content">
        <div class="general">
        <div class="let">
            <h2>Internet de las Cosas</h2>
         </div>
         <div class="aviso">
           

            <p>Convertimos en digital cualquier cosa, utilizando códigos, metodologías y certificaciones de RISC; creando soluciones inteligentes,útilesy no
                invasivas, con la autonomía necesaria para trabajar de forma independiente, administradas por una plataforma con soporte, por cualquier medio,
                a cualquier lugar, sobre todo, ¡Sorprendentemente económico, útil, efectivo y sencillo!
        
       </p>
        <p style="text-align:center"><b>Nuestros Contactos</b></p>

        <p>evelynpineda@risc.com.mx</p>
            <p>Tels: (55) 55432915, 55432985 ext. 102,121,124</p>
            <p>Yosemite #35 Col, Nápoles
            Alc.Benito Júarez, CDMX C.P 03810</p>
              <p style="text-align:center"><b>Visitanos en:  </b>
                  <asp:HyperLink runat="server" NavigateUrl="http://risc.com.mx/"> www.risc.com.mx</asp:HyperLink>
              </p>
             
        </div>
        <br />
            </div>

        <style type="text/css">

            .aviso {
                text-align: justify;
                width: 400px;
                height: 500px;
                color:white;
            }

            .titulo {
                text-align: center;
                color: dodgerblue;
            }

                .titulo > span {
                    vertical-align: middle;
                    font-size: 40px;
                }
            .general {
               background: url("../recursos/iotew.jpeg")no-repeat;
               width:400px;
              
            }
            .Boton {
                text-align: center;
            }
            .let{
                text-align:center;
                color:#BE8D09;
                 width: 350px;
                height: 75px;
            }
        </style>
    </div>
</body>
</html>
