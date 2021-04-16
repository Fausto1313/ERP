using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class IOT_MapaRastreo : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
       
            string usuario = User.Identity.Name;
            int pantalla = 34;
            Permisos permiso = new Permisos();

            if (permiso.returnPermiso(usuario, pantalla) != "Rastreo Satelital")
            {
                Response.Redirect("~/IOT/Home");
            }
        

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        string url = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select latitud, longitud from coordenadas where RISCEI='1805GP2070'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            url = "http://addar.mx:8082/mapa3.html?lat=" + dr[0] + "&long="+dr[1];
        }
        con.Close();
        Frame1.Attributes.Add("src",url);
    }
}