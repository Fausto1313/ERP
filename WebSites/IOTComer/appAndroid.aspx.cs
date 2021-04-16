using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appAndroid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String riscei = null, evento = null, noip=null;
        noip = Request["v1"];
        riscei = Request["v2"];
        evento = Request["v3"];
        irServicio(noip, riscei, evento);
        log(noip,riscei,evento);
    }

    protected void irServicio(String ip, string dispo, string ac)
    {
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("http://localhost:8082/peticionAndroid.php?v1=" + ip + "&v2=" + dispo + "&v3=" + ac);
        Peticion.GetResponseAsync();
        Response.Write("true");
    }

    protected void log(string a, string b, string c){
        System.IO.StreamWriter sw = new System.IO.StreamWriter("C:/Pruebas/pruebaPeticiones.txt");
            sw.WriteLine(a);
            sw.WriteLine(b);
            sw.WriteLine(c);
            sw.WriteLine("Si estoy procesando");
            sw.Close();
    }
}