using System;

public partial class pruebaFecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime d = DateTime.Now;
        Response.Write(d);
    }
}