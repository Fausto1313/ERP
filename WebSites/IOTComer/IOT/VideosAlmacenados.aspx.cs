using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_VideosAlmacenados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        string usuario = User.Identity.Name;
        int pantalla = 43;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Camara")
        {
            String ip = " https://risc-open.ddns.net:4049/";

            frame.Src = ip;
            //myIp.Text = ip;
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
  
    }
}