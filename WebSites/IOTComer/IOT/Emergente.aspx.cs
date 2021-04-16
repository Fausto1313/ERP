using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI;
using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
public partial class IOT_Emergente : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e)
    {

        mostrarDarsConfigurados();

    }

    protected void mostrarDarsConfigurados()
    {
        string json = null;
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("http://localhost:49436/mapService?funcion=3a&nivel1=" + 8397);
        Stream recibido;
        recibido = Peticion.GetResponse().GetResponseStream();
        StreamReader json1 = new StreamReader(recibido);
        json = json1.ReadToEnd();

        RootObject dar = JsonConvert.DeserializeObject<RootObject>(json);
        RootObject obj = new RootObject();
        Response.Write("<script src=//code.jquery.com/jquery-1.5.js></script>");

        foreach (var dev in dar.devices)
        {
            string variable = string.Empty;
            if (dev.estatus == "Configurado")
            {
                Response.Write(dev.html + dev.css + dev.js);

            }
        }

    }
    public class Device
    {
        public string riscei { get; set; }
        public string html { get; set; }
        public string css { get; set; }
        public string js { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public string estatus { get; set; }
        public string estado { get; set; }
    }

    public class RootObject
    {
        public string imagen { get; set; }
        public List<Device> devices { get; set; }
    }

    // Metodo que actualiza el HTML para que regrese los dispositivos si estan activados 
    protected void htmlCheck(string RISCEI)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string html = null;

        SqlCommand cmd = new SqlCommand("select d.Descripcion, i.icono from dars d, (select SUBSTRING(RISCEI,5,2) as a1 from DARS where RISCEI = @riscei) AS a2, iconos i where d.RISCEI = @riscei and i.Modelo = a2.a1 ", con);
        cmd.Parameters.AddWithValue("@riscei", RISCEI);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string descripcion = null, icono = null;
            descripcion = Convert.ToString(dr[0]);
            icono = Convert.ToString(dr[1]);
            string conString1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();
            html = "<div class=\"context-menu-one\">" +
                   "<input type='checkbox' id='R" + RISCEI + "' checked='checked' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "' style='display:none;'/>" +
                   "<label for='R" + RISCEI + "' id='F" + RISCEI + "' class='" + icono + "' title='" + descripcion + "'></label>" +
                   "</div>";
            string updateCliCmd = "UPDATE ScriptsCliente SET htmlcli=@html WHERE idscriptcli=@riscei";
            SqlCommand cmd2 = new SqlCommand(updateCliCmd, con1);
            cmd2.Parameters.AddWithValue("@html", html);
            cmd2.Parameters.AddWithValue("@riscei", RISCEI);
            cmd2.ExecuteNonQuery();
            con1.Close();
        }
        con.Close();

    }

    // Metodo que actualiza el HTML para que regrese los dispositivos si estan apagados
    protected void htmlNOCheck(string RISCEI)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string html = null;

        SqlCommand cmd = new SqlCommand("select d.Descripcion, i.icono from dars d, (select SUBSTRING(RISCEI,5,2) as a1 from DARS where RISCEI = @riscei) AS a2, iconos i where d.RISCEI = @riscei and i.Modelo = a2.a1 ", con);
        cmd.Parameters.AddWithValue("@riscei", RISCEI);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            string descripcion = null, icono = null;
            descripcion = Convert.ToString(dr[0]);
            icono = Convert.ToString(dr[1]);
            string conString1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();
            html = "<div class=\"context-menu-one\">" +
                   "<input type='checkbox' id='R" + RISCEI + "' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "' style='display:none;'/>" +
                   "<label for='R" + RISCEI + "' id='F" + RISCEI + "' class='" + icono + "' title='" + descripcion + "'></label>" +
                   "</div>";
            string updateCliCmd = "UPDATE ScriptsCliente SET htmlcli=@html WHERE idscriptcli=@riscei";
            SqlCommand cmd2 = new SqlCommand(updateCliCmd, con1);
            cmd2.Parameters.AddWithValue("@html", html);
            cmd2.Parameters.AddWithValue("@riscei", RISCEI);
            cmd2.ExecuteNonQuery();
            con1.Close();
        }
        con.Close();

    }


}