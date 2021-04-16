using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
public partial class IFTTTService : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string riscei = string.Empty, accion = string.Empty, nuevo= string.Empty, envio = string.Empty, aux = string.Empty;

        riscei = Request["lust"];
        accion = Request["dh"];
        //accion = Request["accion"];
        riscei = Encrypt.Desencriptar(riscei);
        accion = Encrypt.Desencriptar(accion);
        //Response.Write(riscei+accion);
        envio = returnUrl(riscei, accion);
        makerequest(envio);
    }

    protected void makerequest(string url)
    {
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create(url);
        Peticion.GetResponseAsync();
    }

    protected string returnUrl(string riscei, string accion)
    {
        string url = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.NOIP from Sitios s inner join UbiDis u on u.Cl_Sitio = s.ID " +
            "inner join DARS d on d.UbiDis = u.ID where d.RISCEI = @riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            url = "https://addar.mx/Especiales/peticion2.php?v1=" + Convert.ToString(dr[0]) + "&v2=" + riscei + "&v3=" + accion;
        }
        con.Close();
        return url;
    }
}