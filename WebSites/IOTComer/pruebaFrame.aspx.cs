using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pruebaFrame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string url = string.Empty;
        url = "https://risc-iot.ddns.net:4049/";
        //url = "https://www.google.com.mx";
        Frame1.Attributes.Add("src",url);
    }
}