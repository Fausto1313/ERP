using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_PruebasTelegram : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Accion_Click(object sender, EventArgs e)
    {
        string token = "465931710:AAHAY4-x6ZozrHPWkLfy9t7UUrcJX6Q61bw";
        string mensaje = "Testeo de telegram";

        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://api.telegram.org/bot" + token + "/sendMessage?chat_id=675930577&text=" + Telegram.Text);
        Peticion.GetResponse();
    }
}