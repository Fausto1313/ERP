using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pruebaDAR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Prueba_Click(object sender, EventArgs e)
    {
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("http://risc-open.ddns.net:4040/rest.php?riscei=1710LE2000&evento=ON");
        Peticion.GetResponseAsync();
    }

    protected void Prueba2_Click(object sender, EventArgs e)
    {
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("http://risc-open.ddns.net:4040/rest.php?riscei=1710LE2000&evento=OFF");
        Peticion.GetResponseAsync();
    }
}