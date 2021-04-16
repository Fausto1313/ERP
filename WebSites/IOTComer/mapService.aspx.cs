using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;

public partial class mapService : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    SqlConnection con2 = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string fun = string.Empty;
        fun = Request["funcion"];
        switch (fun) {
            case "1a":
                function1();
                break;
            case "2a":
                function2();
                break;
            case "3a":
                function3();
                break;
            case "4a":
                function4();
                break;
        }
    }

    //Seccion de procesamiento de peticiones
    protected void function1() {
        string jso = string.Empty;
        int nivel = 0;
        nivel = Convert.ToInt32(Request["nivel1"]);
        json1 respuesta = new json1();
        respuesta.imagen = returnImage(nivel);
        respuesta.devices = returnDevices(nivel);
        jso = JsonConvert.SerializeObject(respuesta);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(jso);
    }

    protected void function2() {
        string riscei = string.Empty, estatus = string.Empty;
        double coorX = 0, coorY = 0;
        riscei = Request["riscei"];
        coorX = Convert.ToDouble(Request["posX"]);
        coorY = Convert.ToDouble(Request["posY"]);
        estatus = "Configurado";
        updateCoords(riscei, coorX, coorY, estatus);
    }

    protected void function3()
    {
        string jso = string.Empty;
        int nivel = 0;
        nivel = Convert.ToInt32(Request["nivel1"]);
        json1 respuesta = new json1();
        respuesta.imagen = returnImage(nivel);
        respuesta.devices = returnDevicesCliente(nivel);
        jso = JsonConvert.SerializeObject(respuesta);
        Response.ContentType = "application/json; charset=utf-8";
        Response.Write(jso);
    }

    protected void function4()
    {
        string riscei = string.Empty, estatus = string.Empty, evento = string.Empty;
       
        riscei =Request["v1"];
        estatus =Request["v2"];
        updateStatus(riscei,estatus);
    }

    protected string returnImage(int nivel1) {
        string imagen = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select imagen from ImagenesPlano where nivel1=@nivel1", con);
        cmd.Parameters.AddWithValue("@nivel1", nivel1);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            imagen = Convert.ToString(dr[0]);
        }
        con.Close();
        return imagen;

    }

    protected List<dispositivo> returnDevices(int nivel) {
        List<dispositivo> dev = new List<dispositivo>();
        con.Open();
        SqlCommand cmd = new SqlCommand("(select s.idscript, s.shtml, s.scss, s.sjs, s.posX, s.posY, s.estatus from scripts s inner join (select d.RISCEI from Dars d inner join (select ID from UbiDis where nivel1 = @nivel1) as a1 on d.UbiDis = a1.Id) as aa1 on aa1.RISCEI = s.idscript)", con);
        cmd.Parameters.AddWithValue("@nivel1", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            dispositivo d = new dispositivo();
            d.riscei = (string)dr["Idscript"];
            d.html = (string)dr["shtml"];
            d.css = (string)dr["scss"];
            d.js = (string)dr["sjs"];
            d.posX = Convert.ToInt32(dr["posX"]);
            d.posY = Convert.ToInt32(dr["posY"]);
            d.estatus = (string)dr["estatus"];
           
            dev.Add(d);

        }
        con.Close();

        return dev;
    }

    protected void updateStatus(string riscei,string estatus)
    {
        con.Open();
        string updateCmd = "update estatus set Estado = @estatus where RISCEI = @riscei";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@riscei", riscei);
        updatecmd.Parameters.AddWithValue("@estatus", estatus);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected List<dispositivo> returnDevicesCliente(int nivel)
    {
        List<dispositivo> dev = new List<dispositivo>();
        con.Open();
        SqlCommand cmd = new SqlCommand("select s.idscriptcli, s.htmlcli, s.csscli, s.jscli, s.posX, s.posY, s.estatus from ScriptsCliente s inner join (select d.RISCEI from Dars d inner join (select ID from UbiDis where nivel1 = @nivel1) as a1 on d.UbiDis = a1.Id where d.Modelo !='DAR-BIS-MP') as aa1 on aa1.RISCEI = s.idscriptcli", con);
        cmd.Parameters.AddWithValue("@nivel1", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            dispositivo d = new dispositivo();
            d.riscei = (string)dr["Idscriptcli"];
            d.html = (string)dr["htmlcli"];
            d.css = (string)dr["csscli"];
            d.js = (string)dr["jscli"];
            d.posX = Convert.ToInt32(dr["posX"]);
            d.posY = Convert.ToInt32(dr["posY"]);
            d.estatus = (string)dr["estatus"];
        
            dev.Add(d);

        }
        con.Close();

        return dev;
    }

    protected void updateCoords(string riscei, double cX, double cY, string estatus) {
        con.Open();
        string updateCmd = "UPDATE Scripts SET posX=@posX, posY=@posY, estatus=@estatus WHERE idscript=@riscei";
        SqlCommand updatecmd = new SqlCommand(updateCmd, con);
        updatecmd.Parameters.AddWithValue("@posX", cX);
        updatecmd.Parameters.AddWithValue("@posY", cY);
        updatecmd.Parameters.AddWithValue("@riscei", riscei);
        updatecmd.Parameters.AddWithValue("@estatus",estatus);
        updatecmd.ExecuteNonQuery();
        con.Close();
    }

    protected string Family(string Modelo) {
        string model = string.Empty;

        if (Modelo.Contains("VA"))
            model = "Ventilador";
        else if (Modelo.Contains("LE"))
            model = "LEDS";
        else if (Modelo.Contains("LU"))
            model = "Luces";
        else if (Modelo.Contains("HW"))
            model = "Aire";

        return model;
    }

    protected string icon(string family) {
        string icons = string.Empty;
        con2.Open();
        SqlCommand cmd = new SqlCommand("select icono from Iconos where nombre=@family", con2);
        cmd.Parameters.AddWithValue("@family", family);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            icons = Convert.ToString(dr[0]);
        }
        con2.Close();
        return icons;
    }

    protected List<string> returnCommands(string familia)
    {
        List<string> comando= new List<string>();
        con2.Open();
        SqlCommand cmd = new SqlCommand("select comando from Eventos where Modelo = @family", con2);
        cmd.Parameters.AddWithValue("@family", familia);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            comando.Add(Convert.ToString(dr[0]));
        }
        con2.Close();

        return comando;
    }

    public class json1 {
        public string imagen { get; set; }
        public List<dispositivo> devices { get; set; }
    }

    public class dispositivo {
        public string riscei { get; set; }
        public string html { get; set; }
        public string css { get; set; }
        public string js { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public string estatus { get; set; }
      
    }
}