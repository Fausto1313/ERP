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

public partial class IOT_ControlMulti : System.Web.UI.Page
{
    
    DataTable dt;
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 17;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, 0) == "RISC")
        {
            if (!IsPostBack)
            {
                iniciarLlenadoDownList();
            }
            else if (permiso.returnPermiso(usuario, pantalla) == "Configurar Planos")
            {

            }
            BindGrid();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    // Los métodos manejadores de eventos tienen una estructura muy sencilla.
    // Son métodos como cualquier otro, pero (habitualmente) tienen dos parámetros de entrada.
    // "sender" es el objeto que ha lanzado el evento. Deberemos parsearlo al tipo que nosotros consideremos.
    // "e" son los argumentos del evento. Deberemos parsearlos al tipo que consideremos si lo quisieramos usar.
   
    public void BindGrid()

    {    }



    //Metodo que ejecuta las acciones dell onclick
    protected void Buscar(object sender, EventArgs e)
    {
        int idnivel = Convert.ToInt32(Nivel1.SelectedValue);
        ConsultarImagenes(idnivel);
        mostrarDarsComprados(idnivel);
        ConsultarScriptsParaCSSEncendidos();
        ConsultarScriptsNofuncion();
        mostrarDarsConfigurados(idnivel);

    }
    protected void Guardar(object sender, EventArgs e)
    {
        int idnivel = Convert.ToInt32(Nivel1.SelectedValue);
        ConsultarImagenes(idnivel);
        mostrarDarsComprados(idnivel);
        ConsultarScriptsParaCSSEncendidos();
        ConsultarScriptsNofuncion();
        mostrarDarsConfigurados(idnivel);

    }

    protected void mostrarDarsComprados(int idnivel)
    {
        string json = null;
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://addar.mx/mapService?funcion=1a&nivel1=" + idnivel);
        Stream recibido;
        recibido = Peticion.GetResponse().GetResponseStream();
        StreamReader json1 = new StreamReader(recibido);
        json = json1.ReadToEnd();
        //string riscei = null, html = null, css = null, js = null;
        string imagen = null;
        RootObject dar = JsonConvert.DeserializeObject<RootObject>(json);
        RootObject obj = new RootObject();

       
            imagen = dar.imagen;

        Response.Write("<script type='text/javascript' src='../Scripts/jquery-1.5.js'></script>");

        Response.Write("<script type='text/javascript' src='//ajax.googleapis.com/ajax/libs/jqueryui/1.8.7/jquery-ui.js' ></script>");

              Response.Write("<div class='menu'>");
       
        foreach (var dev in dar.devices)
            {
            if (dev.estatus == "Comprado")
            {
                Response.Write("<div class='caja'>");
                Response.Write(dev.html + dev.css + dev.js);
                Response.Write("</div>");
            }
        }
   
        Response.Write("</div>");
    }



    protected void mostrarDarsConfigurados(int idnivel)
    {
        string json = null;
        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://addar.mx/mapService?funcion=1a&nivel1=" + idnivel);
        Stream recibido;
        recibido = Peticion.GetResponse().GetResponseStream();
        StreamReader json1 = new StreamReader(recibido);
        json = json1.ReadToEnd();
        //string riscei = null, html = null, css = null, js = null;
        string imagen = null;
        RootObject dar = JsonConvert.DeserializeObject<RootObject>(json);
        RootObject obj = new RootObject();


        imagen = dar.imagen;
        
        foreach (var dev in dar.devices)
        {
            if (dev.estatus == "Configurado")
            {
                ConsultarScriptsParaCSSEncendidos();
                ConsultarScriptsNofuncion();
                Response.Write(dev.html + dev.css + dev.js);
            }
        }
        
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


    public string consultaSolicitud()
    {
        string json = null;
        int idnivel = Convert.ToInt32(Nivel1.SelectedValue);

        WebRequest Peticion = default(WebRequest);
        Peticion = WebRequest.Create("https://addar.mx/mapService?funcion=1a&nivel1=" + idnivel);
        Stream recibido;
        recibido = Peticion.GetResponse().GetResponseStream();
        StreamReader json1 = new StreamReader(recibido);
        json = json1.ReadToEnd();
        return json;
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


    protected string[,] ConsultarScriptsParaCSSEncendidos()
    {
         
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        int coun = 0;
        string[,] dar = null;
        string nivel = Nivel1.SelectedValue;
        string css = null;
        string riscei = null;
        double posx = 0.0;
        double posy = 0.0;
        SqlCommand cmd = new SqlCommand("SELECT  s.idscript, s.posX, s.posY FROM (select d.RISCEI, d.Modelo from dars d inner join UbiDis u on d.UbiDis=u.Id where nivel1=@nivel1) as aa1, Scripts s  where s.estatus = 'Configurado' and(aa1.Modelo = 'DAR-BIS-VA/LE/LU/LS' or aa1.Modelo = 'DAR-BIS-HW' or aa1.Modelo = 'DAR-BIS-MP') and(aa1.RISCEI = s.idscript)", con);
        cmd.Parameters.AddWithValue("@nivel1", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        int i = 0;
        while (dr.Read())
        {
            coun++;
            dar = new string[coun, 3];

            riscei = Convert.ToString(dr[0]);
            posx = Convert.ToDouble(dr[1]);
            posy = Convert.ToDouble(dr[2]);
            i++;

            string conString1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con1 = new SqlConnection(conString);
            con1.Open();
            css = "<style type='text/css'>" +
                          "#F" + riscei + " {position: absolute; left:" + posx + "px; top:" + posy + "px; z-index:10;  float: left; opacity: 1;" +
                          "transition: opacity 1.5s linear;  -webkit-transition: opacity 0.5s linear; cursor: pointer; border: 0px; " +
                          "width: 15px; height: 15px; display: block;  background: #fff;    border-radius: 50%;" +
                          " text-align: center;  line-height: 15px; font-size: 15px; color: rgba(255,0,0,0.8);" +
                          "box-shadow: inset 0 12px 35px rgba(255,255,255,0.6); }" +
                          "#R" + riscei + ":checked + #F" + riscei + " {background: #eee; box-shadow: inset 0 12px 35px rgba(0,0,100,0.6);" +
                          " color: rgba(0,220,0,0.8); transition: opacity 0.5s linear; -webkit-transition: opacity 0.5s linear;" +
                          " opacity: 1.8;}" +
                          "</style>";
            string updateCmd = "UPDATE Scripts SET scss=@css WHERE idscript=@riscei";
            string updateCliCmd = "UPDATE ScriptsCliente SET csscli=@css, posX=@posx,posY=@posy WHERE idscriptcli=@riscei";
            SqlCommand cmd1 = new SqlCommand(updateCmd, con1);
            SqlCommand cmd2 = new SqlCommand(updateCliCmd, con1);
            cmd1.Parameters.AddWithValue("@css", css);
            cmd2.Parameters.AddWithValue("@css", css);
            cmd2.Parameters.AddWithValue("@posx", posx);
            cmd2.Parameters.AddWithValue("@posy", posy);
            cmd1.Parameters.AddWithValue("@riscei", riscei);
            cmd2.Parameters.AddWithValue("@riscei", riscei);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con1.Close();
        }
        con.Close();
        return dar;
    }

    protected string[,] ConsultarScriptsNofuncion()
    {

        string conString2 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con2 = new SqlConnection(conString);
        con2.Open();
        int coun = 0;
        string[,] dar = null;
        string nivel = Nivel1.SelectedValue;
        string css = null;
        string riscei = null;
        double posx = 0.0;
        double posy = 0.0;
        SqlCommand cmd = new SqlCommand("SELECT  s.idscript, s.posX, s.posY FROM (select d.RISCEI, d.Modelo from dars d inner join UbiDis u on d.UbiDis=u.Id where nivel1=@nivel1) as aa1, Scripts s  where s.estatus = 'Configurado' and(aa1.Modelo = 'DAR' or aa1.Modelo = 'DAR-BIS-BP/MG' or aa1.Modelo = 'DAR-BIS-TH' or aa1.Modelo = 'DAR-BIS-SC' or aa1.Modelo = 'DAR-BIS-SU/HS' or aa1.Modelo = 'DAR-BIS-MV/SP/HU' or aa1.Modelo = 'DAR-BIS-AL' or aa1.Modelo = 'DAR-BIS-ED' or aa1.Modelo = 'DAR-BIS-P1' or aa1.Modelo = 'DAR-BIS-CP' or aa1.Modelo = 'DAR-BIS-RF/HD' or aa1.Modelo = 'DAR-BIS-CC') and(aa1.RISCEI = s.idscript)", con2);
        cmd.Parameters.AddWithValue("@nivel1", nivel);
        SqlDataReader dr = cmd.ExecuteReader();
        int i = 0;
        while (dr.Read())
        {
            coun++;
            dar = new string[coun, 3];

            riscei = Convert.ToString(dr[0]);
            posx = Convert.ToDouble(dr[1]);
            posy = Convert.ToDouble(dr[2]);
            i++;

            string conString3 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con3 = new SqlConnection(conString);
            con3.Open();
            css = "<style type='text/css'>" +
                          "#F" + riscei + " {position: absolute; left:" + posx + "px; top:" + posy + "px; z-index:10;  float: left; opacity: 1;" +
                          "transition: opacity 1.5s linear;  -webkit-transition: opacity 0.5s linear; cursor: pointer; border: 0px; " +
                          "width: 15px; height: 15px; display: block;  background: #fff;    border-radius: 50%;" +
                          " text-align: center;  line-height: 15px; font-size: 15px; color: rgba(0,0,255,0.8);" +
                          "box-shadow: inset 0 12px 35px rgba(255,255,255,0.6); }" +
                          "#R" + riscei + ":checked + #F" + riscei + " {background: #eee; box-shadow: inset 0 12px 35px rgba(0,0,100,0.6);" +
                          " color: rgba(0,0,220,0.8); transition: opacity 0.5s linear; -webkit-transition: opacity 0.5s linear;" +
                          " opacity: 1.8;}" +
                          "</style>";
            string updateCmd = "UPDATE Scripts SET scss=@css WHERE idscript=@riscei";
            string updateCliCmd = "UPDATE ScriptsCliente SET csscli=@css, posX=@posx,posY=@posy WHERE idscriptcli=@riscei";
            SqlCommand cmd1 = new SqlCommand(updateCmd, con3);
            SqlCommand cmd2 = new SqlCommand(updateCliCmd, con3);
            cmd1.Parameters.AddWithValue("@css", css);
            cmd2.Parameters.AddWithValue("@css", css);
            cmd2.Parameters.AddWithValue("@posx", posx);
            cmd2.Parameters.AddWithValue("@posy", posy);
            cmd1.Parameters.AddWithValue("@riscei", riscei);
            cmd2.Parameters.AddWithValue("@riscei", riscei);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            con3.Close();
        }
        con2.Close();
        return dar;
    }


    protected void iniciarLlenadoDownList()
    {
        Clientes.DataSource = Consultar("SELECT * FROM CLIENTES ");
        Clientes.DataValueField = "ID";
        Clientes.DataTextField = "RazonSocial";
        Clientes.DataBind();
        Clientes.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Sitios.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        Nivel1.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
    }

    protected void ClienteSelecionado(object sender, EventArgs e)
    {
        int cliente = Convert.ToInt32(Clientes.SelectedValue);
        Sitios.DataSource = Consultar("Select * FROM Sitios Where ID_cliente =" + cliente);
        Sitios.DataValueField = "ID";
        Sitios.DataTextField = "C_Sitio";
        Sitios.DataBind();
        Sitios.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

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
    protected void NivelSeleccionado(object sender, EventArgs e)
    {
    }

    protected DataSet Consultar(string consulta)
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }



}
