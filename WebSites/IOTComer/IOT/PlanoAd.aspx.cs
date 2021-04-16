﻿using System;
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


public partial class IOT_PlanoAd : System.Web.UI.Page
{

    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = Context.User.Identity.Name;
        int pantalla = 6;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Planos Administrador")
        {
            if (!IsPostBack)
            {
                ClienteSelecionado();
            }
            BindGrid();
        }
        else
        {
            Response.Redirect("~/IOT/Home");
        }
    }

    // Los métodos manejadores de eventos tienen una estructura muy sencilla.
    // Son métodos como cualquier otro, pero (habitualmente) tienen dos parámetros de entrada.
    // "sender" es el objeto que ha lanzado el evento. Deberemos parsearlo al tipo que nosotros consideremos.
    // "e" son los argumentos del evento. Deberemos parsearlos al tipo que consideremos si lo quisieramos usar.

    public void BindGrid()

    { }



    //Metodo que ejecuta las acciones dell onclick
    protected void GenerarBotones(object sender, EventArgs e)
    {
        int idnivel = Convert.ToInt32(Nivel1.SelectedValue);
        ConsultarImagenes(idnivel);
        mostrarDarsConfigurados(idnivel);
    }
    protected void GenerarBotones1(object sender, EventArgs e)
    {
        int idnivel = Convert.ToInt32(Nivel1.SelectedValue);
        BarridoCalis();
        mostrarDarsConfigurados(idnivel);
    }
    protected void mostrarDarsConfigurados(int idnivel)
    {
        string json = null;
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("http://addar.mx/mapService?funcion=3a&nivel1=" + idnivel);
        Stream recibido;
        recibido = Peticion.GetResponse().GetResponseStream();
        StreamReader json1 = new StreamReader(recibido);
        json = json1.ReadToEnd();

        RootObject dar = JsonConvert.DeserializeObject<RootObject>(json);
        RootObject obj = new RootObject();
        Response.Write("<script type='text/javascript' src='../Scripts/jquery-1.5.js'></script>");

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

    protected void ConsultarImagenes(int nivel1)
    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT  imagen FROM ImagenesPlano Where nivel1 =@nivel1 ";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@nivel1", nivel1);
        cmd.Connection = con;
        con.Open();
        DataTable imagenesBD = new DataTable();
        imagenesBD.Load(cmd.ExecuteReader());
        Repeater1.DataSource = imagenesBD;
        Repeater1.DataBind();
        con.Close();

    }

    protected void Barrido(object sender, EventArgs e)
    {
        BarridoCalis();
    }

    // Metodo de BARRIDO el cual actualiza la pagina para recuperar los dispositivos por nivel 
    protected void BarridoCalis()
    {

        int nivel = Convert.ToInt32(Nivel1.SelectedValue);
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        string consulta = "select s.NOIP, d.RISCEI from sitios s, dars d inner join (select ID, Cl_Sitio from UbiDis where nivel1 = @nivel) as a1 on a1.Id = d.UbiDis where s.ID = a1.Cl_Sitio and(d.Modelo = 'DAR-BIS-LU/VA/LE' or d.Modelo = 'DAR-BIS-HW')";
        SqlCommand cmd = new SqlCommand(consulta, con);
        cmd.Parameters.AddWithValue("@nivel", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            string ip = string.Empty, dis = string.Empty;
            ip = Convert.ToString(dr[0]);
            dis = Convert.ToString(dr[1]);
            //Response.Write(ip+dis);
            //WebRequest peticion = default(WebRequest);
            //peticion = WebRequest.Create("http://addar.mx:8082/peticion.php?v1="+ip+"&v2="+dis+"&v3=test/");
            string url2 = "http://" + ip + "/" + dis + "/test/";
            try
            {
                string respuesta = returnResponseValue(url2);
                //Response.Write(respuesta);
                if (respuesta.Contains("Encendido"))
                {
                    htmlCheck(dis);
                }
                else if (respuesta.Contains("Apagado"))
                {
                    htmlNOCheck(dis);
                }
            }
            catch
            {
                htmlNOCheck(dis);
            }
        }
    }

    protected string returnResponseValue(string url)
    {
        HttpWebRequest peticion = (HttpWebRequest)WebRequest.Create(url);
        //peticion.KeepAlive= false;
        string json2 = string.Empty;
        //peticion = WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)peticion.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);

        json2 = reader.ReadToEnd();
        reader.Close();
        stream.Close();
        response.Close();
        //peticion.Abort();
        return json2;
    }



    protected string Family(string Modelo)
    {
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
            html = "<input type='checkbox' id='R" + RISCEI + "' checked='checked' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "' style='display:none;'/>" +
                   "<label for='R" + RISCEI + "' id='F" + RISCEI + "' class='" + icono + "' title='" + descripcion + "'></label>";
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
            html = "<input type='checkbox' id='R" + RISCEI + "' onclick='checkFluency(this.id)'" + RISCEI + "' class='C" + RISCEI + "' style='display:none;'/>" +
                   "<label for='R" + RISCEI + "' id='F" + RISCEI + "' class='" + icono + "' title='" + descripcion + "'></label>";
            string updateCliCmd = "UPDATE ScriptsCliente SET htmlcli=@html WHERE idscriptcli=@riscei";
            SqlCommand cmd2 = new SqlCommand(updateCliCmd, con1);
            cmd2.Parameters.AddWithValue("@html", html);
            cmd2.Parameters.AddWithValue("@riscei", RISCEI);
            cmd2.ExecuteNonQuery();
            con1.Close();
        }
        con.Close();

    }

    protected void ClienteSelecionado()
    {
        string usuario = User.Identity.Name;
        Sitios.DataSource = Consultar("Select * FROM Sitios Where ID_cliente =(select ID_Cliente from AspNetUsers where username = '" + usuario + " ')");
        Sitios.DataValueField = "ID";
        Sitios.DataTextField = "C_Sitio";
        Sitios.DataBind();
        Sitios.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Nivel1.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

    }


    protected void SitioSeleccionado(object sender, EventArgs e)
    {
        int sitio = Convert.ToInt32(Sitios.SelectedValue);
        Nivel1.DataSource = Consultar("Select distinct n1.ID, n1.Nombre From nivel1 n1, ubidis ud, sitios s where n1.ID = ud.nivel1 And s.ID = ud.Cl_Sitio AND s.ID = " + sitio);
        Nivel1.DataValueField = "ID";
        Nivel1.DataTextField = "Nombre";
        Nivel1.DataBind();
        Nivel1.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    protected DataSet Consultar(string consulta)
    {
        string usuario = Context.User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

}